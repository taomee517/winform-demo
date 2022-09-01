using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDK.STD.Constant
{
    class DefaultValue
    {
        public static byte SPLIT_SIGN = Convert.ToByte(0x7e);
        // 数据包最小长度:起始位(1) + 设备号(8) + 消息体属性(3) + 功能号（2） + 流水号（4） +  消息长度（2） + 校验码(2) + 停止位(1)
        public static Int16 MIN_LENGTH = 23;


        // 转义符号 
        public static byte ESCAPE_SIGN = 0x7d;

        // 转义后的7D
        public static byte[] ESCAPE_7D = { 0x7d, 0x00 };

        // 转义后的7E
        public static byte[] ESCAPE_7E = { 0x7d, 0x01 };

        // 版本号
        public static byte VERSION = 1;

        public static Dictionary<string, string> PWD_MAP = new Dictionary<string, string>();

        // 状态码
        public const byte NONE = 0;
        public const byte ACCEPT = 1;
        public const byte SUCCESS = 2;
        public const byte REFUSE = 3;
        public const byte UNSUPPORTED = 4;
        public const byte FAIL = 0xff;


        // 功能号
        public const Int16 REGISTER = 0x0000;
        public const Int16 LOGIN = 0x0001;
        public const Int16 LOGOUT = 0x0002;
        public const Int16 HEART_BEAT = 0x0003;

        public const Int16 TIME = 0x1000;
        public const Int16 DEVICE_INFO = 0x1001;
        public const Int16 BATTERY = 0x1001;
        public const Int16 SERVER_URL = 0x1001;
        public const Int16 INTERVAL = 0x1001;
        public const Int16 SIGNAL = 0x1001;

        public const Int16 CORE_DATA = 0x2000;
        public const Int16 RANDOM_CHANNEL_DATA = 0x2001;
        public const Int16 PENETRATE_DATA = 0x2002;
        public const Int16 SECOND_PACKET_DATA = 0x2003;

        public const Int16 LOWER_THRESHOLD = 0x3000;
        public const Int16 UPPER_THRESHOLD = 0x3001;
        public const Int16 ALARM = 0x3fff;

        public const Int16 EXCITATION_PARAMS = 0x4000;
        public const Int16 CHANNEL_MASK = 0x4001;


        public const Int32 UPGRADE = 0xFF00;
        public const Int32 UPGRADE_CONFIRM = 0xFF01;
        public const Int32 UPGRADE_FILE = 0xFF02;
        public const Int32 UPGRADE_SHARD_REQ = 0xFF03;
        public const Int32 UPGRADE_SHARD = 0xFF04;
        public const Int32 UPGRADE_RESULT = 0xFF05;

        public const Int32 REBOOT = 0xFFF0;
        public const Int32 PULL_CMD = 0xFFFC;
        public const Int32 ECHO = 0xFFFD;
        public const Int32 DEBUG = 0xFFFE;
        public const Int32 ERROR = 0xFFFF;

        public const Int32 MULTI_SUBSCRIBE = 0xFFF0;






    }
}
