using Beans;
using Constant;
using Device;
using DotNetty.Buffers;
using SDK.MEASURE.Constant;
using SDK.MEASURE.Protocol;
using SDK.STD;
using SDK.STD.Beans;
using SDK.STD.Constant;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using winform_demo.Client;
using winform_demo.Device;
using winform_demo.Utils;

namespace Windows
{
    public partial class Gateway : Form
    {
        private int SensorType = 27000;
        private static VirtualClient client;

        public delegate void ShowMsgLog(string role, string msg);
        public delegate void StatusChange(bool online);
        public delegate void PwdGetter(string pwd);
        public delegate void AsyncCallBack();
        

        private static StatusChange statusChange;
        private static ShowMsgLog showMsgLog;
        private static PwdGetter pwdGetter;
        private static AsyncCallBack asyncCallBack;

        private static SensorModelInfo defaultSensorModel;
        private static List<SensorDataInfo> sensorDatas = new List<SensorDataInfo>();

        public Gateway()
        {
            InitializeComponent();
            // 连接状态变更 委托初始化
            statusChange = new StatusChange(status =>
             {
                 this.Invoke(new Action(() =>
                 {
                     if (status)
                     {
                         socketStatus.ForeColor = Color.Green;
                         socketStatus.Text = "连接成功";

                     }
                     else
                     {
                         socketStatus.ForeColor = Color.Red;
                         socketStatus.Text = "连接断开";
                     }
                 }));
             });

            // 消息日志 委托初始化
            showMsgLog = new ShowMsgLog((role,msg) =>
            {
                // 解决异步线程调用异常
                this.Invoke(new Action(() =>
                {
                    var history = msgBox.Text;
                    if ("Device".Equals(role))
                    {
                        msgBox.Anchor = AnchorStyles.Right;
                    }
                    var boxedMsg = boxMessage(role, msg);
                    if (history == null || "".Equals(history))
                    {
                        msgBox.Text = boxedMsg;
                    }
                    else
                    {
                        msgBox.Text = history + "\r\n" + boxedMsg;
                    }
                }));               
            });


            pwdGetter = new PwdGetter(pwd =>
            {
                this.Invoke(new Action(() =>
                {
                    pwdBox.Text = pwd;
                    errorMessage.Text = "成功获取登录口令：" + pwd;
                }));
            });


            asyncCallBack = new AsyncCallBack(() =>
            {
                this.Invoke(new Action(() =>
                {
                    generateAndLoad();
                    fulfillSendBox();
                    var deviceMessage = this.messageBuffer.Text;
                    if (deviceMessage == null || "".Equals(deviceMessage))
                    {
                        var errorMsg = "==RECYCLE==消息内容为空！！！";
                        this.errorMessage.Text = errorMsg;
                        return;
                    }
                    client.Send(deviceMessage);
                    this.messageBuffer.Clear();
                    this.errorMessage.Clear();
                }));
            });


            this.gatewayNoBox.Text = "4854000000000001";
            this.portBox.Text = "21703";
            this.MeasureMonitorDataSettingBox.Hide();
            this.MeasureMonitorFuncsPanel.Hide();

            defaultSensorModel = new SensorModelInfo();
            defaultSensorModel.ModelName = "振弦默认传感器";
            defaultSensorModel.ParamSize = 2;
            defaultSensorModel.ParamNames = new List<string>(){ "频率", "电阻" };
            defaultSensorModel.ParamUnits = new List<string>() { "Hz", "Ω" };
        }

        // 创建连接
        private async void connect_Click(object sender, EventArgs e)
        {
            var ip = this.ip.Text;
            var port = Convert.ToInt32(this.portBox.Text);
            var mac = gatewayNoBox.Text;
            var device = MockDeviceFactory.BuildMockDevice(this.SensorType, mac, showMsgLog, statusChange, pwdGetter);
            client = new VirtualClient(ip, port, false, 30, device);
            await client.Start();
        }

        // 断开连接
        private async void disconnect_Click(object sender, EventArgs e)
        {
            await client.Disconnect();
        }


