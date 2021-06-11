using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_5
{
    [Flags]
    public enum AddParities
    {
        Null,
        DiagonalFromTopLeft,
        DiagonalFromBottomLeft
    }
    public static class BinaryAdditions
    {
        public static int[] GetBinaries(this string text)
        {
            int size = text.Length;
            int[] result = new int[size];
            for (int i = 0; i < size; i++)
            {
                result[i] = int.Parse(text[i].ToString());
                if (result[i] != 0 && result[i] != 1)
                    throw new Exception("Only 1 and 0 symbols can be entered!");
            }
            return result;
        }
        public static List<HeightAndWidth> GetCombinations(int value)
        {
            List<HeightAndWidth> result = new List<HeightAndWidth>();
            for (int i = 1; i < value + 1; i++)
            {
                for (int j = 1; j < value + 1; j++)
                {
                    if (i * j == value)
                        result.Add(new HeightAndWidth(i, j));
                }
            }
            return result;
        }
        public static Matrix<double> GetMatrixWithParities(this Matrix<double> matrix)
        {
            Matrix<double> result = Matrix<double>.Build.Dense(matrix.RowCount + 1, matrix.ColumnCount + 1);
            for (int i = 0; i < matrix.RowCount; i++)
            {
                for (int j = 0; j < matrix.ColumnCount; j++)
                {
                    result[i, j] = matrix[i, j];
                }
                result[i, matrix.ColumnCount] = (int)matrix.Row(i).Sum() % 2;
            }
            for (int j = 0; j < matrix.ColumnCount; j++)
            {
                result[matrix.RowCount, j] = (int)matrix.Column(j).Sum() % 2;
            }
            double sum = 0;
            for (int i = 0; i < result.RowCount; i++)
            {
                for (int j = 0; j < result.ColumnCount; j++)
                {
                    if (i != result.RowCount - 1 && j != result.ColumnCount - 1)
                        sum += result[i, j];
                }
            }
            result[result.RowCount - 1, result.ColumnCount - 1] = (int)sum % 2;
            return result;
        }
        public static MatrixWithParities GetMatrixWithParities(this Matrix<double> matrix, AddParities addParities)
        {
            Matrix<double> bufmatrix = Matrix<double>.Build.Dense(matrix.RowCount + 1, matrix.ColumnCount + 1);
            for (int i = 0; i < matrix.RowCount; i++)
            {
                for (int j = 0; j < matrix.ColumnCount; j++)
                {
                    bufmatrix[i, j] = matrix[i, j];
                }
                bufmatrix[i, matrix.ColumnCount] = (int)matrix.Row(i).Sum() % 2;
            }
            for (int j = 0; j < matrix.ColumnCount; j++)
            {
                bufmatrix[matrix.RowCount, j] = (int)matrix.Column(j).Sum() % 2;
            }
            double sum = 0;
            for (int i = 0; i < bufmatrix.RowCount; i++)
            {
                for (int j = 0; j < bufmatrix.ColumnCount; j++)
                {
                    if (i != bufmatrix.RowCount - 1 && j != bufmatrix.ColumnCount - 1)
                        sum += bufmatrix[i, j];
                }
            }
            bufmatrix[bufmatrix.RowCount - 1, bufmatrix.ColumnCount - 1] = (int)sum % 2;

            int[] dtl = null;
            int[] dbl = null;
            if (addParities.HasFlag(AddParities.DiagonalFromTopLeft))
                dtl = matrix.GetDiagonalTopLeft();
            if (addParities.HasFlag(AddParities.DiagonalFromBottomLeft))
                dbl = matrix.GetDiagonalBottomLeft();

            MatrixWithParities result = new MatrixWithParities(bufmatrix, dtl, dbl);
            return result;
        }
        public static int[] GetInfoBlock(this Matrix<double> matrix)
        {
            int height = matrix.RowCount;
            int width = matrix.ColumnCount;
            int[] result = new int[height * width];
            int index = 0;
            for (int i = 0; i < height - 1; i++)
            {
                for (int j = 0; j < width - 1; j++)
                {
                    result[index] = (int)matrix[i, j];
                    index++;
                }
            }
            for (int i = 0; i < height - 1; i++)
            {
                result[index] = (int)matrix[i, width - 1];
                index++;
            }
            for (int j = width - 2; j >= 0 ; j--)
            {
                result[index] = (int)matrix[height - 1, j];
                index++;
            }
            result[index] = (int)matrix[height - 1, width - 1];
            return result;
        }
        public static int[] GetDiagonalTopLeft(this Matrix<double> matrix)
        {
            int height = matrix.RowCount;
            int width = matrix.ColumnCount;
            int[] result = new int[height + width - 1];
            int index = 0;
            for (int k = 0; k < height; k++)
            {
                int sum = 0;
                for (int i = k, j = 0; i >= 0 && j <= width - 1; i--, j++)
                {
                    sum += (int)matrix[i, j];
                }
                result[index] = sum % 2;
                index++;
            }
            for (int k = 1; k < width; k++)
            {
                int sum = 0;
                for (int i = height - 1, j = k; i >= 0 && j <= width - 1; i--, j++)
                {
                    sum += (int)matrix[i, j];
                }
                result[index] = sum % 2;
                index++;
            }
            return result;
        }
        public static int[] GetDiagonalBottomLeft(this Matrix<double> matrix)
        {
            int height = matrix.RowCount;
            int width = matrix.ColumnCount;
            int[] result = new int[height + width - 1];
            int index = 0;
            for (int k = width - 1; k >= 0; k--)
            {
                int sum = 0;
                for (int i = height - 1, j = k; i >= 0 && j >= 0; i--, j--)
                {
                    sum += (int)matrix[i, j];
                }
                result[index] = sum % 2;
                index++;
            }
            for (int k = height - 2; k >= 0; k--)
            {
                int sum = 0;
                for (int i = k, j = width - 1; i >= 0 && j >= 0; i--, j--)
                {
                    sum += (int)matrix[i, j];
                }
                result[index] = sum % 2;
                index++;
            }
            return result;
        }
        public static string ToArrayString(this int[] array)
        {
            string result = "";
            for (int i = 0; i < array.Length; i++)
            {
                result += array[i].ToString();
            }
            return result;
        }
    }
}
