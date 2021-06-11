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
			if (Additions.EulerFunction(p) == p - 1 && 0 <= x && x < p)
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
