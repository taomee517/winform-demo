using DotNetty.Buffers;
using DotNetty.Codecs;
using DotNetty.Common.Utilities;
using DotNetty.Transport.Channels;
using SDK.STD.Constant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using winform_demo.Utils;

namespace SDK.STD.Protocol
{
    class StdEscapeHandler : MessageToMessageEncoder<IByteBuffer>
    {
        protected override void Encode(IChannelHandlerContext context, IByteBuffer message, List<object> output)
        {
            var result = Unpooled.Buffer();
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
            output.Add(result);
        }
    }
}
