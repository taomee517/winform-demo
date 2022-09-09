using DotNetty.Buffers;
using SDK.MEASURE.Constant;
using SDK.MEASURE.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDK.MEASURE.Protocol
{
    public class MeasureMessageBuilder
    {

        public static byte[] BuildDataMessage(string gatewayNo,int laserDirection, int distance, int angle, int signal, int errorCode )
        {
            // core 
            IByteBuffer buffer = Unpooled.Buffer();
            buffer.WriteShort(0xD010);
            buffer.WriteShort(13);
            // time
            long timeStamp = DateTimeOffset.Now.ToUnixTimeSeconds();
            buffer.WriteInt((int)timeStamp);
            buffer.WriteByte(Convert.ToByte(ReportReason.SCHEDULED));
            // 水平数据
            buffer.WriteByte(laserDirection);
            buffer.WriteShort(distance);
            buffer.WriteShort(angle);

            // 信号 + 错误码
            buffer.WriteShort(signal);
            buffer.WriteByte(errorCode);

            int readableBytes = buffer.ReadableBytes;
            buffer.AdjustCapacity(readableBytes);
            byte[] core = new byte[readableBytes];
            buffer.ReadBytes(core);

            // content
            byte[] content = BuildContent(1, 2, 0xD00, core);

            // message bytes
            byte[] message = BuildMessage(SDK.MEASURE.Constant.HardwareType.GATEWAY, gatewayNo, content);

            return message;
        }

        public static byte[] BuildMessage(HardwareType hardwareType, string gatewayNo, byte[] content)
        {
            var buffer = Unpooled.Buffer();
            try
            {
                // start sign
                buffer.WriteBytes(MeasureDefault.START_SIGN);

                // length
                int contentLen = content.Length;
                // 去掉head 和 crc的长度
                int totalLen = contentLen + 7;
                buffer.WriteShort(totalLen);

                // hardware-type
                buffer.WriteByte(Convert.ToByte(hardwareType) + 1);

                // mac 
                byte[] macBytes = DeviceId2Bytes(gatewayNo);
                buffer.WriteBytes(macBytes);

                // content
                buffer.WriteBytes(content);

                //crc校验
                byte[] data = new byte[buffer.ReadableBytes];
                buffer.GetBytes(0, data);

                byte[] crc = CRCUtil.CalCrc(data);
                buffer.WriteBytes(crc);

                byte[] result = new byte[buffer.ReadableBytes];
                buffer.ReadBytes(result);
                return result;
            }
            finally
            {
                buffer.Release();
            }
        }


        public static byte[] BuildContent(int serial, int bizType, int funcType, byte[] core)
        {
            int coreLen = core.Length;
            IByteBuffer buffer = Unpooled.Buffer(coreLen + MeasureDefault.PROTOCOL_VERSION_LENGTH + MeasureDefault.BUSINESS_SN_LENGTH + MeasureDefault.FUNCTION_TYPE_LENGTH);
            buffer.WriteByte(MeasureDefault.DEFAULT_PROTOCOL_VERSION);
            buffer.WriteShort(serial);
            int funcVal = ((bizType & 0xf) << 12) | funcType & 0xfff;
            buffer.WriteShort(funcVal);
            if (coreLen>0)
            {
                buffer.WriteBytes(core);
            }
            
            byte[] content = new byte[buffer.ReadableBytes];
            buffer.ReadBytes(content);
            return content;
        }

        public static byte[] BuildTLVContent(int dataType, byte[] data)
        {
            IByteBuffer buf = Unpooled.Buffer();
            buf.WriteShort(dataType);
            buf.WriteShort(data.Length);
            buf.WriteBytes(data);
            byte[] tlvContent = new byte[data.Length + 4];
            buf.ReadBytes(tlvContent);
            return tlvContent;
        }



        public static byte[] DeviceId2Bytes(string deviceId)
        {
            if (deviceId.StartsWith("CL"))
            {
                deviceId = deviceId.Substring(2);
            }
            byte[] bytes = new byte[6];
            int len = deviceId.Length;
            for (int i = 0; i < len - 1; i += 2)
            {
                String temp = deviceId.Substring(i, 2);
                bytes[i / 2] = Convert.ToByte(temp, 16);
            }
            return bytes;
        }
    }
}
