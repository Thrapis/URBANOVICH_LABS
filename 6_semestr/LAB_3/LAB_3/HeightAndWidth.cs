using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_3
{
    public class HeightAndWidth
    {
        public int X;
        public int Y;
        public HeightAndWidth(int x, int y)
        {
            X = x;
            Y = y;
        }
        public static List<HeightAndWidth> GetCombinations(int value, int min)
        {
            List<HeightAndWidth> result = new List<HeightAndWidth>();
            for (int i = min; i <= value - min; i++)
            {
                for (int j = min; j <= value - min; j++)
                {
                    if (i * j == value)
                        result.Add(new HeightAndWidth(i, j));
                }
            }
            return result;
        }
        public override string ToString()
        {
            return $"{X}x{Y}";
        }
    }
}
