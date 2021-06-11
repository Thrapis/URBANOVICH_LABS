using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;
using LAB_8;
using System.Security.Cryptography;

namespace LAB_10
{
    public class Schnorr
    {
        public BigInteger P;
        public BigInteger G;
        public BigInteger Q;
        public BigInteger X;
        public BigInteger Y;

        public Schnorr()
        {
            Console.Clear();
            Y = 1;

            while (Y == 1)
            {
                P = GetP();
                Q = GetQ(P);
                G = GetG(P, Q);

                X = Q - new Random().Next(2, (int)Q - 1);
                Y = Additions.GetReversedByModulo(BigInteger.ModPow(G, X, P), P);
            }

            Console.WriteLine($"{P - 1} / {Q} = {P / Q}");
            Console.WriteLine($"{G} != 1");
            Console.WriteLine($"{G}^{Q} = {BigInteger.ModPow(G, Q, P)} mod {P}");
            Console.WriteLine($"{X} < {Q}");
            Console.WriteLine($"{Y} = ({G}^{X})^-1 mod {P}");
            
        }

        public static ElGamalBlock GetEDS(string text, BigInteger p, BigInteger q, BigInteger g, BigInteger x)
        {
            Random rand = new Random();
            int k = rand.Next(2, (int)q);
            Console.WriteLine($"K = {k}");
            BigInteger a = BigInteger.ModPow(g, k, p);
            string atext = text + a.ToString();
            Console.WriteLine($"A = {a}");
            BigInteger hash = BigInteger.Abs(BigInteger.Parse(MD5.GetHash(atext), System.Globalization.NumberStyles.AllowHexSpecifier));
            Console.WriteLine($"Hash encode = {hash}");
            BigInteger b = (k + x * hash) % q;
            Console.WriteLine($"b = {b}");
            return new ElGamalBlock(hash, b);
        }


        public static bool VerifyEDS(string text, ElGamalBlock eds, BigInteger p, BigInteger g, BigInteger y)
        {
            Console.WriteLine($"hash = {eds.A} ; b = {eds.B}");
            BigInteger X = BigInteger.ModPow(g, eds.B, p) * BigInteger.ModPow(y, eds.A, p) % p;
            Console.WriteLine($"x = {X}");
            string xtext = text + X.ToString();
            BigInteger hash = BigInteger.Abs(BigInteger.Parse(MD5.GetHash(xtext), System.Globalization.NumberStyles.AllowHexSpecifier));
            Console.WriteLine($"Hash decode = {hash}");
            return eds.A == hash;
        }

        private static BigInteger GetP()
        {
            Random rand = new Random();
            BigInteger p = rand.Next(1300, 100000);
            while (Additions.EulerFunction(p) != p - 1)
                p = rand.Next(1300, 100000);
            return p;
        }

        private static BigInteger GetQ(BigInteger p)
        {
            Random rand = new Random();
            BigInteger q = rand.Next(2, (int)p-2);
            while ((p - 1) % q != 0 && Additions.EulerFunction(q) != q - 1)
                q = rand.Next(2, (int)p - 2);

            return q;
        }

        private static BigInteger GetG(BigInteger p, BigInteger q)
        {
            Random rand = new Random();
            BigInteger g = 2;

            while (BigInteger.ModPow(g, q, p) != 1)
                g++;

            return g;
        }
    }
}
