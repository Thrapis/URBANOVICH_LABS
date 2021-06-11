using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_4.Enigma
{
    public class Rotor
    {
        private Dictionary<int, int> InOut;
        private Rotor NextRotor;
        private int[] ReserveOuts;
        private int Position;

        public int SymbolsCount { get; private set; }

        public RotorType Type { get; set; }
        public int Step { get; set; }

        public Rotor(int[] outs, RotorType type, int step = 1)
        {
            InOut = new Dictionary<int, int>();
            ReserveOuts = outs;
            SymbolsCount = outs.Length;
            Type = type;
            Position = 0;
            Step = step;

            for (int i = 0; i < outs.Length; i++)
            {
                InOut.Add(i, outs[i]);
            }
        }

        public void SetInputOutputConnection(int[] connection)
        {
            InOut = new Dictionary<int, int>();
            for (int i = 0; i < connection.Length; i++)
            {
                InOut.Add(i, connection[i]);
            }
            ReserveOuts = connection.ToArray();
            Position = 0;
        }

        public int[] GetInputOutputConnection()
        {
            return ReserveOuts.ToArray();
        }

        public void SetRotorPosition(int position)
        {
            if (position >= SymbolsCount)
                throw new Exception("Incorrect rotor position");

            InOut = new Dictionary<int, int>();
            Position = 0;

            for (int i = 0; i < ReserveOuts.Length; i++)
            {
                InOut.Add(i, ReserveOuts[i]);
            }

            while (Position < position)
            {
                for (int i = 0; i < SymbolsCount; i++)
                {
                    InOut[i] = (InOut[i] + 1) % SymbolsCount;
                }
                Position += 1;
            }
        }

        public int GetRotorPosition()
        {
            return Position;
        }

        public void EnqueueRotor(Rotor rotor)
        {
            if (NextRotor == null)
                NextRotor = rotor;
            else
                NextRotor.EnqueueRotor(rotor);
        }

        public void RollRotor()
        {
            for (int i = 0; i < SymbolsCount; i++)
            {
                InOut[i] = (InOut[i] + Step) % SymbolsCount;
            }

            Position += Step;
            if (Position >= SymbolsCount)
            {
                Position %= SymbolsCount;
                if (NextRotor != null)
                    NextRotor.RollRotor();
            }
        }

        public void NewRollRotor(bool plus)
        {
            for (int i = 0; i < SymbolsCount; i++)
            {
                InOut[i] = (InOut[i] + Step) % SymbolsCount;
            }
            Position += Step;
            if (plus)
            {
                for (int i = 0; i < SymbolsCount; i++)
                {
                    InOut[i] = (InOut[i] + 1) % SymbolsCount;
                }
                Position++;
            }

            if (Position >= SymbolsCount)
            {
                Position %= SymbolsCount;
                if (NextRotor != null)
                    NextRotor.NewRollRotor(true);
            }
            else if (NextRotor != null)
                NextRotor.NewRollRotor(false);
        }

        public void UnRollRotor()
        {
            for (int i = 0; i < SymbolsCount; i++)
            {
                InOut[i] = (InOut[i] - Step + SymbolsCount) % SymbolsCount;
            }

            Position -= Step;
            if (Position < 0)
            {
                Position = (Position + SymbolsCount) % SymbolsCount;
                if (NextRotor != null)
                    NextRotor.UnRollRotor();
            }
        }

        public void NewUnRollRotor(bool minus)
        {
            for (int i = 0; i < SymbolsCount; i++)
            {
                InOut[i] = (InOut[i] - Step + SymbolsCount) % SymbolsCount;
            }
            Position -= Step;
            if (minus)
            {
                for (int i = 0; i < SymbolsCount; i++)
                {
                    InOut[i] = (InOut[i] - 1) % SymbolsCount;
                }
                Position--;
            }

            if (Position < 0)
            {
                Position = (Position + SymbolsCount) % SymbolsCount;
                if (NextRotor != null)
                    NextRotor.NewUnRollRotor(true);
            }
            else if (NextRotor != null)
                NextRotor.NewUnRollRotor(false);
        }

        public int GetOutput(int input)
        {
            return InOut[input];
        }

        public int GetInput(int output)
        {
            return InOut.Where(t => t.Value == output).Select(t => t.Key).First();
        }

        public int ForwardSignal(int signal)
        {
            if (NextRotor != null)
                return NextRotor.ForwardSignal(GetOutput(signal));
            else
                return GetOutput(signal);
        }

        public int BackwardSignal(int signal)
        {
            if (NextRotor != null)
                return GetInput(NextRotor.BackwardSignal(signal));
            else
                return GetInput(signal);
        }

        public int GetRotorsChainCount(int currentCount)
        {
            if (NextRotor != null)
                return NextRotor.GetRotorsChainCount(currentCount + 1);
            else
                return currentCount + 1;
        }

        public void KeysSending(Stack<int> keys)
        {
            int key = keys.Pop();
            SetRotorPosition(key);

            if (NextRotor != null)
                NextRotor.KeysSending(keys);
        }

        public void GetRotorsList(List<Rotor> rotors)
        {
            rotors.Add(this);
            if (NextRotor != null)
                NextRotor.GetRotorsList(rotors);
        }

        public override string ToString()
        {
            return $"Rotor of {SymbolsCount} symbols";
        }
    }
}
