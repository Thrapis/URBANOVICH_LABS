using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_5
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
        public override string ToString()
        {
            return $"{X}x{Y}";
        }
    }
}
