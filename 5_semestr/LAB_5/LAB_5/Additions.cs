using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_5
{
    public static class Additions
    {
        public static string DelLine(this string oldText)
        {
            int index = oldText.IndexOf(System.Environment.NewLine);
            return oldText.Substring(index + System.Environment.NewLine.Length);
        }
        public static Matrix<double> ToMatrix(this double[,] x)
        {
            int height = x.GetLength(0);
            int width = x.GetLength(1);
            Matrix<double> result = Matrix<double>.Build.Dense(height, width);
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    result[i, j] = x[i, j];
                }
            }
            return result;
        }
        public static Matrix<double> ToMatrix(this int[] array, int x, int y)
        {
            int height = x;
            int width = y;
            Matrix<double> result = Matrix<double>.Build.Dense(height, width);
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    result[i, j] = array[i * width + j];
                }
            }
            return result;
        }
        public static string ToStringPlus(this Matrix<double> denseMatrix)
        {
            string result = "";
            for (int i = 0; i < denseMatrix.RowCount; i++)
            {
                if (i == denseMatrix.RowCount - 1)
                {
                    for (int j = 0; j < denseMatrix.ColumnCount; j++)
                    {
                        result += " ━";
                    }
                    result += " ━\r\n";
                }
                for (int j = 0; j < denseMatrix.ColumnCount; j++)
                {
                    if (j == denseMatrix.ColumnCount - 1)
                        result += " ┃";
                    result +=  " " + denseMatrix.Row(i)[j];
                }
                result += "\r\n";
            }
            return result;
        }
    }
}
