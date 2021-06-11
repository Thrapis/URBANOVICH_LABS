using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LAB_8
{
	public class RSA
	{
		public BigInteger P { get; private set; }
		public BigInteger Q { get; private set; }
		public BigInteger N { get; private set; }
		public BigInteger D { get; private set; }
		public BigInteger E { get; private set; }

		public RSA(BigInteger p, BigInteger q, BigInteger d)
		{
			if (p - 1 == Additions.EulerFunction(p) && q - 1 == Additions.EulerFunction(q))
			{
				P = p;
				Q = q;
				N = p * q;
				D = d;
				E = Additions.GetReversedByModulo(d, Additions.EulerFunction(N));
			}
			else
				throw new Exception("You loh");
		}

		public BigInteger[] Ecryption(string text)
        {
			List<BigInteger> result = new List<BigInteger>();

			for (int i = 0; i < text.Length; i++)
            {
				result.Add(BigInteger.ModPow(text[i], E, N));
            }

			return result.ToArray();
        }

		public string Decryption(BigInteger[] encrypted)
		{
			string result = "";

			for (int i = 0; i < encrypted.Length; i++)
			{
				result += (char)(BigInteger.ModPow(encrypted[i], D, N));
			}

			return result;
		}
	}
}
