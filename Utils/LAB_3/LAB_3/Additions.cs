using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_3
{
    class Additions
    {
        public static byte Reverse(byte inByte)
        {
            byte result = 0x00;

            for (byte mask = 0x80; Convert.ToInt32(mask) > 0; mask >>= 1)
            {
                // shift right current result
                result = (byte)(result >> 1);

                // tempbyte = 1 if there is a 1 in the current position
                var tempbyte = (byte)(inByte & mask);
                if (tempbyte != 0x00)
                {
                    // Insert a 1 in the left
                    result = (byte)(result | 0x80);
                }
            }

            return (result);
        }

        public static BitArray FromSixToEight(BitArray bitArray)
        {
            BitArray result = new BitArray(8, false);

            for (int i = 0; i < 6; i++)
            {
                result[i + 2] = bitArray[i];
            }
            return result;
        }
        public static BitArray FromEightToSix(BitArray bitArray)
        {
            BitArray result = new BitArray(6, false);

            for (int i = 0; i < 6; i++)
            {
                result[i] = bitArray[i];
            }
            return result;
        }

        public static BitArray ToCanBeDividedBySix(BitArray bitArray, out int twoBits)
        {
            if (bitArray.Length % 6 != 0)
            {
                BitArray result = new BitArray(bitArray.Length + 6 - bitArray.Length % 6, false);
                for (int i = 0; i < bitArray.Length; i++)
                {
                    result[i] = bitArray[i];
                }
                twoBits = (6 - bitArray.Length % 6) / 2;
                return result;
            }
            twoBits = 0;
            return bitArray;
        }


        public static BitArray XOR(BitArray a, BitArray b)
        {
            BitArray result = new BitArray(a.Count);
            for (int i = 0; i < result.Count; i++)
            {
                result[i] = a[i] == b[i] ? false : true;
            }
            return result;
        }
    }
}
