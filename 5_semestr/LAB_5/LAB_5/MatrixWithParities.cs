using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_5
{
    public class MatrixWithParities
    {
        public Matrix<double> Matrix;
        public int[] DiagonalTopLeft;
        public int[] DiagonalBottomLeft;
        public MatrixWithParities(Matrix<double> matrix, int[] dtl, int[] dbl)
        {
            Matrix = matrix;
            DiagonalTopLeft = dtl;
            DiagonalBottomLeft = dbl;
        }
        public int[] GetInfoBlock()
        {
            int height = Matrix.RowCount;
            int width = Matrix.ColumnCount;
            int size = height * width;
            if (DiagonalTopLeft != null)
                size += (height - 1) + (width - 1) - 1;
            if (DiagonalBottomLeft != null)
                size += (height - 1) + (width - 1) - 1;
            int[] result = new int[size];
            int index = 0;
            for (int i = 0; i < height - 1; i++)
            {
                for (int j = 0; j < width - 1; j++)
                {
                    result[index] = (int)Matrix[i, j];
                    index++;
                }
            }
            for (int i = 0; i < height - 1; i++)
            {
                result[index] = (int)Matrix[i, width - 1];
                index++;
            }
            for (int j = width - 2; j >= 0; j--)
            {
                result[index] = (int)Matrix[height - 1, j];
                index++;
            }
            if (DiagonalTopLeft != null)
            {
                for (int i = 0; i < DiagonalTopLeft.Length; i++)
                {
                    result[index] = DiagonalTopLeft[i];
                    index++;
                }
            }
            if (DiagonalBottomLeft != null)
            {
                for (int i = 0; i < DiagonalBottomLeft.Length; i++)
                {
                    result[index] = DiagonalBottomLeft[i];
                    index++;
                }
            }
            result[index] = (int)Matrix[height - 1, width - 1];
            return result;
        }
    }
}
