using DotNetty.Buffers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDK.STD.Constant;
using SDK.STD.Utils;
using winform_demo.Utils;

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

                var msg = new byte[buffer.ReadableBytes];
                buffer.ReadBytes(msg);
                return msg;
            }
            finally
            {
                buffer.Release();
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


        private static string ZeroFillStr(string text, int len)
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
    }
}
