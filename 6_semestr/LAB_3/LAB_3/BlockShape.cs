using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_3
{
    public class BlockShape
    {
        public int Count;
        public int Size;
        public BlockShape(int count, int size)
        {
            Count = count;
            Size = size;
        }
        public static List<BlockShape> GetCombinations(int value, int min)
        {
            List<BlockShape> result = new List<BlockShape>();
            for (int i = min; i <= value - min; i++)
            {
                for (int j = min; j <= value + 1 - min; j++)
                {
                    if (i * j == value)
                        result.Add(new BlockShape(i, j));
                }
            }
            return result;
        }
        public override string ToString()
        {
            return $"{Count} blocks of size {Size}";
        }
    }
}
