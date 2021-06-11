using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeauralNetwork
{
    public static class DataTools
    {
        public static double[] Normalize(double[] data, double min, double max)
        {
            double[] result = new double[data.Length];
            double range = max - min;

            for (int i = 0; i < data.Length; i++)
            {
                result[i] = (data[i] - min) / range;
            }

            return result;
        }
    }
}
