using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LAB_11
{
    public struct ECEquationMod
    {
        public double A { get; private set; }
        public double B { get; private set; }
        public double Mod { get; private set; }

        public ECEquationMod(double a, double b, double mod)
        {
            if (4 * Math.Pow(a, 3) + 27 * Math.Pow(b, 2) != 0)
            {
                A = a;
                B = b;
                Mod = mod;
            }
            else
                throw new Exception($"Should be: 4a^3 + 27b^2 ≠ 0 mod {mod}");
        }

        public ECPoint ECAdd(ECPoint point_1, ECPoint point_2)
        {
            if (point_1.IsInfinityPoint() && point_2.IsInfinityPoint())
                return ECPoint.InfinityPoint;
            else if (point_1.IsInfinityPoint() && !point_2.IsInfinityPoint())
            {
                while (point_2.Y < 0)
                    point_2.Y += Mod;
                return EquationFilter(point_2);
            }
            else if (!point_1.IsInfinityPoint() && point_2.IsInfinityPoint())
            {
                while (point_1.Y < 0)
                    point_1.Y += Mod;
                return EquationFilter(point_1);
            }   

            ECPoint point_3 = new ECPoint();
            double lambda = 0;
            if (point_1 == point_2)
            {
                double div = (double)GetReversedByModulo((BigInteger)(2 * point_1.Y), (BigInteger)Mod);
                lambda = (3 * Math.Pow(point_1.X, 2) + A) * div % Mod;
            } 
            else
            {
                double y_diff = (point_2.Y - point_1.Y);
                while (y_diff < 0)
                    y_diff += Mod;
                double x_diff = (double)GetReversedByModulo((BigInteger)(point_2.X - point_1.X), (BigInteger)Mod);
                lambda = y_diff * x_diff % Mod;
            }
            point_3.X = (Math.Pow(lambda, 2) - point_1.X - point_2.X) % Mod;
            while (point_3.X < 0)
                point_3.X += Mod;
            point_3.Y = (lambda * (point_1.X - point_3.X) - point_1.Y) % Mod;
            while (point_3.Y < 0)
                point_3.Y += Mod;
            return EquationFilter(point_3);
        }

        public ECPoint ECSub(ECPoint point_1, ECPoint point_2)
        {
            return ECAdd(point_1, point_2.GetReversed());
        }

        public ECPoint ECMult(ECPoint point, int n)
        {
            ECPoint result = ECPoint.NaNPoint;
            string nstr = new string(Convert.ToString(n, 2).Reverse().ToArray());
            ECPoint[] npoints = new ECPoint[nstr.Length];

            for (int i = 0; i < nstr.Length; i++)
            {
                ECPoint buf = point;
                if (i != 0)
                    buf = ECAdd(npoints[i - 1], npoints[i - 1]);
                npoints[i] = buf;
            }

            for (int i = 0; i < nstr.Length; i++)
            {
                if (nstr[i] == '1')
                {
                    if (result.IsNaNPoint())
                        result = npoints[i];
                    else
                        result = ECAdd(result, npoints[i]);
                }
            }
            return EquationFilter(result);
        }

        public ECPoint ECMult(ECPoint point, BigInteger n)
        {
            ECPoint result = ECPoint.NaNPoint;
            string nstr = new string(ToBinaryString(n).TrimStart('0').Reverse().ToArray());
            ECPoint[] npoints = new ECPoint[nstr.Length];

            for (int i = 0; i < nstr.Length; i++)
            {
                ECPoint buf = point;
                if (i != 0)
                    buf = ECAdd(npoints[i - 1], npoints[i - 1]);
                npoints[i] = buf;
            }

            for (int i = 0; i < nstr.Length; i++)
            {
                if (nstr[i] == '1')
                {
                    if (result.IsNaNPoint())
                        result = npoints[i];
                    else
                        result = ECAdd(result, npoints[i]);
                }
            }
            return EquationFilter(result);
        }

        public int GetPeriod()
        {
            return GetAllPoints().Count();
        }

        public ECPoint[] GetAllPoints()
        {
            List<ECPoint> points = new List<ECPoint>();

            for (int x = 0; x < Mod; x++)
            {
                double y2 = (Math.Pow(x, 3) + A * x + B) % Mod;
                while (y2 < 0)
                    y2 += Mod;

                for (int i = 0; i < Mod; i++)
                {
                    double buf_y2 = Math.Pow(i, 2) % Mod;
                    if (buf_y2 == y2)
                        points.Add(new ECPoint(x, i));
                }
            }
            points.Add(new ECPoint(double.PositiveInfinity, double.PositiveInfinity));

            return points.ToArray();
        }

        public ECPoint[] GetPointsByX(int x)
        {
            List<ECPoint> points = new List<ECPoint>();

            double y2 = (Math.Pow(x, 3) + A * x + B) % Mod;
            while (y2 < 0)
                y2 += Mod;

            for (int i = 0; i < Mod; i++)
            {
                double buf_y2 = Math.Pow(i, 2) % Mod;
                if (buf_y2 == y2)
                    points.Add(new ECPoint(x, i));
            }

            return points.ToArray();
        }

        private ECPoint EquationFilter(ECPoint point)
        {
            ECPoint[] points = GetPointsByX((int)point.X);
            IEnumerable<ECPoint> filtered = points.Where(t => t.Y == point.Y);
            if (filtered.Count() > 0)
                return point;
            else
                return ECPoint.InfinityPoint;
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

        private static string ToBinaryString(BigInteger bigint)
        {
            var bytes = bigint.ToByteArray();
            var index = bytes.Length - 1;
            var base2 = new StringBuilder(bytes.Length * 8);
            var binary = Convert.ToString(bytes[index], 2);
            if (binary[0] != '0' && bigint.Sign == 1) base2.Append('0');
            base2.Append(binary);
            for (index--; index >= 0; index--)
                base2.Append(Convert.ToString(bytes[index], 2).PadLeft(8, '0'));
            return base2.ToString();
        }
    }
}
