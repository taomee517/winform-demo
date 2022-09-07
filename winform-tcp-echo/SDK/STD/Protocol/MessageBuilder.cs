using DotNetty.Buffers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDK.STD.Constant;
using SDK.STD.Utils;
using winform_demo.Utils;
using SDK.STD.Beans;
using Beans;

namespace SDK.STD
{
    class MessageBuilder
    {

        // 创建注册消息
        public static byte[] BuildRegisterMessage(string gatewayNo)
        {
            return BuildMessage(gatewayNo, DefaultValue.REGISTER, RequestType.PUBLISH, new byte[0]);
        }


        // 创建登录消息
        public static byte[] BuildLoginMessage(string gatewayNo)
        {
            if (!DefaultValue.PWD_MAP.ContainsKey(gatewayNo))
            {
                return null;
            }
            String pwd = DefaultValue.PWD_MAP[gatewayNo];
            var pwdBytes = BytesUtil.String2Bytes(pwd);
            var pwdLen = pwdBytes.Length;
            var buffer = Unpooled.Buffer(pwdLen + 4);
            buffer.WriteShort(1);
            buffer.WriteShort(pwdLen);
            buffer.WriteBytes(pwdBytes);
            byte[] tlvBytes = new byte[pwdLen + 4];
            buffer.ReadBytes(tlvBytes);
            return BuildMessage(gatewayNo, DefaultValue.LOGIN, RequestType.PUBLISH, tlvBytes);
        }


        // 创建数据消息
        public static byte[] BuildDataMessage(string gatewayNo, List<SensorDataInfo> sensorDatas)
        {
            var totalChannels = sensorDatas.Count;
            var selectCount = sensorDatas.Count(sensorData=> sensorData.CheckeState);
            int startIndex = sensorDatas.FindIndex(sensorData => sensorData.CheckeState);
            int func = selectCount == sensorDatas.Count ? DefaultValue.CORE_DATA : DefaultValue.RANDOM_CHANNEL_DATA;

            int dataLen = selectCount * 8 + 4;            
            var dataBuffer = Unpooled.Buffer(dataLen);
            dataBuffer.WriteShort(3);
            dataBuffer.WriteShort(selectCount * 8);
            for (int i=0;i< totalChannels; i++)
            {
                // TODO 间隔选择情况兼容 
                if (sensorDatas[i].CheckeState)
                {
                    SensorDataInfo sensorData = sensorDatas[i];
                    List<Object> data = sensorData.Params;
                    dataBuffer.WriteFloat((float)Convert.ToDouble(data[0]));
                    dataBuffer.WriteFloat((float)Convert.ToDouble(data[1]));
                }
            }
            byte[] dataBytes = new byte[dataBuffer.ReadableBytes];
            dataBuffer.ReadBytes(dataBytes);


            int length = func == DefaultValue.CORE_DATA ? (10 + dataLen) : (1 + 1 + dataLen + 10);
            var buffer = Unpooled.Buffer(length);
            if (DefaultValue.RANDOM_CHANNEL_DATA == func)
            {
                // 起始通道
                buffer.WriteShort(1);
                buffer.WriteShort(1);
                buffer.WriteByte(startIndex);

                // 随机通道数
                buffer.WriteShort(2);
                buffer.WriteShort(1);
                int randomCount = 1;
                for (int j = startIndex; j < totalChannels; j++)
                {
                    if (sensorDatas[j].CheckeState && j>startIndex) {
                        randomCount++;
                    }
                    else
                    {
                        break;
                    }
                }
                buffer.WriteByte(selectCount);
            }
            buffer.WriteBytes(dataBytes);
            byte[] tlvBytes = new byte[buffer.ReadableBytes];
            buffer.ReadBytes(tlvBytes);
            return BuildMessage(gatewayNo, func, RequestType.PUBLISH, tlvBytes);
        }

        // 创建状态信息
        public static byte[] BuildBatteryMessage(string gatewayNo, BatteryInfo batteryInfo)
        {
            int statusCount = 0;
            if (batteryInfo.BatteryEnable)
            {
                statusCount++;
            }

            if (batteryInfo.VoltageEnable)
            {
                statusCount++;
            }

            if (batteryInfo.TempEnable)
            {
                statusCount++;
            }

            if (statusCount == 0)
            {
                return null;
            }

            var buffer = Unpooled.Buffer(statusCount * 6);
            if (batteryInfo.BatteryEnable)
            {
                buffer.WriteShort(1);
                buffer.WriteShort(2);
                buffer.WriteShort(Convert.ToInt32(batteryInfo.Battery));
            }

            if (batteryInfo.VoltageEnable) 
            { 
                buffer.WriteShort(2);
                buffer.WriteShort(2);
                buffer.WriteShort(Convert.ToInt32(batteryInfo.Voltage * 1000));
            }
            
            if (batteryInfo.TempEnable)
	        {
                buffer.WriteShort(3);
                buffer.WriteShort(2);
                buffer.WriteShort(Convert.ToInt32(batteryInfo.Temp));
	        }            

            byte[] tlvBytes = new byte[buffer.ReadableBytes];
            buffer.ReadBytes(tlvBytes);
            return BuildMessage(gatewayNo, DefaultValue.BATTERY, RequestType.PUBLISH, tlvBytes);
        }


