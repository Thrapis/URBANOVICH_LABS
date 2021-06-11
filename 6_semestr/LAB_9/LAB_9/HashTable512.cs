using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_9
{
    public static class HashTable512
    {
        private const int DefaultSize = 512;
        private const int DefaultWidth = 32;
        private const int DefaultHeight = 16;

        public static string GetHashTable(Encoding encoding, string text)
        {
            int sizeCoeff = 1;

            string binaryText = "";
            foreach (var ch in text)
            {
                string binary = Convert.ToString(encoding.GetBytes(ch.ToString())[0], 2);
                while (binary.Length < 8)
                    binary = binary.Insert(0, "0");
                binaryText += binary;
            }

            int countOfBT = binaryText.Length;

            while (DefaultSize * sizeCoeff - 64 - 1 < countOfBT)
                sizeCoeff++;


            string futureTable = "1";
            futureTable = futureTable.Insert(0, binaryText);

            for (int i = 0; i < DefaultSize * sizeCoeff - 64 - 1 - countOfBT; i++)
            {
                futureTable += "0";
            }

            string last64 = Convert.ToString(countOfBT, 2);

            while (last64.Length < 64)
                last64 = last64.Insert(0, "0");

            if (last64.Length > 64)
                last64.Remove(0, last64.Length - 64);

            futureTable += last64;

            return GetMatrix(futureTable, DefaultWidth, DefaultHeight * sizeCoeff);
        }

        private static string GetMatrix(string text, int width, int height)
        {
            string result = "";
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    result += text[i * width + j] + " ";
                }
                result += "\r\n";
            }
            return result;
        }
    }
}
