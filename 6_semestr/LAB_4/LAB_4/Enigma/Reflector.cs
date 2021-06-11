using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_4.Enigma
{
    public class Reflector
    {
        private Dictionary<int, int> InOut;

        public ReflectorType Type { get; set; }
        public int SymbolsCount { get; private set; }

        public Reflector(Dictionary<int, int> connections, ReflectorType type)
        {
            InOut = connections;
            SymbolsCount = connections.Count;
            Type = type;
        }

        public Dictionary<int, int> GetConnection()
        {
            return InOut.ToDictionary(t => t.Key, t => t.Value);
        }

        public void SetConnection(Dictionary<int, int> connection)
        {
            InOut = connection;
        }

        public int Reflect(int signal)
        {
            return InOut[signal];
        }

        public override string ToString()
        {
            return $"Reflector of {InOut.Count} symbols";
        }
    }
}
