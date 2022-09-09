using DotNetty.Buffers;
using DotNetty.Codecs;
using DotNetty.Transport.Channels;
using SDK.MEASURE.Utils;
using SDK.STD.Constant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using winform_demo.Utils;

namespace SDK.STD.Protocol
{
    class MeasureValidateHandler : SimpleChannelInboundHandler<IByteBuffer>
    {
        protected override void ChannelRead0(IChannelHandlerContext ctx, IByteBuffer input)
        {
            if (!ValidateUtil.validate(input)) return;
            ctx.FireChannelRead(input);
        }
    }
}