        // 创建状态信息
        public static byte[] BuildSignalMessage(string gatewayNo, SignalInfo singalInfo)
        {
            if (!singalInfo.SignalEnable)
            {
                return null;
            }

            var buffer = Unpooled.Buffer(6);

            buffer.WriteShort(1);
            buffer.WriteShort(2);
            buffer.WriteShort(Convert.ToInt32(singalInfo.Signal));
            

            byte[] tlvBytes = new byte[buffer.ReadableBytes];
            buffer.ReadBytes(tlvBytes);
            return BuildMessage(gatewayNo, DefaultValue.SIGNAL, RequestType.PUBLISH, tlvBytes);
        }


        // 创建登出消息
        public static byte[] BuildLogoutMessage(string gatewayNo)
        {
            return BuildMessage(gatewayNo, DefaultValue.LOGOUT, RequestType.PUBLISH, new byte[0]);
        }


        // 创建获取缓存指令
        public static byte[] BuildCacheOrderMessage(string gatewayNo)
        {
            return BuildMessage(gatewayNo, DefaultValue.PULL_CMD, RequestType.EXECUTE, new byte[0]);
        }

        public static byte[] BuildMessage(string gatewayNo, int func, RequestType requestType, byte[] content)
        {
            var buffer = Unpooled.Buffer();
            try
            {
                // start sign
                buffer.WriteByte(DefaultValue.SPLIT_SIGN);

                // gateway no
                var gatewayNoBytes = GatewayNo2Bytes(gatewayNo);
                buffer.WriteBytes(gatewayNoBytes);

                // 属性
                byte[] attr = new byte[3];
                attr[0] = DefaultValue.VERSION;
                attr[1] = DefaultValue.NONE;
                byte info = (byte)(((int)EnvironmentType.RELEASE << 7) | ((int)FormatType.TLV << 3) | requestType);
                attr[2] = info;
                buffer.WriteBytes(attr);

                // func
                buffer.WriteShort(func);
                // serial-device
                buffer.WriteShort(1);
                // serial-server
                buffer.WriteShort(1);

                // serial-device
                int length = content.Length;
                buffer.WriteShort(length);

                if (length > 0)
                {
                    buffer.WriteBytes(content);
                }

                //校验码
                var validatingContent = new byte[buffer.ReadableBytes - 1];
                buffer.GetBytes(1, validatingContent);
                byte[] crc = CRCUtil.CalBytesCrc(validatingContent);
                buffer.WriteBytes(crc);

                // end sign
                buffer.WriteByte(DefaultValue.SPLIT_SIGN);

                //var msg = new byte[buffer.ReadableBytes];
                //buffer.ReadBytes(msg);
                //return msg;
                return Escape(buffer);
            }
            finally
            {
                buffer.Release();
            }
        }



        private static byte[] Escape(IByteBuffer message)
        {
            var result = Unpooled.Buffer();
            try 
            { 
                // head
                result.WriteByte(message.ReadByte());
                while (message.ReadableBytes > 3)
                {
                    byte curr = message.ReadByte();
                    if (curr == DefaultValue.ESCAPE_SIGN)
                    {
                        result.WriteBytes(DefaultValue.ESCAPE_7D);
                        continue;
                    }
                    if (curr == DefaultValue.SPLIT_SIGN)
                    {
                        result.WriteBytes(DefaultValue.ESCAPE_7E);
                        continue;
                    }
                    result.WriteByte(curr);
                }
                var tailBytes = new byte[3];
                message.ReadBytes(tailBytes);
                result.WriteBytes(tailBytes);
                result.AdjustCapacity(result.ReadableBytes);

                var msg = new byte[result.ReadableBytes];
                result.ReadBytes(msg);
                return msg;
            }
            finally
            {
                result.Release();
            }
}




        private static byte[] GatewayNo2Bytes(string gatewayNo)
        {
            byte[] result = new byte[8];
            var gwHex = ZeroFillStr(gatewayNo, 16);
            for (int i = 0; i < gwHex.Length; i += 2)
            {
                var sHex = gwHex.Substring(i, 2);
                int intValue = Convert.ToInt32(sHex, 16);
                result[i / 2] = (byte)intValue;
            }
            return result;
        }

        public static String Bytes2GatewayNo(byte[] bytes)
        {
            StringBuilder sb = new StringBuilder();
            var len = bytes.Length;
            for (int i=0; i< len; i++)
            {
                byte b = bytes[i];
                var ss = Convert.ToString(b & 0xff, 16);
                ss = ZeroFillStr(ss, 2);
                sb.Append(ss);
            }
            return sb.ToString();
        }


        public static string ZeroFillStr(string text, int len)
        {
            int textLen = text.Length;
            if (textLen < len)
            {
                for (int i = 0; i < len - textLen; i++)
                {
                    text = "0" + text;
                }
            }
            else
            {
                text = text.Substring(textLen - len);
            }
            return text;
        }

        public static string TailZeroFillStr(string text, int len)
        {
            int index = text.IndexOf(".");
            int tailLen = 0;
            if (index < 0)
            {
                text += ".";
            }
            else
            {
                var tail = text.Substring(index + 1);
                tailLen = tail.Length;

            }
            if (tailLen < len)
            {
                for (int i = 0; i < len - tailLen; i++)
                {
                    text += "0";
                }
            }
            return text;
        }
    }
}
