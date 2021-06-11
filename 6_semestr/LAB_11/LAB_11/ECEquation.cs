using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_11
{
    public struct ECEquation
    {
        public double A { get; private set; }
        public double B { get; private set; }

        public ECEquation(double a, double b)
        {
            if (4 * Math.Pow(a, 3) + 27 * Math.Pow(b, 2) != 0)
            {
                A = a;
                B = b;
            }
            else
                throw new Exception("Should be: 4a^3 + 27b^2 ≠ 0");
        }

        public ECPoint ECAdd(ECPoint point_1, ECPoint point_2)
        {
            ECPoint point_3 = new ECPoint();
            double lambda = 0;
            if (point_1 == point_2)
                lambda = (3 * Math.Pow(point_1.X, 2) + A) / (2 * point_1.Y);
            else
                lambda = (point_2.Y - point_1.Y) / (point_2.X - point_1.X);
            point_3.X = Math.Pow(lambda, 2) - point_1.X - point_2.X;
            point_3.Y = lambda * (point_1.X - point_3.X) - point_1.Y;
            return point_3;
        }

        public ECPoint ECMult(ECPoint point, int n)
        {
            ECPoint result = new ECPoint(double.NaN, double.NaN);
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
            return result;
        }

        public ECPoint[] GetPointsToDraw(double minx, double maxx, double step)
        {
            List<ECPoint> points = new List<ECPoint>();

            for (double x = minx; x < maxx; x += step)
            {
                double y = Math.Sqrt(Math.Pow(x, 3) + A * x + B);
                points.Add(new ECPoint(x, y));
                points.Add(new ECPoint(x, -y));
            }
            
            
            return points.ToArray();
        }
    }
}