        // 设备端发送消息至服务端
        private void send_Click(object sender, EventArgs e)
        {
            if (client == null || !client.Active())
            {
                var errorMsg = "请先创建连接！！！";
                this.errorMessage.Text = errorMsg;
                return;

            }
            var deviceMessage = this.messageBuffer.Text;            
            if (deviceMessage == null || "".Equals(deviceMessage))
            {
                var errorMsg = "消息内容为空！！！";
                this.errorMessage.Text = errorMsg;
                return;
            }
            client.Send(deviceMessage);
            this.messageBuffer.Clear();
            this.errorMessage.Clear();

            bool scheduleSetting = this.scheduledBox.Checked;
            var intervalValue = this.intervalSelect.Value;
            if (scheduleSetting && intervalValue > 0)
            {
                recycleGenDataAndSend();
            }
        }

        // 设备登录
        private void register_Click(object sender, EventArgs e)
        {
            var gatewayNo = this.gatewayNoBox.Text;
            if (!gatewayNoValidate(gatewayNo)) return;

            byte[] bytes = MessageBuilder.BuildRegisterMessage(gatewayNo);
            this.messageBuffer.Text = bytesFormat(bytes); ;

            //Task.Run(async delegate
            //{
            //    await Task.Delay(1000);
            //    send_Click(sender, e);
            //});

            //send_Click(sender, e);

        }

        // 设备登录
        private void login_Click(object sender, EventArgs e)
        {
            var gatewayNo = this.gatewayNoBox.Text;
            if (!gatewayNoValidate(gatewayNo)) return;

            if (!DefaultValue.PWD_MAP.ContainsKey(gatewayNo))
            {
                var errorMsg = "请先注册，获取临时口令！！！";
                this.errorMessage.Text = errorMsg;
                return;
            }
            byte[] bytes = MessageBuilder.BuildLoginMessage(gatewayNo);
            this.messageBuffer.Text = bytesFormat(bytes); 
        }

        // 设备登出
        private void logout_Click(object sender, EventArgs e)
        {
            var gatewayNo = this.gatewayNoBox.Text;
            if (!gatewayNoValidate(gatewayNo)) return;

            byte[] bytes = MessageBuilder.BuildLogoutMessage(gatewayNo);
            this.messageBuffer.Text = bytesFormat(bytes);
        }

        // 拉取缓存指令
        private void cacheOrder_Click(object sender, EventArgs e)
        {
            var gatewayNo = this.gatewayNoBox.Text;
            if (!gatewayNoValidate(gatewayNo)) return;
            byte[] bytes = MessageBuilder.BuildCacheOrderMessage(gatewayNo);
            this.messageBuffer.Text = bytesFormat(bytes);
        }

        // 清空日志
        private void logClear_Click(object sender, EventArgs e)
        {
            this.msgBox.Clear();
            this.errorMessage.Clear();
            this.messageBuffer.Clear();
        }



