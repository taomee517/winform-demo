using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDK.STD.Constant
{
    enum RequestType
    {
        QUERY,
        QUERY_ACK,
        SETTING,
        SETTING_ACK,
        PUBLISH,
        PUBLISH_ACK,
        EXECUTE,
        EXECUTE_ACK,
        SUBSCRIBE,
        SUBSCRIBE_ACK,
        UNSUBSCRIBE,
        UNSUBSCRIBE_ACK
    }
}
