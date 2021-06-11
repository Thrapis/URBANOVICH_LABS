using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_11
{
    public static class ECEncryption
    {
        public static (ECEPublicKeys, ECEPrivateKeys) GenerateECE(int l)
        {
            Random rand = new Random();
            
            int p = 0;
            int a;
            int b;
            int x;
            ECEquationMod equation;
            ECPoint[] points;
            do
            {
                p = (int)Math.Pow(2, 2 * l - 1);
                while (Math.Pow(2, 2 * l - 1) >= p || p >= Math.Pow(2, 2 * l) || p % 4 == 3)
                {
                    p++;
                    Console.WriteLine($"p = {p}");
                }
                a = rand.Next(0, p);
                b = rand.Next(0, p);
                equation = new ECEquationMod(a, b, p);

                x = 0;
                points = equation.GetPointsByX(x);
                while (points.Length == 0)
                {
                    x++;
                    if (x >= p)
                        break;
                    points = equation.GetPointsByX(x);
                    Console.WriteLine($"x = {x}");
                }
            } while (x >= p);
            
            int q = rand.Next(7, 513);
            ECPoint G = points[0];

            int d = rand.Next(1, q);
            ECPoint Q = equation.ECMult(G, d);
            while (Q.IsInfinityPoint())
            {
                d = rand.Next(1, q);
                Q = equation.ECMult(G, d);
                Console.WriteLine($"d = {d}");
                Console.WriteLine($"Q = {Q}");
            }

            return (new ECEPublicKeys(p, a, b, q, G, Q), new ECEPrivateKeys(p, a, b, q, d, G));
        }

        public static (ECEPublicKeys, ECEPrivateKeys) GenerateECE(int p, int a, int b)
        {
            Random rand = new Random();

            ECEquationMod equation = new ECEquationMod(a, b, p);

            int x = 0;
            ECPoint[] points = equation.GetPointsByX(x);
            while (points.Length == 0)
            {
                x++;
                points = equation.GetPointsByX(x);
                Console.WriteLine($"x = {x}");
            }

            int q = rand.Next(7, 513);
            ECPoint G = points[0];

            int d = rand.Next(1, q);
            ECPoint Q = equation.ECMult(G, d);
            while (Q.IsInfinityPoint())
            {
                d = rand.Next(1, q);
                Q = equation.ECMult(G, d);
                Console.WriteLine($"d = {d}");
                Console.WriteLine($"Q = {Q}");
            }

            return (new ECEPublicKeys(p, a, b, q, G, Q), new ECEPrivateKeys(p, a, b, q, d, G));
        }

        public static (ECEPublicKeys, ECEPrivateKeys) GenerateECE(int p, int a, int b, int d)
        {
            Random rand = new Random();

            ECEquationMod equation = new ECEquationMod(a, b, p);

            int x = 0;
            ECPoint[] points = equation.GetPointsByX(x);
            while (points.Length == 0)
            {
                x++;
                points = equation.GetPointsByX(x);
                Console.WriteLine($"x = {x}");
            }

            int q = rand.Next(7, 513);
            ECPoint G = points[0];

            ECPoint Q = equation.ECMult(G, d);

            return (new ECEPublicKeys(p, a, b, q, G, Q), new ECEPrivateKeys(p, a, b, q, d, G));
        }

        public static (ECEPublicKeys, ECEPrivateKeys) GenerateECE(int p, int a, int b, ECPoint G, int q, int d)
        {
            ECEquationMod equation = new ECEquationMod(a, b, p);

            ECPoint Q = equation.ECMult(G, d);

            return (new ECEPublicKeys(p, a, b, q, G, Q), new ECEPrivateKeys(p, a, b, q, d, G));
        }

        public static List<ECMessageBlock> Encryption(ECPoint[] messagePoints, ECEPublicKeys keys)
        {
            List<ECMessageBlock> blocks = new List<ECMessageBlock>();

            Random rand = new Random();
            ECEquationMod equation = new ECEquationMod(keys.a, keys.b, keys.p);

            for (int i = 0; i < messagePoints.Length; i++)
            {
                int k = rand.Next(7, 512);
                ECPoint c1 = equation.ECMult(keys.G, k);
                ECPoint c2 = equation.ECAdd(messagePoints[i], equation.ECMult(keys.Q, k));
                blocks.Add(new ECMessageBlock(c1, c2));
            }

            return blocks;
        }

        public static ECPoint[] Decryption(List<ECMessageBlock> blocks, ECEPrivateKeys keys)
        {
            ECEquationMod equation = new ECEquationMod(keys.a, keys.b, keys.p);
            ECPoint[] points = new ECPoint[blocks.Count];

            for (int i = 0; i < blocks.Count; i++)
            {
                ECPoint dc1 = equation.ECMult(blocks[i].C1, keys.d);
                ECPoint point = equation.ECSub(blocks[i].C2, dc1);

                points[i] = point;
            }

            return points;
        }
    }
}
