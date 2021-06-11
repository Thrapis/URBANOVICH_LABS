using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LAB_8
{
	public struct ElGamalBlock
	{
		public BigInteger A;
		public BigInteger B;

		public ElGamalBlock(BigInteger a, BigInteger b)
		{
			A = a;
			B = b;
		}
	}

	public class ElGamal
	{
		public BigInteger P { get; private set; }
		public BigInteger G { get; private set; }
		public BigInteger X { get; private set; }
		public BigInteger Y { get; private set; }

		public ElGamal(BigInteger p, BigInteger x)
		{
			if (Additions.EulerFunction(p) == p - 1 && 1 < x && x < p - 1)
			{
				P = p;
				X = x;
				BigInteger[] primalRoots = Additions.GetPrimitiveRoots(p);
				Random rand = new Random();
				G = primalRoots[rand.Next(0, primalRoots.Length)];
				Y = BigInteger.ModPow(G, X, P);
			}
			else
				throw new Exception("You loh");
		}

		public static ElGamalBlock HashEcryption(BigInteger hash, BigInteger P, BigInteger G, BigInteger X)
		{
			Random rand = new Random();

			
			int k = rand.Next(2, (int)P - 1);
			while (Additions.EuclidsAlgorithmOfTwo(k, P - 1) != 1)
				k = rand.Next(2, (int)P - 1);

			BigInteger a = BigInteger.ModPow(G, k, P);
			BigInteger b = ((hash - X * a) * Additions.GetReversedByModulo(k, P - 1)) % (P - 1);
			while (b < 0)
				b += (P - 1);

			return new ElGamalBlock(a, b);
		}

		public static bool HashDecryptionVerify(ElGamalBlock encrypted, BigInteger hash, BigInteger P, BigInteger G, BigInteger Y)
		{
			BigInteger b = encrypted.B;
			BigInteger a = encrypted.A;
			BigInteger left = (BigInteger.ModPow(Y, a, P) * BigInteger.ModPow(a, b, P)) % P;
			BigInteger right = BigInteger.ModPow(G, hash, P);
			return left == right;
		}

		public static ElGamalBlock[] Ecryption(string text, BigInteger P, BigInteger G, BigInteger Y)
		{
			List<ElGamalBlock> result = new List<ElGamalBlock>();
			Random rand = new Random();
			for (int i = 0; i < text.Length; i++)
			{
				int k = rand.Next(0, (int)P);
				BigInteger a = BigInteger.ModPow(G, k, P);
				BigInteger b = text[i] * BigInteger.Pow(Y, k) % P;
				result.Add(new ElGamalBlock(a, b));
			}
			return result.ToArray();
		}

		public static string Decryption(ElGamalBlock[] encrypted, BigInteger P, BigInteger X)
		{
			string result = "";
			for (int i = 0; i < encrypted.Length; i++)
			{
				BigInteger b = encrypted[i].B;
				BigInteger a = encrypted[i].A;
				result += (char)(b * BigInteger.Pow(a, (int)(P - X - 1)) % P);
			}
			return result;
		}

		public ElGamalBlock[] Ecryption(string text)
		{
			List<ElGamalBlock> result = new List<ElGamalBlock>();
			Random rand = new Random();
			for (int i = 0; i < text.Length; i++)
			{
				int k = rand.Next(0, (int)P);
				BigInteger a = BigInteger.ModPow(G, k, P);
				BigInteger b = text[i] * BigInteger.Pow(Y, k) % P;
				result.Add(new ElGamalBlock(a, b));
			}
			return result.ToArray();
		}

		public string Decryption(ElGamalBlock[] encrypted)
		{
			string result = "";
			for (int i = 0; i < encrypted.Length; i++)
			{
				BigInteger b = encrypted[i].B;
				BigInteger a = encrypted[i].A;
				result += (char)(b * BigInteger.Pow(a, (int)(P - X - 1)) % P);
			}
			return result;
		}
	}
}
