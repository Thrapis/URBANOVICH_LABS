using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_4.Enigma
{
    public class CommutationPanel
    {
        private const int MaxCommutations = 10 * 2;

        private Dictionary<int, int> Commutations;

        public CommutationPanel()
        {
            Commutations = new Dictionary<int, int>();
        }

        public bool AddCommutation(int commut_1, int commut_2)
        {
            if (MaxCommutations != Commutations.Count)
            {
                if (!Commutations.ContainsKey(commut_1) && !Commutations.ContainsKey(commut_2))
                {
                    Commutations.Add(commut_1, commut_2);
                    Commutations.Add(commut_2, commut_1);
                    return true;
                } 
            }

            return false;
        }

        public Dictionary<int, int> GetCommutations()
        {
            return Commutations.ToDictionary(t => t.Key, t => t.Value);
        }

        public bool RemoveCommutationWith(int commut)
        {
            if (Commutations.ContainsKey(commut))
            {
                int nextcommut = Commutations[commut];
                Commutations.Remove(commut);
                Commutations.Remove(nextcommut);
                return true;
            }

            return false;
        }

        public bool Contains(int commut)
        {
            return Commutations.ContainsKey(commut);
        }

        public int ResendSignal(int signal)
        {
            if (Commutations.ContainsKey(signal))
                return Commutations[signal];
            else
                return signal;
        }
    }
}
