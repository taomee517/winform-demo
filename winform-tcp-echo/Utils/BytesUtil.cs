﻿using System;
using System.Text;

namespace winform_demo.Utils
{
    class BytesUtil
    {
        public static byte[] String2Bytes(string msg)
        {
            return System.Text.Encoding.Default.GetBytes(msg);
        }

        public static string Bytes2String(byte[] bytes)
        {
            return System.Text.Encoding.Default.GetString(bytes);
        }

        /*16进制字符串转为字节数组*/
        public static byte[] Hex2Bytes(string hex)
        {
            hex = hex.Replace(" ", "");
            var result = new byte[hex.Length / 2];
            var sb = new StringBuilder("0x");
            for (var i = 0; i < hex.Length; i++)
            {
                var c = hex[i];
                sb.Append(c);
                if (i % 2 == 0) continue;
                var singleHex = sb.ToString();
                result[i / 2] = Convert.ToByte(singleHex, 16);
                sb = new StringBuilder("0x");
            }
            return result;
        }

        public static string BytesToHex(byte[] bytes)
        {
            if (bytes == null)
            {
                return null;
            }
            var sb = new StringBuilder();
            var lastIndex = bytes.Length;
            for (var i = 0; i < lastIndex; i++)
            {
                var b = bytes[i];
                if (b < 16)
                {
                    sb.Append(0);
                }
                sb.Append(Convert.ToString(b, 16));
            }
            return sb.ToString();
        }

        public static string BytesToHexWithBlank(byte[] bytes)
        {
            if (bytes == null)
            {
                return null;
            }
            var hex = BytesToHex(bytes);
            return HexJoinSeparator(hex, " ");
        }

        public static string BytesToHexWithSeparator(byte[] bytes, string sep)
        {
            if (bytes == null)
            {
                return null;
            }
            var hex = BytesToHex(bytes);
            return HexJoinSeparator(hex, sep);
        }

        public static string HexJoinSeparator(string hex, string sep)
        {
            hex = hex.Replace(" ", "");
            var sb = new StringBuilder();
            for (var i = 0; i < hex.Length; i++)
            {
                var c = hex[i];
                sb.Append(c);
                if (i < hex.Length - 1 && i % 2 == 1)
                {
                    sb.Append(sep);
                }
            }

            return sb.ToString();
        }

        public static string HexInsertSpace(string hex)
        {
            return HexJoinSeparator(hex, " ");
        }

        public static string ToShowString(byte[] bytes)
        {
            var lastIndex = bytes.Length - 1;
            var sb = new StringBuilder();
            sb.Append("[");
            for (var i = 0; i < lastIndex; i++)
            {
                sb.Append(bytes[i]);
                sb.Append(",");
            }
            sb.Append(bytes[lastIndex]);
            sb.Append("]");
            return sb.ToString();
        }

        /// <summary>
        /// int型转字节数组
        /// </summary>
        /// <param name="value">int</param>
        /// <returns>字节数组</returns>
        public static byte[] Int16ToBytes(Int16 value)
        {
            return new byte[2] { (byte)(value >> 8 & 0xff), (byte)(value & 0xff) };
        }

        /// <summary>
        /// int型转字节数组
        /// </summary>
        /// <param name="value">int32</param>
        /// <returns>字节数组</returns>
        public static byte[] Int32ToBytes(Int32 value)
        {
            return new byte[4] { (byte)(value >> 24 & 0xff), (byte)(value >> 16 & 0xff), (byte)(value >> 8 & 0xff), (byte)(value & 0xff) };
        }

        /// <summary>
        /// 字节数组转int
        /// </summary>
        /// <param name="bytes">字节数组</param>
        /// <returns>int16</returns>
        public static Int16 Bytes2Int16(byte[] bytes)
        {
            var checkSum = 0;
            for (var i = 0; i < bytes.Length; i++)
            {
                var b = bytes[i];
                checkSum = b << (bytes.Length - 1 - i) | checkSum;
            }

            return (Int16)(checkSum & 0xffff);
        }

        /// <summary>
        /// 判断两个数组是否相等
        /// </summary>
        /// <param name="b1"></param>
        /// <param name="b2"></param>
        /// <returns></returns>
        public static bool ByteArrayEquals(byte[] b1, byte[] b2)
        {
            if (b1.Length != b2.Length) return false;
            for (int i = 0; i < b1.Length; i++)
                if (b1[i] != b2[i])
                    return false;
            return true;
        }
    }
}
