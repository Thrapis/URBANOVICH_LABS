using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_5
{
    public static class DES
    {
        private static byte[] IP;
        private static byte[] E;

        private static byte[] S1;
        private static byte[] S2;
        private static byte[] S3;
        private static byte[] S4;
        private static byte[] S5;
        private static byte[] S6;
        private static byte[] S7;
        private static byte[] S8;

        private static byte[] FunP;
        private static byte[] KeyP;
        private static byte[] IP_1;

        private static byte[] KeyMap;
        private static byte[] Offsets;

        static DES()
        {
            IP = new byte[]{58,50,42,34,26,18,10,2,60,52,44,36,28,20,12,4,
                            62,54,46,38,30,22,14,6,64,56,48,40,32,24,16,8,
                            57,49,41,33,25,17,9,1,59,51,43,35,27,19,11,3,
                            61,53,45,37,29,21,13,5,63,55,47,39,31,23,15,7};
            IP_1 = new byte[] {40,8,48,16,56,24,64,32,39,7,47,15,55,23,63,31,
                            38,6,46,14,54,22,62,30,37,5,45,13,53,21,61,29,
                            36,4,44,12,52,20,60,28,35,3,43,11,51,19,59,27,
                            34,2,42,10,50,18,58,26,33,1,41,9,49,17,57,25};

            E = new byte[] { 32,1, 2, 3, 4, 5,
                            4, 5, 6, 7, 8, 9,
                            8, 9, 10,11,12,13,
                            12,13,14,15,16,17,
                            16,17,18,19,20,21,
                            20,21,22,23,24,25,
                            24,25,26,27,28,29,
                            28,29,30,31,32,1};

            KeyP = new byte[] { 57,49,41,33,25,17,9, 1, 58,50,42,34,26,18,
                                10,2, 59,51,43,35,27,19,11,3, 60,52,44,36,
                                63,55,47,39,31,23,15,7, 62,54,46,38,30,22,
                                14,6, 61,53,45,37,29,21,13,5, 28,20,12,4};

            FunP = new byte[] { 16,7, 20,21,29,12,28,17,
                                1, 15,23,26,5, 18,31,10,
                                2, 8, 24,14,32,27,3, 9,
                                19,13,30,6, 22,11,4, 25};

            S1 = new byte[] { 14,4, 13,1, 2, 15,11,8, 3, 10,6, 12,5, 9, 0, 7,
                              0, 15,7, 4, 14,2, 13,1, 10,6, 12,11,9, 5, 3, 8,
                              4, 1, 14,8, 13,6, 2, 11,15,12,9, 7, 3, 10,5, 0,
                              15,12,8, 2, 4, 9, 1, 7, 5, 11,3, 14,10,0, 6, 13};
            S2 = new byte[] {15,1, 8, 14,6, 11,3, 4, 9, 7, 2, 13,12,0, 5, 10,
                            3, 13,4, 7, 15,2, 8, 14,12,0, 1, 10,6, 9, 11,5,
                            0, 14,7, 11,10,4, 13,1, 5, 8, 12,6, 9, 3, 2, 15,
                            13,8, 10,1, 3, 15,4, 2, 11,6, 7, 12,0, 5, 14,9};
            S3 = new byte[] {10,0, 9, 14,6, 3, 15,5, 1, 13,12,7, 11,4, 2, 8,
                            13,7, 0, 9, 3, 4, 6, 10,2, 8, 5, 14,12,11,15,1,
                            13,6, 4, 9, 8, 15,3, 0, 11,1, 2, 12,5, 10,14,7,
                            1, 10,13,0, 6, 9, 8, 7, 4, 15,14,3, 11,5, 2, 12};
            S4 = new byte[] { 7, 13,14,3, 0, 6, 9, 10,1, 2, 8, 5, 11,12,4, 15,
                            13,8, 11,5, 6, 15,0, 3, 4, 7, 2, 12,1, 10,14,9,
                            10,6, 9, 0, 12,11,7, 13,15,1, 3, 14,5, 2, 8, 4,
                            3, 15,0, 6, 10,1, 13,8, 9, 4, 5, 11,12,7, 2, 14};
            S5 = new byte[] { 2, 12,4, 1, 7, 10,11,6, 8, 5, 3, 15,13,0, 14,9,
                            14,11,2, 12,4, 7, 13,1, 5, 0, 15,10,3, 9, 8, 6,
                            4, 2, 1, 11,10,13,7, 8, 15,9, 12,5, 6, 3, 0, 14,
                            11,8, 12,7, 1, 14,2, 13,6, 15,0, 9, 10,4, 5, 3   };
            S6 = new byte[] { 12,1, 10,15,9, 2, 6, 8, 0, 13,3, 4, 14,7, 5, 11,
                            10,15,4, 2, 7, 12,9, 5, 6, 1, 13,14,0, 11,3, 8,
                            9, 14,15,5, 2, 8, 12,3, 7, 0, 4, 10,1, 13,11,6,
                            4, 3, 2, 12,9, 5, 15,10,11,14,1, 7, 6, 0, 8, 13};
            S7 = new byte[] {4, 11,2, 14,15,0, 8, 13,3, 12,9, 7, 5, 10,6, 1,
                            13,0, 11,7, 4, 9, 1, 10,14,3, 5, 12,2, 15,8, 6,
                            1, 4, 11,13,12,3, 7, 14,10,15,6, 8, 0, 5, 9, 2,
                            6, 11,13,8, 1, 4, 10,7, 9, 5, 0, 15,14,2, 3, 12};
            S8 = new byte[] { 13,2, 8, 4, 6, 15,11,1, 10,9, 3, 14,5, 0, 12,7,
                            1, 15,13,8, 10,3, 7, 4, 12,5, 6, 11,0, 14,9, 2,
                            7, 11,4, 1, 9, 12,14,2, 0, 6, 10,13,15,3, 5, 8,
                            2, 1, 14,7, 4, 10,8, 13,15,12,9, 0, 3, 5, 6, 11};

            Offsets = new byte[] { 1, 1, 2, 2, 2, 2, 2, 2, 1, 2, 2, 2, 2, 2, 2, 1 };

            KeyMap = new byte[] {14,17,11,24,1, 5, 3, 28,15,6, 21,10,23,19,12,4,
                                26,8, 16,7, 27,20,13,2, 41,52,31,37,47,55,30,40,
                                51,45,33,48,44,49,39,56,34,53,46,42,50,36,29,32};

        }

        public static string Encrypt(DESType type, string message, params string[] keyplus)
        {
            foreach (var kp in keyplus)
            {
                if (kp.Length != 8)
                    throw new Exception("Invalid keyplus parameter");

                if (!IsKeySafe(kp))
                    throw new Exception("The keyplus is damaged");
            }

            string binaryMessage = ToBinaryOctoplets(message);
            while (binaryMessage.Length % 64 != 0)
                binaryMessage += "00000000";

            string[] binaryKeyplus = new string[keyplus.Length];
            string[] extendedKeyplus = new string[keyplus.Length];
            for (int i = 0; i < keyplus.Length; i++)
            {
                binaryKeyplus[i] = ToBinaryOctoplets(keyplus[i]);
                extendedKeyplus[i] = PermutateWith(KeyP, binaryKeyplus[i]);
            }

            string binaryResult = "";
            switch (type)
            {
                case DESType.DES:
                    binaryResult = EncryptionStrategySimple(binaryMessage, extendedKeyplus[0]);
                    break;
                case DESType.DES_EEE2:
                    binaryResult = EncryptionStrategyEEE2(binaryMessage, extendedKeyplus);
                    break;
                case DESType.DES_EDE2:
                    binaryResult = EncryptionStrategyEDE2(binaryMessage, extendedKeyplus);
                    break;
                case DESType.DES_EEE3:
                    binaryResult = EncryptionStrategyEEE3(binaryMessage, extendedKeyplus);
                    break;
                case DESType.DES_EDE3:
                    binaryResult = EncryptionStrategyEDE3(binaryMessage, extendedKeyplus);
                    break;
            }
            return binaryResult;
        }

        public static string Decrypt(DESType type, string encrypted, params string[] keyplus)
        {
            foreach (var kp in keyplus)
            {
                if (kp.Length != 8)
                    throw new Exception("Invalid keyplus parameter");

                if (!IsKeySafe(kp))
                    throw new Exception("The keyplus is damaged");
            }

            string binaryEncrypted = ToBinaryOctoplets(encrypted);

            string[] binaryKeyplus = new string[keyplus.Length];
            string[] extendedKeyplus = new string[keyplus.Length];
            for (int i = 0; i < keyplus.Length; i++)
            {
                binaryKeyplus[i] = ToBinaryOctoplets(keyplus[i]);
                extendedKeyplus[i] = PermutateWith(KeyP, binaryKeyplus[i]);
            }

            string binaryResult = "";
            switch (type)
            {
                case DESType.DES:
                    binaryResult = DecryptionStrategySimple(binaryEncrypted, extendedKeyplus[0]);
                    break;
                case DESType.DES_EEE2:
                    binaryResult = DecryptionStrategyEEE2(binaryEncrypted, extendedKeyplus);
                    break;
                case DESType.DES_EDE2:
                    binaryResult = DecryptionStrategyEDE2(binaryEncrypted, extendedKeyplus);
                    break;
                case DESType.DES_EEE3:
                    binaryResult = DecryptionStrategyEEE3(binaryEncrypted, extendedKeyplus);
                    break;
                case DESType.DES_EDE3:
                    binaryResult = DecryptionStrategyEDE3(binaryEncrypted, extendedKeyplus);
                    break;
            }
            return ToText(binaryResult);
        }

        private static string EncryptionStrategySimple(string binaryMessage, string extendedKeyplus)
        {
            string result = "";
            for (int i = 0; i + 63 < binaryMessage.Length; i += 64)
            {
                string first64 = PermutateWith(IP, binaryMessage.Substring(i, 64));
                string firstLeft = first64.Substring(0, 32);
                string firstRight = first64.Substring(32, 32);
                string firstKey = GetNextKey(0, extendedKeyplus);
                result += MakeRound(0, firstLeft, firstRight, firstKey);
            }
            return result;
        }

        private static string EncryptionStrategyEEE2(string binaryMessage, string[] extendedKeyplus)
        {
            string result = "";
            string buf1 = "";
            string buf2 = "";
            for (int i = 0; i + 63 < binaryMessage.Length; i += 64)
            {
                string first64 = PermutateWith(IP, binaryMessage.Substring(i, 64));
                string firstLeft = first64.Substring(0, 32);
                string firstRight = first64.Substring(32, 32);
                string firstKey = GetNextKey(0, extendedKeyplus[0]);
                buf1 += MakeRound(0, firstLeft, firstRight, firstKey);
            }
            for (int i = 0; i + 63 < buf1.Length; i += 64)
            {
                string first64 = PermutateWith(IP, buf1.Substring(i, 64));
                string firstLeft = first64.Substring(0, 32);
                string firstRight = first64.Substring(32, 32);
                string firstKey = GetNextKey(0, extendedKeyplus[1]);
                buf2 += MakeRound(0, firstLeft, firstRight, firstKey);
            }
            for (int i = 0; i + 63 < buf2.Length; i += 64)
            {
                string first64 = PermutateWith(IP, buf2.Substring(i, 64));
                string firstLeft = first64.Substring(0, 32);
                string firstRight = first64.Substring(32, 32);
                string firstKey = GetNextKey(0, extendedKeyplus[0]);
                result += MakeRound(0, firstLeft, firstRight, firstKey);
            }
            return result;
        }

        private static string EncryptionStrategyEDE2(string binaryMessage, string[] extendedKeyplus)
        {
            string result = "";
            string buf1 = "";
            string buf2 = "";
            for (int i = 0; i + 63 < binaryMessage.Length; i += 64)
            {
                string first64 = PermutateWith(IP, binaryMessage.Substring(i, 64));
                string firstLeft = first64.Substring(0, 32);
                string firstRight = first64.Substring(32, 32);
                string firstKey = GetNextKey(0, extendedKeyplus[0]);
                buf1 += MakeRound(0, firstLeft, firstRight, firstKey);
            }
            for (int i = 0; i + 63 < buf1.Length; i += 64)
            {
                string first64 = PermutateWith(IP, buf1.Substring(i, 64));
                string firstLeft = first64.Substring(0, 32);
                string firstRight = first64.Substring(32, 32);
                string firstKey = extendedKeyplus[1];
                buf2 += MakeReverseRound(15, firstLeft, firstRight, firstKey);
            }
            for (int i = 0; i + 63 < buf2.Length; i += 64)
            {
                string first64 = PermutateWith(IP, buf2.Substring(i, 64));
                string firstLeft = first64.Substring(0, 32);
                string firstRight = first64.Substring(32, 32);
                string firstKey = GetNextKey(0, extendedKeyplus[0]);
                result += MakeRound(0, firstLeft, firstRight, firstKey);
            }
            return result;
        }

        private static string EncryptionStrategyEEE3(string binaryMessage, string[] extendedKeyplus)
        {
            string result = "";
            string buf1 = "";
            string buf2 = "";
            for (int i = 0; i + 63 < binaryMessage.Length; i += 64)
            {
                string first64 = PermutateWith(IP, binaryMessage.Substring(i, 64));
                string firstLeft = first64.Substring(0, 32);
                string firstRight = first64.Substring(32, 32);
                string firstKey = GetNextKey(0, extendedKeyplus[0]);
                buf1 += MakeRound(0, firstLeft, firstRight, firstKey);
            }
            for (int i = 0; i + 63 < buf1.Length; i += 64)
            {
                string first64 = PermutateWith(IP, buf1.Substring(i, 64));
                string firstLeft = first64.Substring(0, 32);
                string firstRight = first64.Substring(32, 32);
                string firstKey = GetNextKey(0, extendedKeyplus[1]);
                buf2 += MakeRound(0, firstLeft, firstRight, firstKey);
            }
            for (int i = 0; i + 63 < buf2.Length; i += 64)
            {
                string first64 = PermutateWith(IP, buf2.Substring(i, 64));
                string firstLeft = first64.Substring(0, 32);
                string firstRight = first64.Substring(32, 32);
                string firstKey = GetNextKey(0, extendedKeyplus[2]);
                result += MakeRound(0, firstLeft, firstRight, firstKey);
            }
            return result;
        }

        private static string EncryptionStrategyEDE3(string binaryMessage, string[] extendedKeyplus)
        {
            string result = "";
            string buf1 = "";
            string buf2 = "";
            for (int i = 0; i + 63 < binaryMessage.Length; i += 64)
            {
                string first64 = PermutateWith(IP, binaryMessage.Substring(i, 64));
                string firstLeft = first64.Substring(0, 32);
                string firstRight = first64.Substring(32, 32);
                string firstKey = GetNextKey(0, extendedKeyplus[0]);
                buf1 += MakeRound(0, firstLeft, firstRight, firstKey);
            }
            for (int i = 0; i + 63 < buf1.Length; i += 64)
            {
                string first64 = PermutateWith(IP, buf1.Substring(i, 64));
                string firstLeft = first64.Substring(0, 32);
                string firstRight = first64.Substring(32, 32);
                string firstKey = extendedKeyplus[1];
                buf2 += MakeReverseRound(15, firstLeft, firstRight, firstKey);
            }
            for (int i = 0; i + 63 < buf2.Length; i += 64)
            {
                string first64 = PermutateWith(IP, buf2.Substring(i, 64));
                string firstLeft = first64.Substring(0, 32);
                string firstRight = first64.Substring(32, 32);
                string firstKey = GetNextKey(0, extendedKeyplus[2]);
                result += MakeRound(0, firstLeft, firstRight, firstKey);
            }
            return result;
        }

        private static string DecryptionStrategySimple(string binaryEncrypted, string extendedKeyplus)
        {
            string result = "";
            for (int i = 0; i + 63 < binaryEncrypted.Length; i += 64)
            {
                string first64 = PermutateWith(IP, binaryEncrypted.Substring(i, 64));
                string firstLeft = first64.Substring(0, 32);
                string firstRight = first64.Substring(32, 32);
                string firstKey = extendedKeyplus;
                result += MakeReverseRound(15, firstLeft, firstRight, firstKey);
            }
            return result;
        }

        private static string DecryptionStrategyEEE2(string binaryMessage, string[] extendedKeyplus)
        {
            string result = "";
            string buf1 = "";
            string buf2 = "";
            for (int i = 0; i + 63 < binaryMessage.Length; i += 64)
            {
                string first64 = PermutateWith(IP, binaryMessage.Substring(i, 64));
                string firstLeft = first64.Substring(0, 32);
                string firstRight = first64.Substring(32, 32);
                string firstKey = extendedKeyplus[0];
                buf1 += MakeReverseRound(15, firstLeft, firstRight, firstKey);
            }
            for (int i = 0; i + 63 < buf1.Length; i += 64)
            {
                string first64 = PermutateWith(IP, buf1.Substring(i, 64));
                string firstLeft = first64.Substring(0, 32);
                string firstRight = first64.Substring(32, 32);
                string firstKey = extendedKeyplus[1];
                buf2 += MakeReverseRound(15, firstLeft, firstRight, firstKey);
            }
            for (int i = 0; i + 63 < buf2.Length; i += 64)
            {
                string first64 = PermutateWith(IP, buf2.Substring(i, 64));
                string firstLeft = first64.Substring(0, 32);
                string firstRight = first64.Substring(32, 32);
                string firstKey = extendedKeyplus[0];
                result += MakeReverseRound(15, firstLeft, firstRight, firstKey);
            }
            return result;
        }

        private static string DecryptionStrategyEDE2(string binaryMessage, string[] extendedKeyplus)
        {
            string result = "";
            string buf1 = "";
            string buf2 = "";
            for (int i = 0; i + 63 < binaryMessage.Length; i += 64)
            {
                string first64 = PermutateWith(IP, binaryMessage.Substring(i, 64));
                string firstLeft = first64.Substring(0, 32);
                string firstRight = first64.Substring(32, 32);
                string firstKey = extendedKeyplus[0];
                buf1 += MakeReverseRound(15, firstLeft, firstRight, firstKey);
            }
            for (int i = 0; i + 63 < buf1.Length; i += 64)
            {
                string first64 = PermutateWith(IP, buf1.Substring(i, 64));
                string firstLeft = first64.Substring(0, 32);
                string firstRight = first64.Substring(32, 32);
                string firstKey = GetNextKey(0, extendedKeyplus[1]);
                buf2 += MakeRound(0, firstLeft, firstRight, firstKey);
            }
            for (int i = 0; i + 63 < buf2.Length; i += 64)
            {
                string first64 = PermutateWith(IP, buf2.Substring(i, 64));
                string firstLeft = first64.Substring(0, 32);
                string firstRight = first64.Substring(32, 32);
                string firstKey = extendedKeyplus[0];
                result += MakeReverseRound(15, firstLeft, firstRight, firstKey);
            }
            return result;
        }

        private static string DecryptionStrategyEEE3(string binaryMessage, string[] extendedKeyplus)
        {
            string result = "";
            string buf1 = "";
            string buf2 = "";
            for (int i = 0; i + 63 < binaryMessage.Length; i += 64)
            {
                string first64 = PermutateWith(IP, binaryMessage.Substring(i, 64));
                string firstLeft = first64.Substring(0, 32);
                string firstRight = first64.Substring(32, 32);
                string firstKey = extendedKeyplus[2];
                buf1 += MakeReverseRound(15, firstLeft, firstRight, firstKey);
            }
            for (int i = 0; i + 63 < buf1.Length; i += 64)
            {
                string first64 = PermutateWith(IP, buf1.Substring(i, 64));
                string firstLeft = first64.Substring(0, 32);
                string firstRight = first64.Substring(32, 32);
                string firstKey = extendedKeyplus[1];
                buf2 += MakeReverseRound(15, firstLeft, firstRight, firstKey);
            }
            for (int i = 0; i + 63 < buf2.Length; i += 64)
            {
                string first64 = PermutateWith(IP, buf2.Substring(i, 64));
                string firstLeft = first64.Substring(0, 32);
                string firstRight = first64.Substring(32, 32);
                string firstKey = extendedKeyplus[0];
                result += MakeReverseRound(15, firstLeft, firstRight, firstKey);
            }
            return result;
        }

        private static string DecryptionStrategyEDE3(string binaryMessage, string[] extendedKeyplus)
        {
            string result = "";
            string buf1 = "";
            string buf2 = "";
            for (int i = 0; i + 63 < binaryMessage.Length; i += 64)
            {
                string first64 = PermutateWith(IP, binaryMessage.Substring(i, 64));
                string firstLeft = first64.Substring(0, 32);
                string firstRight = first64.Substring(32, 32);
                string firstKey = extendedKeyplus[2];
                buf1 += MakeReverseRound(15, firstLeft, firstRight, firstKey);
            }
            for (int i = 0; i + 63 < buf1.Length; i += 64)
            {
                string first64 = PermutateWith(IP, buf1.Substring(i, 64));
                string firstLeft = first64.Substring(0, 32);
                string firstRight = first64.Substring(32, 32);
                string firstKey = GetNextKey(0, extendedKeyplus[1]);
                buf2 += MakeRound(0, firstLeft, firstRight, firstKey);
            }
            for (int i = 0; i + 63 < buf2.Length; i += 64)
            {
                string first64 = PermutateWith(IP, buf2.Substring(i, 64));
                string firstLeft = first64.Substring(0, 32);
                string firstRight = first64.Substring(32, 32);
                string firstKey = extendedKeyplus[0];
                result += MakeReverseRound(15, firstLeft, firstRight, firstKey);
            }
            return result;
        }

        public static string KeyToSafeKey(string key7byte)
        {
            string keyBin = ToBinaryOctoplets(key7byte);

            string keyplus = "";
            for (int i = 0; i + 6 < keyBin.Length; i += 7)
            {
                if (OddCountOfOnes(keyBin.Substring(i, 7)))
                    keyplus += keyBin.Substring(i, 7) + "0";
                else
                    keyplus += keyBin.Substring(i, 7) + "1";
            }

            return ToText(keyplus);
        }

        public static bool IsKeySafe(string keyplus)
        {
            string binKeyplus = ToBinaryOctoplets(keyplus);
            for (int i = 0; i + 7 < binKeyplus.Length; i += 8)
            {
                bool oddCountOfOnes = OddCountOfOnes(binKeyplus.Substring(i, 7));
                if (oddCountOfOnes && binKeyplus[i + 7] != '0' || !oddCountOfOnes && binKeyplus[i + 7] != '1')
                    return false;
            }
            return true;
        }

        public static string FromBinaryToHex(string binaryOctoplets)
        {
            string result = "";
            for (int i = 0; i + 7 < binaryOctoplets.Length; i += 8)
            {
                string binByte = binaryOctoplets.Substring(i, 8);
                
                result += Convert.ToString(Convert.ToByte(binByte, 2), 16).PadLeft(2, '0').ToUpper();

                if (i + 7 + 8 < binaryOctoplets.Length)
                    result += "-";
            }
            return result;
        }

        public static string ToBinaryOctoplets(string text)
        {
            string result = "";
            foreach (var symbol in Encoding.GetEncoding(1251).GetBytes(text))
            {
                string symbolBin = Convert.ToString(symbol, 2);
                while (symbolBin.Length % 8 != 0)
                    symbolBin = symbolBin.Insert(0, "0");
                result += symbolBin;
            }
            return result;
        }

        public static string ToText(string binaryOctoplets)
        {
            List<byte> bytes = new List<byte>();
            for (int i = 0; i + 7 < binaryOctoplets.Length; i += 8)
            {
                string binByte = binaryOctoplets.Substring(i, 8);
                bytes.Add(Convert.ToByte(binByte, 2));
            }
            return Encoding.GetEncoding(1251).GetString(bytes.ToArray());
        }

        private static string PermutateWith(byte[] plan, string bin)
        {
            string result = "";

            for (int i = 0; i < plan.Length; i++)
            {
                result += bin[plan[i] - 1];
            }

            return result;
        }

        private static string Function(string side, string key)
        {
            string sideXorKey = XOR(PermutateWith(E, side), PermutateWith(KeyMap, key));

            string blocks4bit = "";
            int block = 1;
            for (int i = 0; i + 5 < sideXorKey.Length; i += 6)
            {
                string a = "" + sideXorKey[i] + sideXorKey[i + 5];
                string b = "" + sideXorKey[i + 1] + sideXorKey[i + 2] + sideXorKey[i + 3] + sideXorKey[i + 4];
                int an = Convert.ToInt32(a, 2);
                int bn = Convert.ToInt32(b, 2);

                byte cross = 0;

                switch (block)
                {
                    case 1:
                        cross = S1[an * 16 + bn];
                        break;
                    case 2:
                        cross = S2[an * 16 + bn];
                        break;
                    case 3:
                        cross = S3[an * 16 + bn];
                        break;
                    case 4:
                        cross = S4[an * 16 + bn];
                        break;
                    case 5:
                        cross = S5[an * 16 + bn];
                        break;
                    case 6:
                        cross = S6[an * 16 + bn];
                        break;
                    case 7:
                        cross = S7[an * 16 + bn];
                        break;
                    case 8:
                        cross = S8[an * 16 + bn];
                        break;
                }

                string bincross = Convert.ToString(cross, 2);
                while (bincross.Length % 4 != 0)
                    bincross = bincross.Insert(0, "0");

                blocks4bit += bincross;
                block++;
            }

            return PermutateWith(FunP, blocks4bit);
        }

        private static string GetNextKey(int nextRound, string pastKey)
        {
            string C = pastKey.Substring(0, 28);
            string D = pastKey.Substring(28, 28);
            int offset = Offsets[nextRound];
            for (int i = 0; i < offset; i++)
            {
                C = C.Substring(1, C.Length - 1) + C[0];
                D = D.Substring(1, D.Length - 1) + D[0];
            }
            return C + D;
        }

        private static string GetPreviousKey(int previousRound, string pastKey)
        {
            string C = pastKey.Substring(0, 28);
            string D = pastKey.Substring(28, 28);
            int offset = Offsets[previousRound];
            for (int i = 0; i < offset; i++)
            {
                C = C[C.Length - 1] + C.Substring(0, C.Length - 1);
                D = D[C.Length - 1] + D.Substring(0, D.Length - 1);
            }
            return C + D;
        }

        private static string MakeRound(int depth, string pastLeft, string pastRight, string actualKey)
        {
            string newLeft = pastRight;
            string newRight = XOR(pastLeft, Function(pastRight, actualKey));

            if (depth < 15)
            {
                string nextKey = GetNextKey(depth + 1, actualKey);
                return MakeRound(depth + 1, newLeft, newRight, nextKey);
            }
            else
                return PermutateWith(IP_1, newLeft + newRight);
        }

        private static string MakeReverseRound(int depth, string pastLeft, string pastRight, string actualKey)
        {
            string newLeft = XOR(pastRight, Function(pastLeft, actualKey));
            string newRight = pastLeft;

            if (depth > 0)
            {
                string nextKey = GetPreviousKey(depth, actualKey);
                return MakeReverseRound(depth - 1, newLeft, newRight, nextKey);
            }
            else
                return PermutateWith(IP_1, newLeft + newRight);
        }

        private static bool OddCountOfOnes(string bin7)
        {
            int count = 0;
            foreach (var digit in bin7)
            {
                if (digit == '1')
                    count++;
            }
            return count % 2 == 1;
        }

        private static string XOR(string arg1, string arg2)
        {
            string result = "";

            for (int i = 0; i < arg1.Length && i < arg2.Length; i++)
            {
                result += arg1[i] == arg2[i] ? '0' : '1';
            }

            return result;
        }
    }
}