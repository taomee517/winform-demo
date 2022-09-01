using System;
using System.Drawing;
using System.Windows.Forms;
using winform_demo.Client;
using winform_demo.Device;

namespace winform_demo
{
    public partial class Gateway : Form
    {

        private static VirtualClient client;

        public delegate void ShowMsgLog(string role, string msg);
        public delegate void StatusChange(bool online);

        private static StatusChange statusChange;
        private static ShowMsgLog showMsgLog;

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
                    var refreshMsg = history + "\r\n" + boxedMsg;
                    msgBox.Text = refreshMsg;
                }));
            });
        }

        // 创建连接
        private async void connect_Click(object sender, EventArgs e)
        {
            var ip = this.ip.Text;
            var port = Convert.ToInt32(this.port.Text);
            var mac = textBox1.Text;
            var device = new VirtualDevice(mac, showMsgLog, statusChange);
            client = new VirtualClient(ip, port, false, 30, device);
            await client.Start();
        }

        // 断开连接
        private async void disconnect_Click(object sender, EventArgs e)
        {
            await client.Disconnect();
        }

        // 网关通道数调整
        private void channelSize_ValueChanged(object sender, EventArgs e)
        {

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
            if (deviceMessage==null || "".Equals(deviceMessage))
            {
                var errorMsg = "消息内容为空！！！";
                this.errorMessage.Text = errorMsg;
                return;
            }
            client.Send(deviceMessage);
            this.errorMessage.Clear();
        }

        // 设备登录
        private void login_Click(object sender, EventArgs e)
        {
            
        }

        // 设备登出
        private void logout_Click(object sender, EventArgs e)
        {

        }

        // 拉取缓存指令
        private void cacheOrder_Click(object sender, EventArgs e)
        {

        }

        // 清空日志
        private void logClear_Click(object sender, EventArgs e)
        {
            this.msgBox.Clear();
            this.errorMessage.Clear();
            this.messageBuffer.Clear();
        }


        private string boxMessage(string role, string message)
        {
            var time = DateTime.Now.ToString();
            var boxedMsg = time + "\r\n" + role + ":" + message;
            return boxedMsg;
        }
    }
}