        private void buildStatusMsg_Click(object sender, EventArgs e)
        {
            var gatewayNo = this.gatewayNoBox.Text;
            if (!gatewayNoValidate(gatewayNo)) return;

            // 生成电池信息对象
            BatteryInfo batteryInfo = new BatteryInfo();
            batteryInfo.BatteryEnable = this.batteryCheckBox.Checked;
            batteryInfo.VoltageEnable = this.voltageCheckBox.Checked;
            batteryInfo.TempEnable = this.tempCheckBox.Checked;

            var batteryVal = this.batteryBox.Text;
            if (batteryVal==null || "".Equals(batteryVal) && batteryInfo.BatteryEnable)
            {
                this.batteryBox.BackColor = Color.Red;
                return;
            }
            var voltageVal = this.voltageBox.Text;
            if (voltageVal == null || "".Equals(voltageVal) && batteryInfo.VoltageEnable)
            {
                this.voltageBox.BackColor = Color.Red;
                return;
            }

            var tempVal = this.tempBox.Text;
            if (tempVal == null || "".Equals(tempVal) && batteryInfo.TempEnable)
            {
                this.tempBox.BackColor = Color.Red;
                return;
            }

            batteryInfo.Battery = Convert.ToDouble(batteryVal);
            batteryInfo.Voltage = Convert.ToDouble(voltageVal);
            batteryInfo.Temp = Convert.ToDouble(tempVal);
            byte[] batterStatusMsg = MessageBuilder.BuildBatteryMessage(gatewayNo, batteryInfo);
            this.messageBuffer.Text = bytesFormat(batterStatusMsg) + " ";
            this.batteryBox.BackColor = Color.White;
            this.voltageBox.BackColor = Color.White;
            this.tempBox.BackColor = Color.White;


            //生成信号信息对象
            SignalInfo signalInfo = new SignalInfo();
            signalInfo.SignalEnable = this.signalCheckBox.Checked;

            var signalVal = this.signalBox.Text;
            if (signalVal == null || "".Equals(signalVal) && signalInfo.SignalEnable)
            {
                this.signalBox.BackColor = Color.Red;
                return;
            }

            signalInfo.Signal = Convert.ToDouble(signalVal);
            byte[] signalStatusMsg = MessageBuilder.BuildSignalMessage(gatewayNo, signalInfo);
            this.messageBuffer.Text += bytesFormat(signalStatusMsg);
            this.signalBox.BackColor = Color.White;
        }

        private void buildDataMsg_Click(object sender, EventArgs e)
        {
            fulfillSendBox();
        }

        
        private void buildRandomData_Click(object sender, EventArgs e)
        {
            generateAndLoad();
            this.baseFBox.BackColor = Color.White;
            this.baseRBox.BackColor = Color.White;
            this.swingFBox.BackColor = Color.White;
            this.swingRBox.BackColor = Color.White;
        }

        public void randomDataDialog_Apply(object sender, DataEventArgs e)
        {
            List<SensorDataInfo> latestSensorDatas = e.SensorDatas;
            int dataSize = latestSensorDatas.Count;
            if (dataSize > 0) {                
                for (int i = 0; i < dataSize; i++)
                {
                    SensorDataInfo dataInfo = sensorDatas[i];
                    if (dataInfo.CheckeState)
                    {
                        List<Object> paramDatas = dataInfo.Params;
                        string item = "CH-" + (i + 1) + "\t频率：" + MessageBuilder.TailZeroFillStr(paramDatas[0].ToString(), 2) + " Hz\t电阻：" + MessageBuilder.TailZeroFillStr(paramDatas[1].ToString(), 2) + " Ω";
                        this.selectChannelsBox.Items[i] = item;
                        this.selectChannelsBox.SetItemChecked(i, true);
                    }else
                    {
                        this.selectChannelsBox.Items[i] = "CH-" + (i + 1);
                        this.selectChannelsBox.SetItemChecked(i, false);
                    }                    
                }
                sensorDatas = latestSensorDatas;
            }
        }



        private void channelDataEdit_Click(object sender, EventArgs e)
        {
            int totalChannelSize = Convert.ToInt32(this.channelSize.Value);
            //List<Int32> selectedChannelIndexes = new List<Int32>();
            //CheckedListBox channelSelect = this.selectChannelsBox;
            //for (int i = 0; i < totalChannelSize; i++)
            //{
            //    if (channelSelect.GetItemChecked(i))
            //    {
            //        selectedChannelIndexes.Add(i);
            //    }
            //}
            ChannelForm chf = new ChannelForm(totalChannelSize, TopologyType.P2P,  sensorDatas);
            // 将DataApply的实现委托为randomDataDialog_Apply方法
            chf.DataApply += randomDataDialog_Apply;
            chf.Show();
        }



        // 网关通道数调整
        private void channelSize_ValueChanged(object sender, EventArgs e)
        {
            CheckedListBox selectedChannels = this.selectChannelsBox;
            selectedChannels.Items.Clear();
            int chSize = Convert.ToInt32(this.channelSize.Value);
            for(int i=0;i<chSize; i++) 
            {
                var item = "CH-" + (i + 1);      
                selectedChannels.Items.Add(item);
                selectedChannels.SetItemChecked(i, true);
            }            
        }



