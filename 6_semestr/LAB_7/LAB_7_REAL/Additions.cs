using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LAB_7_REAL
{
    public static class Additions
    {
        public static List<int> Erathosphen(int under_value)
        {
            List<int> list = new List<int>();
            List<int> deletetions = new List<int>();
            for (int i = 2; i < under_value; i++)
            {
                list.Add(i);
            }

            for (int i = 2; i < under_value; i++)
            {
                if (list.Contains(i))
                {
                    deletetions.Clear();
                    foreach (int val in list)
                    {
                        if (val % i == 0 && i < val)
                        {
                            deletetions.Add(val);
                        }
                    }
                    foreach (var val in deletetions)
                    {
                        list.Remove(val);
                    }
                }
            }

            return list;
        }

        public static BigInteger EuclidsAlgorithmOfTwo(BigInteger a, BigInteger b)
        {
            BigInteger q = 0;
            BigInteger r = 0;

            do
            {
                if (a > b)
                {
                    q = a / b;
                    r = a - b * q;
                    if (r == 0)
                        return b;
                    a = r;
                }
                else
                {
                    q = b / a;
                    r = b - a * q;
                    if (r == 0)
                        return a;
                    b = r;
                }
            } while (r != 0);
            return a;
        }

        public static BigInteger EulerFunction(BigInteger n)
        {
            BigInteger num = n;
            List<BigInteger> delimeters = new List<BigInteger>();

            BigInteger buf = BigInteger.Parse(n.ToString());
            while (buf != 1)
            {
                for (BigInteger i = 2; i <= buf; i++)
                {
                    if (buf % i == 0)
                    {
                        buf /= i;
                        if (!delimeters.Contains(i))
                            delimeters.Add(i);
                        break;
                    }
                }
            }

            for (int i = 0; i < delimeters.Count; i++)
            {
                num /= delimeters[i];
                num *= (delimeters[i] - 1);
            }

            return num;
        }

        public static BigInteger Bezu(BigInteger a, BigInteger b, out BigInteger x, out BigInteger y)
        {
            if (b < a)
            {
                BigInteger t = a;
                a = b;
                b = t;
            }

            if (a == 0)
            {
                x = 0;
                y = 1;
                return b;
            }

            BigInteger gcd = Bezu(b % a, a, out x, out y);

            BigInteger newY = x;
            BigInteger newX = y - (b / a) * x;

            x = newX;
            y = newY;
            return gcd;
        }

        public static BigInteger GetReversedByModulo(BigInteger a, BigInteger modulo)
        {
            BigInteger x = 0;
            BigInteger y = 0;
            Bezu(a, modulo, out x, out y);

            BigInteger reva = x;
            while (reva < 0)
                reva += modulo;

            return reva;
        } 

        public static BigInteger SumElements(this BigInteger[] integers)
        {
            BigInteger bi = 0;
            for (int i = 0; i < integers.Length; i++)
            {
                bi += integers[i];
            }
            return bi;
        }

        public static BigInteger SumElements(this BigInteger[] integers, BitArray mask)
        {
            BigInteger bi = 0;
            for (int i = 0; i < integers.Length; i++)
            {
                if (mask[i])
                    bi += integers[i];
            }
            return bi;
        }

        public static string ToStringArray(this BigInteger[] bigIntegers)
        {
            string result = "";
            for (int i = 0; i < bigIntegers.Length; i++)
            {
                result += $"[{bigIntegers[i]}]\r\n";
            }
            return result;
        }

        public static byte BitsToByte(this BitArray bitsArray)
        {
            byte[] ret = new byte[1];

            bool[] boolArray = new bool[8];
            for (int i = 0, j = bitsArray.Length - 1; j >= 0; i++, j--)
            {
                boolArray[i] = bitsArray[j];
            }
            BitArray bits = new BitArray(boolArray);

            bits.CopyTo(ret, 0);

            return ret[0];
        }

        public static BitArray[] ToBinaryASCII(this string text)
        {
            BitArray[] bitArrays = new BitArray[text.Length];
            for (int bai = 0; bai < text.Length; bai++)
            {
                string bin = Convert.ToString(Encoding.GetEncoding(1251)
                    .GetBytes(text[bai].ToString())[0], 2)
                    .PadLeft(8, '0');

                BitArray bitArray = new BitArray(8);
                for (int i = 7, j = 7; i >= 0; i--, j--)
                {
                    bitArray[j] = bin[i] == '0' ? false : true;
                }
                bitArrays[bai] = bitArray; 
            }
            return bitArrays;
        }

        public static byte Reverse(byte inByte)
        {
            byte result = 0x00;

            for (byte mask = 0x80; Convert.ToInt32(mask) > 0; mask >>= 1)
            {
                // shift right current result
                result = (byte)(result >> 1);

                // tempbyte = 1 if there is a 1 in the current position
                var tempbyte = (byte)(inByte & mask);
                if (tempbyte != 0x00)
                {
                    // Insert a 1 in the left
                    result = (byte)(result | 0x80);
                }
            }

            return (result);
        }

        public static BitArray[] ToBinaryBase64(this string text)
        {
            byte[] base64bytes = Convert.FromBase64String(text);
            for (int i = 0; i < base64bytes.Length; i++)
            {
                base64bytes[i] = Reverse(base64bytes[i]);
            }

            int bytecount = base64bytes.Length * 8;
            while (bytecount % 6 != 0)
                bytecount += 2;
            bytecount /= 6;

            BitArray[] bitArrays = new BitArray[bytecount];

            string binDigits = "";
            for (int i = 0; i < base64bytes.Length; i++)
            {
                string num = Convert.ToString(base64bytes[i], 2);
                string arr = "";
                while (arr.Length + num.Length < 8)
                    arr += '0';
                arr += num;

                binDigits += arr;
            }

            while (binDigits.Length % 6 != 0)
                binDigits += "00";

            int counter = 0;
            for (int i = 0; i + 5 < binDigits.Length; i += 6)
            {
                BitArray bitArray = new BitArray(6);
                for (int j = 5; j >= 0; j--)
                {
                    bitArray[j] = binDigits[i + j] == '0' ? false : true;
                }
                bitArrays[counter] = bitArray;
                counter++;
            }
            return bitArrays;
        }

        public static byte[] ToByteBase64(this byte[] sixpletsInOcto)
        {
            int bytecount = sixpletsInOcto.Length * 6;
            while (bytecount % 8 != 0)
                bytecount -= 2;
            bytecount /= 8;
            byte[] result = new byte[bytecount];
            string binDigits = "";
            for (int i = 0; i < sixpletsInOcto.Length; i++)
            {
                string num = Convert.ToString(sixpletsInOcto[i], 2);
                string arr = "";
                while (arr.Length + num.Length < 6)
                    arr += '0';
                arr += num;
                binDigits += arr;
            }

            binDigits = binDigits.Substring(0, bytecount * 8);

            for (int i = 0; i + 7 < binDigits.Length; i += 8)
            {
                BitArray bitArray = new BitArray(8);
                for (int j = 0; j < 8; j++)
                {
                    if (binDigits[i + j] == '0')
                        bitArray[j] = false;
                    else
                        bitArray[j] = true;
                }

                byte buf = BitsToByte(bitArray);
                result[i / 8] = Reverse(buf);
            }

            return result;
        }
    }
}
