using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_2
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
        public static List<HeightAndWidth> GetCombinations(int value)
        {
            List<HeightAndWidth> result = new List<HeightAndWidth>();
            for (int i = 2; i < value; i++)
            {
                for (int j = 2; j < value; j++)
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
