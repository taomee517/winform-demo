using DotNetty.Buffers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDK.STD
{
    class MessageBuilder
    {

        public static byte[] BuildMessage()
        {
            var buffer = Unpooled.Buffer(100);
            try
            {
                // start sign

                var msg = new byte[buffer.ReadableBytes];
                buffer.ReadBytes(msg);
                return msg;
            }
            finally
            {
                buffer.Release();
            }
        }
    }
}
