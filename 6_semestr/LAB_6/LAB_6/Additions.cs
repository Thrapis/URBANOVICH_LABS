using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_6
{
    public static class Additions
    {
        public static int EuclidsAlgorithmOfTwo(int a, int b)
        {
            int q = 0;
            int r = 0;

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

        public static int EulerFunction(int n)
        {
            int num = n;
            List<int> delimeters = new List<int>();

            int buf = int.Parse(n.ToString());
            while (buf != 1)
            {
                for (int i = 2; i <= buf; i++)
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

        public static int Bezu(int a, int b, out int x, out int y)
        {
            if (b < a)
            {
                int t = a;
                a = b;
                b = t;
            }

            if (a == 0)
            {
                x = 0;
                y = 1;
                return b;
            }

            int gcd = Bezu(b % a, a, out x, out y);

            int newY = x;
            int newX = y - (b / a) * x;

            x = newX;
            y = newY;
            return gcd;
        }

        public static int GetReversedByModulo(int a, int modulo)
        {
            int x = 0;
            int y = 0;
            Bezu(a, modulo, out x, out y);

            int reva = x;
            while (reva < 0)
                reva += modulo;

            return reva;
        }
    }
}
