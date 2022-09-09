using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDK.MEASURE.Constant
{
    public class MeasureDefault
    {
        public static readonly byte[] START_SIGN = new byte[] { 0x3A, 0xA3 & 0xff };

        public const int MIN_LENGTH = 13;

        public const int HARDWARE_TYPE_LENGTH = 1;

        public const int MAC_LENGTH = 6;


        //协议版本长度
        public const byte DEFAULT_PROTOCOL_VERSION = 1;
        public const int PROTOCOL_VERSION_LENGTH = 1;

        //业务流水号长度
        public const int BUSINESS_SN_LENGTH = 2;

        //业务类型 + 功能码
        public const int FUNCTION_TYPE_LENGTH = 2;


        /**
         * 拼接符号
         */
        public const string MAC_PREFIX = "CL";

        public const string ENV_CONNECTOR = "=";

        public const string MULTI_ENV_SPLITOR = ",";
    }
}
