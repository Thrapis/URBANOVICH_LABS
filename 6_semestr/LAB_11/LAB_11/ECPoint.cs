using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_11
{
    public struct ECPoint
    {
        public static ECPoint NaNPoint = new ECPoint(double.NaN, double.NaN);
        public static ECPoint InfinityPoint = new ECPoint(double.PositiveInfinity, double.PositiveInfinity);

        public double X;
        public double Y;

        public ECPoint(double x, double y)
        {
            X = x;
            Y = y;
        }

        public ECPoint GetReversed()
        {
            return new ECPoint(X, -Y);
        }

        public bool IsNaNPoint()
        {
            return Double.IsNaN(X) || Double.IsNaN(Y);
        }

        public bool IsInfinityPoint()
        {
            return Double.IsInfinity(X) || Double.IsInfinity(Y);
        }

        public override string ToString()
        {
            return $"Point (X = {X}; Y = {Y})";
        }

        public static ECPoint FromString(string pointString)
        {
            pointString = pointString.Replace("Point (X = ", "");
            pointString = pointString.Replace(" Y = ", "");
            pointString = pointString.Replace(")", "");
            string[] xy = pointString.Split(';');

            double x = Convert.ToDouble(xy[0]);
            double y = Convert.ToDouble(xy[1]);
            ECPoint point = new ECPoint(x, y);

            return point;
        } 

        public static bool operator ==(ECPoint obj1, ECPoint obj2)
        {
            if (obj1.X == obj2.X && obj1.Y == obj2.Y)
                return true;
            return false;
        }

        public static bool operator !=(ECPoint obj1, ECPoint obj2)
        {
            return !(obj1 == obj2);
        }
    }
}
