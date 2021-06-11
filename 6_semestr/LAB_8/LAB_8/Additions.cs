using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LAB_8
{
	public static class Additions
	{
		public static string ToStringArray(this BigInteger[] bigIntegers)
		{
			string result = "";
			for (int i = 0; i < bigIntegers.Length; i++)
			{
				result += $"[{bigIntegers[i]}]\r\n";
			}
			return result;
		}

		public static string ToStringArray(this ElGamalBlock[] elGamalBlocks)
		{
			string result = "";
			for (int i = 0; i < elGamalBlocks.Length; i++)
			{
				result += "{["+elGamalBlocks[i].A +
					"][" + elGamalBlocks[i].B + "]}\r\n";
			}
			return result;
		}

		public static BigInteger EuclidsAlgorithmOfTwo(BigInteger a, BigInteger b)
		{
			BigInteger q = 0;
			BigInteger r = 0;

			do
			{
				if (a > b)
				{
					q = a / b;
					r = a - b * q;
					if (r == 0)
						return b;
					a = r;
				}
				else
				{
					q = b / a;
					r = b - a * q;
					if (r == 0)
						return a;
					b = r;
				}
			} while (r != 0);
			return a;
		}

		public static BigInteger EulerFunction(BigInteger n)
		{
			BigInteger num = n;
			List<BigInteger> delimeters = new List<BigInteger>();

			BigInteger buf = BigInteger.Parse(n.ToString());
			while (buf != 1)
			{
				for (BigInteger i = 2; i <= buf; i++)
				{
					if (buf % i == 0)
					{
						buf /= i;
						if (!delimeters.Contains(i))
							delimeters.Add(i);
						break;
					}
				}
			}

			for (int i = 0; i < delimeters.Count; i++)
			{
				num /= delimeters[i];
				num *= (delimeters[i] - 1);
			}

			return num;
		}

		public static BigInteger[] Factorize(BigInteger p)
        {
			List<BigInteger> result = new List<BigInteger>();

			BigInteger p_copy = p;

			for (int i = 2; i <= p_copy; i++)
            {
				if (p_copy == 1)
					break;

				if (p_copy % i == 0)
                {
					p_copy /= i;
					if (!result.Contains(i))
						result.Add(i);
					i--;
                }
            }

			return result.ToArray();
		}

		public static BigInteger Bezu(BigInteger a, BigInteger b, out BigInteger x, out BigInteger y)
		{
			if (b < a)
			{
				BigInteger t = a;
				a = b;
				b = t;
			}

			if (a == 0)
			{
				x = 0;
				y = 1;
				return b;
			}

			BigInteger gcd = Bezu(b % a, a, out x, out y);

			BigInteger newY = x;
			BigInteger newX = y - (b / a) * x;

			x = newX;
			y = newY;
			return gcd;
		}

		public static BigInteger GetReversedByModulo(BigInteger a, BigInteger modulo)
		{
			BigInteger x = 0;
			BigInteger y = 0;
			Bezu(a, modulo, out x, out y);

			BigInteger reva = x;
			while (reva < 0)
				reva += modulo;

			return reva;
		}
	
		public static BigInteger[] GetPrimitiveRoots(BigInteger p)
        {
			List<BigInteger> result = new List<BigInteger>();

			BigInteger euler = EulerFunction(p);
			BigInteger[] factorizes = Factorize(euler);

			List<BigInteger> powers = new List<BigInteger>();
			for (int i = 0; i < factorizes.Length; i++)
			{
				powers.Add(euler / factorizes[i]);
			}

			for (BigInteger i = 2; i < euler; i++)
            {
				bool isResidRoot = false;
				if (EuclidsAlgorithmOfTwo(i, p) == 1)
                {
					isResidRoot = true;
					for (int j = 0; j < powers.Count; j++)
                    {
						if (BigInteger.ModPow(i, powers[j], p) == 1)
                        {
							isResidRoot = false;
							break;
						}
                    } 
                }
				if (isResidRoot)
					result.Add(i);
            }

			return result.ToArray();
        }
	}
}
