using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeauralNetwork
{
    static class Additions
    {
        public static double[] CopyArray(this double[] arr)
        {
            double[] newArr = new double[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                newArr[i] = arr[i];
            }
            return newArr;
        }

        public static double Sigmoid(this double x)
        {
            return 1.0 / (1.0 + Math.Exp(-x));
        }

        public static double SigmoidDx(this double x)
        {
            return x * (1.0 - x);
        }

        public static double[] SigmoidDx(this double[] x1)
        {
            double[] result = new double[x1.Length];
            for (int i = 0; i < x1.Length; i++)
            {
                result[i] = x1[i] * (1.0 - x1[i]);
            }
            return result;
        }

        public static double[] ArrToArrMult(this double[] x1, double[] x2)
        {
            double[] result = new double[x1.Length];
            for (int i = 0; i < x1.Length; i++)
            {
                result[i] = x1[i] * x2[i];
            }
            return result;
        }
        public static double[] ArrToArrDiv(this double[] x1, double[] x2)
        {
            double[] result = new double[x1.Length];
            for (int i = 0; i < x1.Length; i++)
            {
                result[i] = x1[i] / x2[i];
            }
            return result;
        }
        public static double[] ArrToScalMult(this double[] x1, double x2)
        {
            double[] result = new double[x1.Length];
            for (int i = 0; i < x1.Length; i++)
            {
                result[i] = x1[i] * x2;
            }
            return result;
        }
        public static double[] ArrToScalMinus(this double[] x1, double x2)
        {
            double[] result = new double[x1.Length];
            for (int i = 0; i < x1.Length; i++)
            {
                result[i] = x1[i] - x2;
            }
            return result;
        }
        public static double[] ArrMod(this double[] x1)
        {
            double[] result = new double[x1.Length];
            for (int i = 0; i < x1.Length; i++)
            {
                result[i] = Math.Abs(x1[i]);
            }
            return result;
        }
        public static double[] ArrToScalSum(this double[] x1, double x2)
        {
            double[] result = new double[x1.Length];
            for (int i = 0; i < x1.Length; i++)
            {
                result[i] = x1[i] + x2;
            }
            return result;
        }

        public static double[] ArrToScalDif(this double[] x1, double x2)
        {
            double[] result = new double[x1.Length];
            for (int i = 0; i < x1.Length; i++)
            {
                result[i] = x1[i] - x2;
            }
            return result;
        }

        public static double[] ArrToScalSumPow(this double[] x1, double x2, double x3)
        {
            double[] result = new double[x1.Length];
            for (int i = 0; i < x1.Length; i++)
            {
                result[i] = x2 * Math.Pow(x1[i], x3);
            }
            return result;
        }
        public static double[] ArrToArrDif(this double[] x1, double[] x2)
        {
            double[] result = new double[x1.Length];
            for (int i = 0; i < x1.Length; i++)
            {
                result[i] = x1[i] - x2[i];
            }
            return result;
        }

        public static double[] ArrToArrSum(this double[] x1, double[] x2)
        {
            double[] result = new double[x1.Length];
            for (int i = 0; i < x1.Length; i++)
            {
                result[i] = x1[i] + x2[i];
            }
            return result;
        }

        public static double[] Pow(this double[] x1, double power)
        {
            double[] result = new double[x1.Length];
            for (int i = 0; i < x1.Length; i++)
            {
                result[i] = Math.Pow(x1[i], power);
            }
            return result;
        }

        public static double[] Ln(this double[] x1)
        {
            double[] result = new double[x1.Length];
            for (int i = 0; i < x1.Length; i++)
            {
                result[i] = Math.Log(x1[i]);
            }
            return result;
        }
        public static double[] Sqrt(this double[] x1)
        {
            double[] result = new double[x1.Length];
            for (int i = 0; i < x1.Length; i++)
            {
                result[i] = Math.Sqrt(x1[i]);
            }
            return result;
        }
    }
}
