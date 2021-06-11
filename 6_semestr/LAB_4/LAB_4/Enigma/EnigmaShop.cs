using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_4.Enigma
{
    public static class EnigmaShop
    {
        private static List<int[]> OutsList;
        private static List<Dictionary<int, int>> ConnectionList;

        static EnigmaShop()
        {
            OutsList = new List<int[]>();
            ConnectionList = new List<Dictionary<int, int>>();

            char[] outsI = new char[26] { 'E', 'K', 'M', 'F', 'L', 'G', 'D', 'Q', 'V', 'Z', 'N', 'T', 'O', 'W', 'Y', 'H', 'X', 'U', 'S', 'P', 'A', 'I', 'B', 'R', 'C', 'J' };
            char[] outsII = new char[26] { 'A', 'J', 'D', 'K', 'S', 'I', 'R', 'U', 'X', 'B', 'L', 'H', 'W', 'T', 'M', 'C', 'Q', 'G', 'Z', 'N', 'P', 'Y', 'F', 'V', 'O', 'E' };
            char[] outsIII = new char[26] { 'B', 'D', 'F', 'H', 'J', 'L', 'C', 'P', 'R', 'T', 'X', 'V', 'Z', 'N', 'Y', 'E', 'I', 'W', 'G', 'A', 'K', 'M', 'U', 'S', 'Q', 'O' };
            char[] outsIV = new char[26] { 'E', 'S', 'O', 'V', 'P', 'Z', 'J', 'A', 'Y', 'Q', 'U', 'I', 'R', 'H', 'X', 'L', 'N', 'F', 'T', 'G', 'K', 'D', 'C', 'M', 'W', 'B' };
            char[] outsV = new char[26] { 'V', 'Z', 'B', 'R', 'G', 'I', 'T', 'Y', 'U', 'P', 'S', 'D', 'N', 'H', 'L', 'X', 'A', 'W', 'M', 'J', 'Q', 'O', 'F', 'E', 'C', 'K' };
            char[] outsVI = new char[26] { 'J', 'P', 'G', 'V', 'O', 'U', 'M', 'F', 'Y', 'Q', 'B', 'E', 'N', 'H', 'Z', 'R', 'D', 'K', 'A', 'S', 'X', 'L', 'I', 'C', 'T', 'W' };
            char[] outsVII = new char[26] { 'N', 'Z', 'J', 'H', 'G', 'R', 'C', 'X', 'M', 'Y', 'S', 'W', 'B', 'O', 'U', 'F', 'A', 'I', 'V', 'L', 'P', 'E', 'K', 'Q', 'D', 'T' };
            char[] outsVIII = new char[26] { 'F', 'K', 'Q', 'H', 'T', 'L', 'X', 'O', 'C', 'B', 'J', 'S', 'P', 'D', 'Z', 'R', 'A', 'M', 'E', 'W', 'N', 'I', 'U', 'Y', 'G', 'V' };
            char[] outsBeta = new char[26] { 'L', 'E', 'Y', 'J', 'V', 'C', 'N', 'I', 'X', 'W', 'P', 'B', 'Q', 'M', 'D', 'R', 'T', 'A', 'K', 'Z', 'G', 'F', 'U', 'H', 'O', 'S' };
            char[] outsGamma = new char[26] { 'F', 'S', 'O', 'K', 'A', 'N', 'U', 'E', 'R', 'H', 'M', 'B', 'T', 'I', 'Y', 'C', 'W', 'L', 'Q', 'P', 'Z', 'X', 'V', 'G', 'J', 'D' };

            char[] connectionB = new char[26] { 'Y', 'R', 'U', 'H', 'Q', 'S', 'L', 'D', 'P', 'X', 'N', 'G', 'O', 'K', 'M', 'I', 'E', 'B', 'F', 'Z', 'C', 'W', 'V', 'J', 'A', 'T' };
            char[] connectionC = new char[26] { 'F', 'V', 'P', 'J', 'I', 'A', 'O', 'Y', 'E', 'D', 'R', 'Z', 'X', 'W', 'G', 'C', 'T', 'K', 'U', 'Q', 'S', 'B', 'N', 'M', 'H', 'L' };
            char[] connectionBDunn = new char[26] { 'E', 'N', 'K', 'Q', 'A', 'U', 'Y', 'W', 'J', 'I', 'C', 'O', 'P', 'B', 'L', 'M', 'D', 'X', 'Z', 'V', 'F', 'T', 'H', 'R', 'G', 'S' };
            char[] connectionCDunn = new char[26] { 'R', 'D', 'O', 'B', 'J', 'N', 'T', 'K', 'V', 'E', 'H', 'M', 'L', 'F', 'C', 'W', 'Z', 'A', 'X', 'G', 'Y', 'I', 'P', 'S', 'U', 'Q' };

            OutsList.Add(outsI.Select(t => (int)t - (int)'A').ToArray());
            OutsList.Add(outsII.Select(t => (int)t - (int)'A').ToArray());
            OutsList.Add(outsIII.Select(t => (int)t - (int)'A').ToArray());
            OutsList.Add(outsIV.Select(t => (int)t - (int)'A').ToArray());
            OutsList.Add(outsV.Select(t => (int)t - (int)'A').ToArray());
            OutsList.Add(outsVI.Select(t => (int)t - (int)'A').ToArray());
            OutsList.Add(outsVII.Select(t => (int)t - (int)'A').ToArray());
            OutsList.Add(outsVIII.Select(t => (int)t - (int)'A').ToArray());
            OutsList.Add(outsBeta.Select(t => (int)t - (int)'A').ToArray());
            OutsList.Add(outsGamma.Select(t => (int)t - (int)'A').ToArray());

            ConnectionList.Add(connectionB.Select(t => (int)t - (int)'A')
                .ToDictionary(v => connectionB.ToList().IndexOf((char)(v + 'A'))));
            ConnectionList.Add(connectionC.Select(t => (int)t - (int)'A')
                .ToDictionary(v => connectionC.ToList().IndexOf((char)(v + 'A'))));
            ConnectionList.Add(connectionBDunn.Select(t => (int)t - (int)'A')
                .ToDictionary(v => connectionBDunn.ToList().IndexOf((char)(v + 'A'))));
            ConnectionList.Add(connectionCDunn.Select(t => (int)t - (int)'A')
                .ToDictionary(v => connectionCDunn.ToList().IndexOf((char)(v + 'A'))));
        }

        public static Rotor GetRotor(RotorType rotorType, int step = 1)
        {
            if (rotorType == RotorType.CustomRotor)
                return GenerateRotor(26, step);
            else
                return new Rotor(OutsList[(int)rotorType].ToArray(), rotorType, step);
        }

        public static Reflector GetReflector(ReflectorType reflectorType)
        {
            if (reflectorType == ReflectorType.CustomReflector)
                return GenerateReflector(26);
            else
                return new Reflector(ConnectionList[(int)reflectorType].ToDictionary(t => t.Key, t => t.Value), reflectorType);
        }

        public static Rotor GenerateRotor(int symbolsCount, int step = 1)
        {
            Random ran = new Random();
            List<int> outs = new List<int>();

            for (int i = 0; i < symbolsCount; i++)
            {
                int el = ran.Next(0, symbolsCount);
                while (outs.Contains(el))
                    el = ran.Next(0, symbolsCount);

                outs.Add(el);
            }

            return new Rotor(outs.ToArray(), RotorType.CustomRotor, step);
        }

        public static Reflector GenerateReflector(int symbolsCount)
        {
            if (symbolsCount % 2 != 0)
                throw new Exception("Нечётное количество символов");

            Random ran = new Random();
            Dictionary<int, int> reflectionConnections = new Dictionary<int, int>();

            for (int i = 0; i < symbolsCount; i++)
            {
                if (!reflectionConnections.ContainsKey(i))
                {
                    int cokey = ran.Next(0, symbolsCount);
                    while (reflectionConnections.ContainsKey(cokey) || i == cokey)
                        cokey = ran.Next(0, symbolsCount);

                    reflectionConnections.Add(i, cokey);
                    reflectionConnections.Add(cokey, i);
                }
            }

            return new Reflector(reflectionConnections, ReflectorType.CustomReflector);
        }
    }
}
