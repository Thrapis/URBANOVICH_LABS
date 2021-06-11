using LAB_10;
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

		public static BigInteger GetEDS(string text, BigInteger N, BigInteger D)
		{
			BigInteger hash = BigInteger.Abs(BigInteger.Parse(MD5.GetHash(text).Substring(0, 8), System.Globalization.NumberStyles.AllowHexSpecifier));
			BigInteger EDShash = BigInteger.ModPow(hash, D, N);
			Console.WriteLine("Enc hash: " + hash);

			return EDShash;
		}

		public static bool VerifyEDS(string text, BigInteger eds, BigInteger N, BigInteger E)
		{
			BigInteger hash = BigInteger.Abs(BigInteger.Parse(MD5.GetHash(text).Substring(0, 8), System.Globalization.NumberStyles.AllowHexSpecifier));
			BigInteger deEDS = BigInteger.ModPow(eds, E, N);
			Console.WriteLine("Dec hash: " + deEDS);

			return hash == deEDS;
		}

		public static BigInteger[] Ecryption(string text, BigInteger N, BigInteger D)
		{
			List<BigInteger> result = new List<BigInteger>();

			for (int i = 0; i < text.Length; i++)
			{
				result.Add(BigInteger.ModPow(text[i], D, N));
			}

			return result.ToArray();
		}

		public static string Decryption(BigInteger[] encrypted, BigInteger N, BigInteger E)
		{
			string result = "";

			for (int i = 0; i < encrypted.Length; i++)
			{
				result += (char)(BigInteger.ModPow(encrypted[i], E, N));
			}

			return result;
		}

		public BigInteger[] Ecryption(string text)
        {
			List<BigInteger> result = new List<BigInteger>();

			for (int i = 0; i < text.Length; i++)
            {
				result.Add(BigInteger.ModPow(text[i], D, N));
            }

			return result.ToArray();
        }

		public string Decryption(BigInteger[] encrypted)
		{
			string result = "";

			for (int i = 0; i < encrypted.Length; i++)
			{
				result += (char)(BigInteger.ModPow(encrypted[i], E, N));
			}

			return result;
		}
	}
}