        private void allChannelSelect(object sender, EventArgs e)
        {
            CheckedListBox selectedChannels = this.selectChannelsBox;
            int chSize = Convert.ToInt32(this.channelSize.Value);
            for (int i = 0; i < chSize; i++)
            {
                selectedChannels.SetItemChecked(i, true);
            }
        }

        private void allChannelRemove(object sender, EventArgs e)
        {
            sensorDatas.Clear();
            CheckedListBox selectedChannels = this.selectChannelsBox;
            int chSize = Convert.ToInt32(this.channelSize.Value);
            for (int i = 0; i < chSize; i++)
            {
                var item = "CH-" + (i + 1);
                this.selectChannelsBox.Items[i] = item;
                selectedChannels.SetItemChecked(i, false);
            }
        }


        // 生成监控量测设备详情报文
        private void measureDeviceInfoBtn_Click(object sender, EventArgs e)
        {
            var gatewayNo = this.gatewayNoBox.Text;
            if (!gatewayNoValidate(gatewayNo)) return;

            // core 
            byte[] gatewayBytes = System.Text.Encoding.UTF8.GetBytes(gatewayNo);
            IByteBuffer buffer = Unpooled.Buffer();
            buffer.WriteShort(0xD007);
            buffer.WriteShort(gatewayBytes.Length + 1);
            // option
            byte option = 1 << 5;
            buffer.WriteByte(option);
            buffer.WriteBytes(gatewayBytes);
            int readableBytes = buffer.ReadableBytes;
            buffer.AdjustCapacity(readableBytes);
            byte[] core = new byte[readableBytes];
            buffer.ReadBytes(core);

            // content
            byte[] content = MeasureMessageBuilder.BuildContent(1,2,0xD00,core);

            // message bytes
            byte[] message = MeasureMessageBuilder.BuildMessage(SDK.MEASURE.Constant.HardwareType.GATEWAY, gatewayNo, content);
            this.messageBuffer.Text = bytesFormat(message);
        }


        // 生成监控量测数据报文
        private void measureDataBtn_Click(object sender, EventArgs e)
        {
            var gatewayNo = this.gatewayNoBox.Text;
            if (!gatewayNoValidate(gatewayNo)) return;

            var horizontalDistance = this.horizontalDistanceBox.Text;
            var horizontalAngle = this.horizontalAngleBox.Text;
            var virticalDistance = this.virticalDistanceBox.Text;
            var virticalAngle = this.virticalAngleBox.Text;

            var signal = this.signalBox.Text;

            // 数据格式校验
            if (
                !valueTextValidate(horizontalDistance)  ||
                !valueTextValidate(horizontalAngle)     ||
                !valueTextValidate(virticalDistance)    ||
                !valueTextValidate(virticalAngle)       ||
                !valueTextValidate(signal)
            ) return;

            int errorCode = 0;
            byte[] horizontalMsg = MeasureMessageBuilder.BuildDataMessage(gatewayNo,
                Convert.ToInt32(LaserDirection.HORIZONTAL),
                Convert.ToInt32(horizontalDistance),
                Convert.ToInt32(horizontalAngle),
                Convert.ToInt32(signal), errorCode);

            byte[] virticalMsg = MeasureMessageBuilder.BuildDataMessage(gatewayNo,
                Convert.ToInt32(LaserDirection.VIRTICAL),
                Convert.ToInt32(virticalDistance),
                Convert.ToInt32(virticalAngle),
                Convert.ToInt32(signal), errorCode);
            var msgBuf = bytesFormat(horizontalMsg) + " " + bytesFormat(virticalMsg);
            this.messageBuffer.Text = msgBuf;
        }


