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
    class StdFrameSplitHandler: ByteToMessageDecoder
    {

        protected override void Decode(IChannelHandlerContext context, IByteBuffer input, List<object> output)
        {
            var len = input.ReadableBytes;
            var rdx = input.ReaderIndex;
            if (len < DefaultValue.MIN_LENGTH)
            {
                return;
            }

            //var spliterByteProcessor = new ByteProcessor(b => b == DefaultValue.SPLIT_SIGN ? true : false);
            //int startSignIndex = input.ForEachByte(spliterByteProcessor);
            int startSignIndex = findIndex(input, DefaultValue.SPLIT_SIGN);
            if (startSignIndex == -1)
            {
                input.Clear();
                return;
            }
            //将readerIndex置为起始符下标+1
            //因为起始符结束符是一样的，如果不往后移一位，下次到的还是起始下标
            input.SetReaderIndex(startSignIndex + 1);

            //找到第一个报文结束符的下标
            int endSignIndex = findIndex(input, DefaultValue.SPLIT_SIGN);
            if (endSignIndex == -1 || endSignIndex < startSignIndex)
            {
                input.SetReaderIndex(startSignIndex);
                return ;
            }

            //计算报文的总长度
            //此处不能去操作writerIndex,否则只能截取到第一条完整报文
            int length = endSignIndex + 1 - startSignIndex;

            //如果长度还小于最小长度，就丢掉这条消息
            if (length < DefaultValue.MIN_LENGTH)
            {
                byte[] errMsg = new byte[length];
                for (int i = startSignIndex; i < (endSignIndex + 1); i++)
                {
                    int errIndex = i - startSignIndex;
                    errMsg[errIndex] = input.GetByte(i);
                }

                var hexMsg = BytesUtil.BytesToHexWithBlank(errMsg);
                Console.WriteLine("异常消息： packet = " + hexMsg);
                input.SetReaderIndex(endSignIndex);
                return;
            }

            //将报文内容写入符串，并返回
            byte[] data = new byte[length];
            input.SetReaderIndex(startSignIndex);
            input.ReadBytes(data);
            output.Add(Unpooled.WrappedBuffer(data));
        }


        private int findIndex(IByteBuffer input, byte sign)
        {
            var len = input.ReadableBytes;
            var rdx = input.ReaderIndex;
            var wtx = input.WriterIndex;
            for (int i = rdx; i < wtx; i++)
            {
                byte b = input.GetByte(i);
                if (b == sign)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
