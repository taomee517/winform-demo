using DotNetty.Buffers;
using winform_demo.Utils;

namespace SDK.MEASURE.Utils
{
    public class ValidateUtil
    {
        public static bool validate(byte[] content)
        {
            var buffer = Unpooled.WrappedBuffer(content);
            var waitValidateData = new byte[buffer.ReadableBytes -2];
            buffer.ReadBytes(waitValidateData);
            
            var crc = new byte[2];
            buffer.ReadBytes(crc);
            
            var calCrc = CRCUtil.CalCrc(waitValidateData);
            return BytesUtil.ByteArrayEquals(calCrc, crc);
        }

        public static bool validate(IByteBuffer buffer)
        {
            int rdx = buffer.ReaderIndex;
            int validateContentLen = buffer.ReadableBytes - 2;
            var waitValidateData = new byte[validateContentLen];
            buffer.GetBytes(rdx, waitValidateData);

            var crc = new byte[2];
            buffer.GetBytes(rdx + validateContentLen, crc);

            var calCrc = CRCUtil.CalCrc(waitValidateData);
            return BytesUtil.ByteArrayEquals(calCrc, crc);
        }
    }
}