        private void measureRandomDataBtn_Click(object sender, EventArgs e)
        {
            var horizontalDistance = this.horizontalDistanceBox.Text;
            var horizontalAngle = this.horizontalAngleBox.Text;
            var virticalDistance = this.virticalDistanceBox.Text;
            var virticalAngle = this.virticalAngleBox.Text;


            // 数据格式校验
            if (
                !valueTextValidate(horizontalDistance) ||
                !valueTextValidate(horizontalAngle) ||
                !valueTextValidate(virticalDistance) ||
                !valueTextValidate(virticalAngle)
            ) return;


            // 随机范围
            var horizontalRandomDistance = this.horizontalDistanceRandomBox.Text;
            var horizontalRandomAngle = this.horizontalAngleRandomBox.Text;
            var virticalRandomDistance = this.virticalDistanceRandomBox.Text;
            var virticalRandomAngle = this.virticalAngleRandomBox.Text;


            // 随机范围数据格式校验
            if (
                !valueTextValidate(horizontalRandomDistance) ||
                !valueTextValidate(horizontalRandomAngle) ||
                !valueTextValidate(virticalRandomDistance) ||
                !valueTextValidate(virticalRandomAngle)
            ) return;

            Random random = new Random();
            int multiply = random.Next() % 2 == 0?1:-1;
            this.horizontalDistanceBox.Text = (Convert.ToInt32(horizontalDistance) + (int)(random.NextDouble() * Convert.ToInt32(horizontalRandomDistance)) * multiply).ToString();
            this.horizontalAngleBox.Text = (Convert.ToInt32(horizontalAngle) + (int)(random.NextDouble() * Convert.ToInt32(horizontalRandomAngle)) * multiply).ToString();
            this.virticalDistanceBox.Text = (Convert.ToInt32(virticalDistance) + (int)(random.NextDouble() * Convert.ToInt32(virticalRandomDistance)) * multiply).ToString();
            this.virticalAngleBox.Text = (Convert.ToInt32(virticalAngle) + (int)(random.NextDouble() * Convert.ToInt32(virticalRandomAngle)) * multiply).ToString();
        }


        // 点击航天振弦
        private void aeroVM_Click(object sender, EventArgs e)
        {
            this.SensorType = 27000;
            this.gatewayNoBox.Text = "4854000000000001";
            this.portBox.Text = "21703";
            this.pwdLabel.Show();
            this.pwdBox.Show();
            this.AeroVMPanel.Show();
            this.AeroVMDataSettingBox.Show();
            this.AeroVMFuncsPanel.Show();
            this.MeasureMonitorDataSettingBox.Hide();
            this.MeasureMonitorFuncsPanel.Hide();

        }


        // 点击监控量测
        private void measureMonitor_Click(object sender, EventArgs e)
        {
            this.SensorType = 7000;
            this.portBox.Text = "19014";
            this.gatewayNoBox.Text = "CL202200000001";
            this.pwdLabel.Hide();
            this.pwdBox.Hide();
            this.AeroVMPanel.Hide();
            this.AeroVMDataSettingBox.Hide();            
            this.AeroVMFuncsPanel.Hide();
            this.MeasureMonitorDataSettingBox.Show();
            this.MeasureMonitorFuncsPanel.Show();
        }


