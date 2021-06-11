using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_4.Enigma
{
    public class EnigmaMachine
    {
        private Rotor FirstRotor;
        private Reflector Reflector;
        private CommutationPanel CommutationPanel;
        private List<char> Keyboard;

        private readonly List<int[]> ReserveOutsList;

        public EnigmaMachine(char[] keyboard, List<int[]> outsList, Dictionary<int, int> reflectorConnections)
        {
            if (keyboard.Length != outsList[0].Length)
                throw new Exception("Invalid outs list");

            if (keyboard.Length != reflectorConnections.Count)
                throw new Exception("Invalid reflector connections");

            ReserveOutsList = new List<int[]>(outsList.ToArray());

            Keyboard = new List<char>(keyboard);

            for (int i = 0; i < outsList.Count; i++)
            {
                if (FirstRotor == null)
                {
                    FirstRotor = new Rotor(outsList[i], RotorType.CustomRotor);
                }
                else
                {
                    FirstRotor.EnqueueRotor(new Rotor(outsList[i], RotorType.CustomRotor));
                }
            }

            Reflector = new Reflector(reflectorConnections, ReflectorType.CustomReflector);
            CommutationPanel = new CommutationPanel();
        }

        public EnigmaMachine(char[] keyboard, List<Rotor> rotors, Reflector reflector, CommutationPanel commutationPanel = null)
        {
            Keyboard = new List<char>(keyboard.ToArray());
            Reflector = reflector;

            for (int i = 0; i < rotors.Count; i++)
            {
                if (FirstRotor == null)
                    FirstRotor = rotors[i];
                else
                    FirstRotor.EnqueueRotor(rotors[i]);
            }

            if (commutationPanel == null)
                CommutationPanel = new CommutationPanel();
            else
                CommutationPanel = commutationPanel;

        }

        public void ResetMachine()
        {
            FirstRotor = null;

            for (int i = 0; i < ReserveOutsList.Count; i++)
            {
                if (FirstRotor == null)
                {
                    FirstRotor = new Rotor(ReserveOutsList[i], RotorType.CustomRotor);
                }
                else
                {
                    FirstRotor.EnqueueRotor(new Rotor(ReserveOutsList[i], RotorType.CustomRotor));
                }
            }
        }

        public void SetKeys(int[] keys)
        {
            if (keys.Length > FirstRotor.GetRotorsChainCount(0))
                throw new Exception("To many keys");

            Stack<int> keysStack = new Stack<int>();
            for (int i = 0; i < keys.Length; i++)
            {
                keysStack.Push(keys[i]);
            }

            FirstRotor.KeysSending(keysStack);
        }

        public List<Rotor> GetRotors()
        {
            List<Rotor> rotors = new List<Rotor>();

            if (FirstRotor != null)
                FirstRotor.GetRotorsList(rotors);

            return rotors;
        }

        public Reflector GetReflector()
        {
            return Reflector;
        }

        public CommutationPanel GetCommutationPanel()
        {
            return CommutationPanel;
        }

        public char ClickTheButton(char c)
        {
            if (!Keyboard.Contains(c))
                throw new Exception("Keyboard has no one similar button");

            int commutationSignal = CommutationPanel.ResendSignal(Keyboard.IndexOf(c));

            int forwardSignal = FirstRotor.ForwardSignal(commutationSignal);

            int reflectSignal = Reflector.Reflect(forwardSignal);

            int backwardSignal = FirstRotor.BackwardSignal(reflectSignal);

            FirstRotor.RollRotor();

            int returnedSignal = CommutationPanel.ResendSignal(backwardSignal);

            return Keyboard.ElementAt(returnedSignal);
        }

        public char NewClickTheButton(char c)
        {
            if (!Keyboard.Contains(c))
                throw new Exception("Keyboard has no one similar button");

            int commutationSignal = CommutationPanel.ResendSignal(Keyboard.IndexOf(c));

            int forwardSignal = FirstRotor.ForwardSignal(commutationSignal);

            int reflectSignal = Reflector.Reflect(forwardSignal);

            int backwardSignal = FirstRotor.BackwardSignal(reflectSignal);

            FirstRotor.NewRollRotor(false);

            int returnedSignal = CommutationPanel.ResendSignal(backwardSignal);

            return Keyboard.ElementAt(returnedSignal);
        }

        public void RollBackRotors()
        {
            if (FirstRotor != null)
                FirstRotor.UnRollRotor();
        }

        public void NewRollBackRotors()
        {
            if (FirstRotor != null)
                FirstRotor.NewUnRollRotor(false);
        }
    }
}
