using DotNetty.Buffers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDK.STD.Utils
{
    class CRCUtil
    {
        public static byte[] CalBytesCrc(byte[] data)
        {
            byte[] crc = new byte[2];
            int CRC = 0x0000ffff;
            int POLYNOMIAL = 0x0000a001;

            int i, j;
            for (i = 0; i < data.Length; i++)
            {
                CRC ^= ((int)data[i] & 0x000000ff);
                for (j = 0; j < 8; j++)
                {
                    if ((CRC & 0x00000001) != 0)
                    {
                        CRC >>= 1;
                        CRC ^= POLYNOMIAL;
                    }
                    else
                    {
                        CRC >>= 1;
                    }
                }
            }
            crc[0] = (byte)(CRC >> 8 & 0xff);
            crc[1] = (byte)(CRC & 0xff);
            return crc;
        }

        public static byte[] CalBufferCrc(IByteBuffer content)
        {
            byte[] bytes = new byte[content.ReadableBytes];
            content.ReadBytes(bytes);
            return CalBytesCrc(bytes);
        }
    }
}
