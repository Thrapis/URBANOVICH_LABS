using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_4_
{
    public static class Additions
    {
        public static string DelLine(this string oldText)
        {
            int index = oldText.IndexOf(System.Environment.NewLine);
            return oldText.Substring(index + System.Environment.NewLine.Length);
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
                    result += " " + denseMatrix.Row(i)[j];
                }
                result += "\r\n";
            }
            return result;
        }
    }
}
