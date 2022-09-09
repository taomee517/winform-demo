using DotNetty.Buffers;
using DotNetty.Codecs;
using DotNetty.Transport.Channels;
using SDK.MEASURE.Constant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using winform_demo.Utils;

namespace SDK.MEASURE.Protocol
{
    public class MeasureFrameSplitHandler : ByteToMessageDecoder
    {

        protected override void Decode(IChannelHandlerContext context, IByteBuffer input, List<object> output)
        {
            var len = input.ReadableBytes;
            var rdx = input.ReaderIndex;
            int readableSize = input.ReadableBytes;

            byte[] raw = new byte[len];
            input.GetBytes(rdx, raw);

            if (readableSize == 0)
            {
                return;
            }
            int startIndex = findStartIndex(input);
            
            //至少得有13个字节
            if (readableSize < MeasureDefault.MIN_LENGTH)
            {
                return;
            }

            //没找到起始符，直接弃包
            if (startIndex == -1)
            {
                input.Clear();
                return ;
            }
            input.SetReaderIndex(startIndex);
            int length = input.GetShort(2);

            //真正的包长度 = 帧头（2) + 长度(2) + 【长度值 硬件类型(1) + MAC地址(6) + 业务数据(n)】 + CRC校验(2)
            int frameLength = length + 6;
            if (readableSize < frameLength)
            {
                return ;
            }

            IByteBuffer buffer = Unpooled.Buffer(frameLength);
            input.ReadBytes(buffer);
            output.Add(buffer);
        }


        private int findStartIndex(IByteBuffer byteBuf)
        {
            byte[] starter = new byte[2];
            int readableSize = byteBuf.ReadableBytes;
            for (int i = byteBuf.ReaderIndex; i < readableSize - 1; i++)
            {
                starter[0] = byteBuf.GetByte(i);
                starter[1] = byteBuf.GetByte(i + 1);
                if (BytesUtil.ByteArrayEquals(starter, MeasureDefault.START_SIGN))
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