        // 生成随机数据
        private void generateAndLoad()
        {
            sensorDatas.Clear();
            var baseFVal = this.baseFBox.Text;
            var baseRVal = this.baseRBox.Text;
            var swingFVal = this.swingFBox.Text;
            var swingRVal = this.swingRBox.Text;
            if (baseFVal == null || "".Equals(baseFVal))
            {
                this.baseFBox.BackColor = Color.Red;
                return;
            }

            if (baseRVal == null || "".Equals(baseRVal))
            {
                this.baseRBox.BackColor = Color.Red;
                return;
            }

            if (swingFVal == null || "".Equals(swingFVal))
            {
                this.swingFBox.BackColor = Color.Red;
                return;
            }

            if (swingRVal == null || "".Equals(swingRVal))
            {
                this.swingRBox.BackColor = Color.Red;
                return;
            }

            var baseF = Convert.ToDouble(baseFVal);
            var baseR = Convert.ToDouble(baseRVal);
            var swingF = Convert.ToDouble(swingFVal);
            var swingR = Convert.ToDouble(swingRVal);
            Random random = new Random();
            var chSize = this.channelSize.Value;
            for (int i = 0; i < chSize; i++)
            {
                var randomNF = Math.Round(baseF + random.NextDouble() * swingF, 2);
                var randomNR = Math.Round(baseR + random.NextDouble() * swingR);
                if (this.selectChannelsBox.GetItemChecked(i))
                {
                    string item = "CH-" + (i + 1) + "\t频率：" + MessageBuilder.TailZeroFillStr(randomNF.ToString(), 2) + " Hz\t电阻：" + MessageBuilder.TailZeroFillStr(randomNR.ToString(), 2) + " Ω";
                    this.selectChannelsBox.Items[i] = item;
                }
                SensorDataInfo sensorData = new SensorDataInfo();
                sensorData.ModelInfo = defaultSensorModel;
                sensorData.CheckeState = this.selectChannelsBox.GetItemChecked(i);
                sensorData.Params = new List<object>() { randomNF, randomNR };
                sensorDatas.Add(sensorData);
            }
        }

        // 生成数据报文，填充待发送框
        private void fulfillSendBox()
        {
            var gatewayNo = this.gatewayNoBox.Text;
            if (!gatewayNoValidate(gatewayNo)) return;

            if (this.selectChannelsBox.CheckedItems.Count == 0)
            {
                var errorMsg = "未选中任何通道！！！";
                this.errorMessage.Text = errorMsg;
                return;
            }

            if (sensorDatas.Count == 0)
            {
                var errorMsg = "请先生成通道数据！！！";
                this.errorMessage.Text = errorMsg;
                this.selectChannelsBox.BackColor = Color.Red;
                return;
            }
            byte[] bytes = MessageBuilder.BuildDataMessage(gatewayNo, sensorDatas);
            this.messageBuffer.Text = bytesFormat(bytes);
            this.selectChannelsBox.BackColor = Color.White;
        }

        private bool gatewayNoValidate(string gatewayNo)
        {
            if (gatewayNo == null || "".Equals(gatewayNo))
            {
                var errorMsg = "网关号为空！！！";
                this.errorMessage.Text = errorMsg;
                return false;
            }

            if (this.SensorType == 27000)
            {
                if (gatewayNo.Length != 16 || !gatewayNo.StartsWith("4854"))
                {
                    var errorMsg = "网关号格式不符！！！";
                    this.errorMessage.Text = errorMsg;
                    return false;
                }
            }
            else if(this.SensorType == 7000)
            {
                if (gatewayNo.Length != 14 || !gatewayNo.StartsWith("CL"))
                {
                    var errorMsg = "网关号格式不符！！！";
                    this.errorMessage.Text = errorMsg;
                    return false;
                }
            }

            return true;
        }

        private bool valueTextValidate(string text)
        {
            if (text == null || "".Equals(text))
            {
                var errorMsg = "数据为空！！！";
                this.errorMessage.Text = errorMsg;
                return false;
            }
            try
            {
                var value = Convert.ToDecimal(text);
            }
            catch(Exception e)
            {
                var errorMsg = "数据格式异常！！！";
                this.errorMessage.Text = errorMsg;
                return false;
            }
            return true;
        }


        private void recycleGenDataAndSend()
        {
            int interval = Convert.ToInt32(this.intervalSelect.Value);
            var job = new Task(() =>
            {
                while (this.scheduledBox.Checked)
                {
                    Thread.Sleep(interval);
                    asyncCallBack.Invoke();
                }
            });
            job.Start();
        }


        private string bytesFormat(byte[] bytes)
        {
            return BytesUtil.BytesToHexWithBlank(bytes);
        }

        private string boxMessage(string role, string message)
        {
            var time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff", DateTimeFormatInfo.InvariantInfo);
            var boxedMsg = time + "\t" + role + "\r\n" +  message;
            return boxedMsg;
        }
    }
}
