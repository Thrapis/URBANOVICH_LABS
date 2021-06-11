using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_9
{
    public static class MD5
    {
        private const int DefaultSize = 512;
        private const int DefaultWidth = 32;
        private const int DefaultHeight = 16;

        static uint[] T;

        static int[] S = { 7, 12, 17, 22,  7, 12, 17, 22,  7, 12, 17, 22,  7, 12, 17, 22,
                 5,  9, 14, 20,  5,  9, 14, 20,  5,  9, 14, 20,  5,  9, 14, 20,
                 4, 11, 16, 23,  4, 11, 16, 23,  4, 11, 16, 23,  4, 11, 16, 23,
                 6, 10, 15, 21,  6, 10, 15, 21,  6, 10, 15, 21,  6, 10, 15, 21 };

        static MD5()
        {
            T = new uint[64];
            for (int i = 0; i < 64; i++)
            {
                T[i] = (uint)(Math.Pow(2, 32) * Math.Abs(Math.Sin(i)));
            }
        }

        private static uint F(uint X, uint Y, uint Z) => (X & Y) | (~X & Z);
        private static uint G(uint X, uint Y, uint Z) => (X & Z) | (~Z & Y);
        private static uint H(uint X, uint Y, uint Z) => X ^ Y ^ Z;
        private static uint I(uint X, uint Y, uint Z) => Y ^ (~Z | X);

        private static string GetBitString(Encoding encoding, string text)
        {
            int sizeCoeff = 1;

            string binaryText = "";
            foreach (var ch in text)
            {
                string binary = Convert.ToString(encoding.GetBytes(ch.ToString())[0], 2);
                while (binary.Length < 8)
                    binary = binary.Insert(0, "0");
                binaryText += binary;
            }

            int countOfBT = binaryText.Length;

            while (DefaultSize * sizeCoeff - 64 - 1 < countOfBT)
                sizeCoeff++;

            string futureTable = "1";
            futureTable = futureTable.Insert(0, binaryText);

            for (int i = 0; i < DefaultSize * sizeCoeff - 64 - 1 - countOfBT; i++)
            {
                futureTable += "0";
            }

            string last64 = Convert.ToString(countOfBT, 2);

            while (last64.Length < 64)
                last64 = last64.Insert(0, "0");

            if (last64.Length > 64)
                last64.Remove(0, last64.Length - 64);

            futureTable += last64;

            return futureTable;
        }

        static uint CycleShiftRight(uint value, int bits)
        {
            if (bits == 0) return value;

            uint right = value >> 1;
            if (bits > 1)
            {
                right &= 0x7FFFFFFF;
                right >>= bits - 1;
            }
            return (value << (32 - bits)) | right;
        }

        static uint CycleShiftLeft(uint value, int bits)
        {
            if (bits == 0) return value;

            uint right = value >> 1;
            if ((32 - bits) > 1)
            {
                right &= 0x7FFFFFFF;
                right >>= 32 - bits - 1;
            }
            return value << bits | right;
        }

        public static string GetHash(string text)
        {
            uint A = 0x67452301;
            uint B = 0xefcdab89;
            uint C = 0x98badcfe;
            uint D = 0x10325476;
            string x512n = GetBitString(Encoding.GetEncoding(1251), text);

            uint[] M = new uint[16];

            for (int chunk = 0; chunk + 511 < x512n.Length; chunk += 512)
            {
                string x512 = x512n.Substring(chunk, 512);

                for (int i = 0; i + 31 < 512; i += 32)
                {
                    M[i / 32] = (uint)Convert.ToInt32(x512.Substring(i, 32), 2);
                }

                uint AA = A;
                uint BB = B;
                uint CC = C;
                uint DD = D;

                for (uint i = 0; i < 64; i++)
                {
                    uint f = 0;
                    //uint g = 0;

                    if (i < 16)
                    {
                        f = F(BB, CC, DD);
                        //g = i;
                    }
                    else if (i < 32)
                    {
                        f = G(BB, CC, DD);
                        //g = (5 * i + 1) % 16;
                    }
                    else if (i < 48)
                    {
                        f = H(BB, CC, DD);
                        //g = (3 * i + 5) % 16;
                    }
                    else if(i < 64)
                    {
                        f = I(BB, CC, DD);
                        //g = (7 * i) % 16;
                    }
                    uint newval = CycleShiftLeft(f + AA + M[i % 16] + T[i], S[i]);
                    AA = DD;
                    DD = CC;
                    CC = BB;
                    BB = newval;
                }
                A = A + AA;
                B = B + BB;
                C = C + CC;
                D = D + DD;
            }
            string hash = Convert.ToString(A, 16) + Convert.ToString(B, 16)
                + Convert.ToString(C, 16) + Convert.ToString(D, 16);
            return hash;
        }
    }
}
