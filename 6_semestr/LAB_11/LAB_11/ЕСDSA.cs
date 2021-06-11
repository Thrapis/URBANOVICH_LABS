using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LAB_11
{
    public struct ECDSABlock
    {
        public BigInteger R { get; private set; }
        public BigInteger S { get; private set; }

        public ECDSABlock(BigInteger r, BigInteger s)
        {
            R = r;
            S = s;
        }

        public override string ToString()
        {
            return $"[{R};{S}]";
        }

        public static ECDSABlock FromString(string blockString)
        {
            blockString = blockString.Replace("[", "").Replace("]", "");
            string[] rs = blockString.Split(';');

            BigInteger r = BigInteger.Parse(rs[0]);
            BigInteger s = BigInteger.Parse(rs[1]);

            return new ECDSABlock(r, s);
        }
    }


    public static class ЕСDSA
    {
        public static ECDSABlock GenerateEDS(string text, ECEPrivateKeys keys)
        {
            Random rand = new Random();
            BigInteger r = 0;
            BigInteger s = 0;
            ECEquationMod equation = new ECEquationMod(keys.a, keys.b, keys.p);

            while (s == 0)
            {
                r = 0;
                int k = 0;

                while (r == 0)
                {
                    k = rand.Next(1, keys.q);
                    ECPoint kG = equation.ECMult(keys.G, k);
                    r = (int)kG.X % keys.q;
                }

                BigInteger t = GetReversedByModulo(k, keys.q);

                BigInteger hash = BigInteger.Abs(BigInteger.Parse(MD5.GetHash(text), System.Globalization.NumberStyles.AllowHexSpecifier));
                s = t * (hash + keys.d * r) % keys.q;
            };

            return new ECDSABlock(r, s);
        }

        public static bool VerifyEDS(string text, ECDSABlock eds, ECEPublicKeys keys)
        {
            if (1 < eds.R && eds.S < keys.q)
            {
                ECEquationMod equation = new ECEquationMod(keys.a, keys.b, keys.p);

                BigInteger hash = BigInteger.Abs(BigInteger.Parse(MD5.GetHash(text), System.Globalization.NumberStyles.AllowHexSpecifier));
                BigInteger w = GetReversedByModulo(eds.S, keys.q);
                BigInteger u1 = w * hash % keys.q;
                BigInteger u2 = w * eds.R % keys.q;
                ECPoint Gu1 = equation.ECMult(keys.G, u1);
                ECPoint Qu2 = equation.ECMult(keys.Q, u2);
                ECPoint sum = equation.ECAdd(Gu1, Qu2);
                BigInteger v = (int)sum.X % keys.q;

                return v == eds.R;
            }
            else
                return false;
        }

        private static BigInteger Bezu(BigInteger a, BigInteger b, out BigInteger x, out BigInteger y)
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

        private static BigInteger GetReversedByModulo(BigInteger a, BigInteger modulo)
        {
            BigInteger x = 0;
            BigInteger y = 0;
            while (a < 0)
                a += modulo;
            a %= modulo;
            Bezu(a, modulo, out x, out y);

            BigInteger reva = x;
            while (reva < 0)
                reva += modulo;

            return reva;
        }
    }
}
