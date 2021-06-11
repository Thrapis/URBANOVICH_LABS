using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LAB_7_REAL
{
    public class BackpackEncryptor
    {
        private BigInteger BASENUM = BigInteger.Parse("1267650600228229401496703205376");

        public BPEType Type;

        public BigInteger[] ClosedKey { get; private set; }
        public BigInteger[] OpenKey { get; private set; }
        public BigInteger Modulus { get; private set; }
        public BigInteger A { get; private set; }
        public BigInteger AR { get; private set; }

        public BackpackEncryptor(BPEType type)
        {
            Random rand = new Random();

            Type = type;
            ClosedKey = GenerateClosedKey();
            Modulus = ClosedKey.SumElements() + rand.Next(1, 99999);

            A = rand.Next(0, 100000000);
            while (Additions.EuclidsAlgorithmOfTwo(A, Modulus) != 1) 
            {
                A = rand.Next(0, 100000000);
            }

            AR = Additions.GetReversedByModulo(A, Modulus);

            OpenKey = CalculateOpenKey();
        }

        public static BigInteger[] Encrypt(BPEType type, BigInteger[] openKey, string text)
        {
            BitArray[] ba;

            if (type == BPEType.ASCII)
                ba = text.ToBinaryASCII();
            else
                ba = text.ToBinaryBase64();

            BigInteger[] result = new BigInteger[ba.Length];

            for (int i = 0; i < ba.Length; i++)
            {
                result[i] = openKey.SumElements(ba[i]);
            }

            return result;
        }

        public static string Decrypt(BPEType type, BigInteger[] closedKey, BigInteger ar, BigInteger modulus, BigInteger[] encoded)
        {
            string result = "";
            byte[] bt = new byte[encoded.Length];

            for (int i = 0; i < encoded.Length; i++)
            {
                BigInteger Si = encoded[i] * ar % modulus;
                bt[i] = PackBackpack(type, closedKey, Si);
            }

            if (type == BPEType.ASCII)
                result += Encoding.GetEncoding(1251).GetString(bt);
            else
            {
                bt = bt.ToByteBase64();
                result += Convert.ToBase64String(bt);
            }


            return result;
        }

        public BigInteger[] Encrypt(string text)
        {
            BitArray[] ba;

            if (Type == BPEType.ASCII)
                ba = text.ToBinaryASCII();
            else
                ba = text.ToBinaryBase64();

            BigInteger[] result = new BigInteger[ba.Length];

            for (int i = 0; i < ba.Length; i++)
            {
                result[i] = OpenKey.SumElements(ba[i]);
            }

            return result;
        }

        public string Decrypt(BigInteger[] encoded)
        {
            string result = "";
            byte[] bt = new byte[encoded.Length];

            for (int i = 0; i < encoded.Length; i++)
            {
                BigInteger Si = encoded[i] * AR % Modulus;
                bt[i] = PackBackpack(Type, ClosedKey, Si);
            }

            if (Type == BPEType.ASCII)
                result += Encoding.GetEncoding(1251).GetString(bt);
            else
            {
                bt = bt.ToByteBase64();
                result += Convert.ToBase64String(bt);
            }
                

            return result;
        }

        private static byte PackBackpack(BPEType type, BigInteger[] closedKey, BigInteger si)
        {
            BitArray bp = new BitArray((int)type);
            for (int i = 0; i < Math.Pow(2, (int)type); i++)
            {
                string bin = Convert.ToString(i, 2).PadLeft((int)type, '0');

                BigInteger buf = 0;
                for (int j = 0; j < bin.Length; j++)
                {
                    if (bin[j] == '1')
                        buf += closedKey[j];
                }
                if (buf == si)
                {
                    for (int j = 0; j < bin.Length; j++)
                    {
                        if (bin[j] == '0')
                            bp[j] = false;
                        else
                            bp[j] = true;
                    }
                    break;
                }
            }
            return bp.BitsToByte();
        }

        public void SetClosedKeyValue(int index, BigInteger value)
        {
            ClosedKey[index] = value;
        }

        public void RegenerateOpenKey()
        {
            OpenKey = CalculateOpenKey();
        }

        public void SetA(BigInteger value)
        {
            A = value;
        }

        public void RegenerateAR()
        {
            AR = Additions.GetReversedByModulo(A, Modulus);
        }

        public void SetModulus(BigInteger value)
        {
            Modulus = value;
        }

        private BigInteger[] GenerateClosedKey()
        {
            BigInteger[] closedKey = new BigInteger[(int)Type];

            BigInteger init = Generate100bitNumber();
            closedKey[(int)Type - 1] = init;
            for (int i = (int)Type - 2; i >= 0; i--)
            {
                closedKey[i] = closedKey[i + 1] / 2 - 1;
            }

            return closedKey;
        }

        private BigInteger[] CalculateOpenKey()
        {
            BigInteger[] openKey = new BigInteger[(int)Type];

            for (int i = 0; i < (int)Type; i++)
            {
                openKey[i] = (ClosedKey[i] * A) % Modulus;
            }

            return openKey;
        }

        private BigInteger Generate100bitNumber()
        {
            Random rand = new Random();
            BigInteger ans = BigInteger.Parse(BASENUM.ToString());
            BigInteger i = (BigInteger.Parse(BASENUM.ToString())) / 2;

            while (!i.IsOne)
            {
                ans += rand.Next(0, 100) > 50 ? i : 0;
                i /= 2;
            }

            return ans;
        }
    }
}
