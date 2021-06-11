using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_6
{
	public class BBS
	{
		public int P { get; private set; }
		public int Q { get; private set; }
		public int N { get; private set; }
		public int StartX { get; private set; }
		public int X { get; private set; }

		public BBS(int p, int q, int x_init)
		{
			if (p % 4 == 3 && q % 4 == 3 && Additions.EuclidsAlgorithmOfTwo(x_init, p * q) == 1)
			{
				P = p;
				Q = q;
				N = p * q;
				StartX = (int)Math.Pow(x_init % N, 2) % N;
				X = StartX;
			}
			else
				throw new Exception("You loh");
		
		}

		public void Reset() => X = StartX;

		public int GetNext() => X = (int)Math.Pow(X, 2) % N;

		public bool GetNextLowestBit() => GetLowestBit(GetNext());

		public static bool GetLowestBit(int x) => (x & 1) == 1;

        public static int GetNumberByIndex(int p, int q, int x_start, int t)
        {
            if (p % 4 == 3 && q % 4 == 3)
            {
                int n = p * q;
                int a = (int)Math.Pow(t, 2) % ((p - 1) * (q - 1));
                return (int)Math.Pow(x_start, a) % n;
            }
            else
                throw new Exception("You loh");
            
        }
    }
}
