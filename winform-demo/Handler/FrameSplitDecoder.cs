using DotNetty.Buffers;
using DotNetty.Codecs;
using DotNetty.Transport.Channels;
using System;
using System.Collections.Generic;
using winform_demo.SDK;

namespace winform_demo.Handler
{
    class FrameSplitDecoder : ByteToMessageDecoder
    {

        protected override void Decode(IChannelHandlerContext context, IByteBuffer input, List<object> output)
        {
            var msg = new byte[input.ReadableBytes];
            input.ReadBytes(msg);
            output.Add(msg);
        }
        
        
        public override void ExceptionCaught(IChannelHandlerContext context, Exception exception)
        {
            Console.WriteLine("Exception: " + exception);
            context.CloseAsync();
        }
    }
}
