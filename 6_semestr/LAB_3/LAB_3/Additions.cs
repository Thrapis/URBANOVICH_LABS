using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_3
{
    public static class Additions
    {
        public static int[] SwapIndexes(this int[] arr, int i, int j)
        {
            int num1 = arr[i];
            int num2 = arr[j];
            arr[i] = num2;
            arr[j] = num1;
            return arr;
        }

        public static char[,] SwapRows(this char[,] arr, int r1, int r2)
        {
            char[] row1 = new char[arr.GetLength(1)];
            char[] row2 = new char[arr.GetLength(1)];

            for (int i = 0; i < arr.GetLength(1); i++)
            {
                row1[i] = arr[r1, i];
                row2[i] = arr[r2, i];
                arr[r1, i] = row2[i];
                arr[r2, i] = row1[i];
            }

            return arr;
        }

        public static char[,] SwapColoumns(this char[,] arr, int c1, int c2)
        {
            char[] col1 = new char[arr.GetLength(0)];
            char[] col2 = new char[arr.GetLength(0)];

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                col1[i] = arr[i, c1];
                col2[i] = arr[i, c2];
                arr[i, c1] = col2[i];
                arr[i, c2] = col1[i];
            }

            return arr;
        }

        public static char[,] SortByRows(char[,] arr, int[] rowsn)
        {
            bool changes = true;
            while (changes)
            {
                changes = false;
                for (int i = 1; i < rowsn.Length; i++)
                {
                    if (rowsn[i - 1] > rowsn[i])
                    {
                        rowsn = rowsn.SwapIndexes(i - 1, i);
                        arr = arr.SwapRows(i - 1, i);
                        changes = true;
                    }
                }
            }
            return arr;
        }

        public static char[,] SortByColoumns(char[,] arr, int[] colsn)
        {
            bool changes = true;
            while (changes)
            {
                changes = false;
                for (int i = 1; i < colsn.Length; i++)
                {
                    if (colsn[i - 1] > colsn[i])
                    {
                        colsn = colsn.SwapIndexes(i - 1, i);
                        arr = arr.SwapColoumns(i - 1, i);
                        changes = true;
                    }
                }
            }
            return arr;
        }

        public static char[,] RestoreByRows(char[,] arr, int[] rowsn)
        {
            int[] curRowsn = new int[rowsn.Length];
            for (int i = 0; i < rowsn.Length; i++)
            {
                curRowsn[i] = i + 1;
            }

            for (int n = 1; n <= rowsn.Length; n++)
            {
                int currentIndex = 0;
                int lastIndex = 0;
                for (int i = 0; i < curRowsn.Length; i++)
                {
                    if (curRowsn[i] == n)
                    {
                        currentIndex = i;
                        break;
                    }
                }
                for (int i = 0; i < rowsn.Length; i++)
                {
                    if (rowsn[i] == n)
                    {
                        lastIndex = i;
                        break;
                    }
                }

                curRowsn = curRowsn.SwapIndexes(currentIndex, lastIndex);
                arr = arr.SwapRows(currentIndex, lastIndex);
            }
            
            return arr;
        }

        public static char[,] RestoreByColoumns(char[,] arr, int[] colsn)
        {
            int[] curColsn = new int[colsn.Length];
            for (int i = 0; i < colsn.Length; i++)
            {
                curColsn[i] = i + 1;
            }

            for (int n = 1; n <= colsn.Length; n++)
            {
                int currentIndex = 0;
                int lastIndex = 0;
                for (int i = 0; i < curColsn.Length; i++)
                {
                    if (curColsn[i] == n)
                    {
                        currentIndex = i;
                        break;
                    }
                }
                for (int i = 0; i < colsn.Length; i++)
                {
                    if (colsn[i] == n)
                    {
                        lastIndex = i;
                        break;
                    }
                }

                curColsn = curColsn.SwapIndexes(currentIndex, lastIndex);
                arr = arr.SwapColoumns(currentIndex, lastIndex);
            }

            return arr;
        }

        public static string[] SplitToBlocks(this string text, BlockShape blockShape)
        {
            List<string> list = new List<string>();

            for (int i = 0; i + blockShape.Size - 1 < text.Length; i += blockShape.Size)
            {
                list.Add(text.Substring(i, blockShape.Size));
            }

            return list.ToArray();
        }
    }
}
