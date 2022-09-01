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
    class StdUnescapeHandler : SimpleChannelInboundHandler<IByteBuffer>
    {
        protected override void ChannelRead0(IChannelHandlerContext ctx, IByteBuffer input)
        {
            //int firstRdx = input.ReaderIndex;
            var result = Unpooled.Buffer();
            bool skip = false;
            byte[] temp = new byte[2];
            while (input.ReadableBytes > 1)
            {
                byte curr = input.ReadByte();
                temp[0] = curr;
                var rdx = input.ReaderIndex;
                temp[1] = input.GetByte(rdx);
                if (skip)
                {
                    skip = false;
                    continue;
                }
                if (BytesUtil.ByteArrayEquals(temp, DefaultValue.ESCAPE_7D))
                {
                    result.WriteByte(DefaultValue.ESCAPE_SIGN);
                    skip = true;
                    continue;
                }
                if (BytesUtil.ByteArrayEquals(temp, DefaultValue.ESCAPE_7E))
                {
                    result.WriteByte(DefaultValue.SPLIT_SIGN);
                    skip = true;
                    continue;
                }
                result.WriteByte(curr);
            }
            result.WriteByte(temp[1]);
            //input.SetReaderIndex(firstRdx);
            //ReferenceCountUtil.Release(input);
            result.AdjustCapacity(result.ReadableBytes);
            ctx.FireChannelRead(result);
        }
    }
}
