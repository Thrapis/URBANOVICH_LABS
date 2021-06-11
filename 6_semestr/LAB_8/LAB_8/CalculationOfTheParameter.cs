using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace LAB_8
{
	public static class CalculationOfTheParameter
	{
		public static string GetSatistics()
		{
			string result = "";

			Random rand = new Random();
			BigInteger a = rand.Next(5, 36);

			result += "y\t|\ta\t|\tx\t|\tn\t|\tTime\n";

			BigInteger[] narr = new BigInteger[] { GenerateRandomNumber(2, 1024), GenerateRandomNumber(2, 2048) };
			BigInteger[] xarr = new BigInteger[]
			{
				GenerateRandomNumber(10, 3),
				GenerateRandomNumber(10, 7),
				GenerateRandomNumber(10, 13),
				GenerateRandomNumber(10, 23),
				GenerateRandomNumber(10, 37),
				GenerateRandomNumber(10, 48),
				GenerateRandomNumber(10, 66),
				GenerateRandomNumber(10, 72),
				GenerateRandomNumber(10, 90),
				GenerateRandomNumber(10, 100)
			};
			
			for (int j = 0; j < 2; j++)
			{
				BigInteger n = narr[j];
				string ns = "";
				if (j == 0)
					ns = "2^1024";
				else
					ns = "2^2048";

				for (int i = 0; i < 10; i++)
				{
					BigInteger x = GenerateRandomNumber(10, rand.Next(3, 10));

					DateTime dateTime1 = DateTime.Now;
					BigInteger y = BigInteger.ModPow(a, x, n);
					DateTime dateTime2 = DateTime.Now;
					string xs = "";
					switch (i)
                    {
						case 0: xs = "10^3"; break;
						case 1: xs = "10^7"; break;
						case 2: xs = "10^13"; break;
						case 3: xs = "10^23"; break;
						case 4: xs = "10^37"; break;
						case 5: xs = "10^48"; break;
						case 6: xs = "10^66"; break;
						case 7: xs = "10^72"; break;
						case 8: xs = "10^90"; break;
						case 9: xs = "10^100"; break;
                    }
					
					string ys = y.ToString().Length > 4 ? y.ToString().Substring(0, 4) + "..." : y.ToString();
					
					result += $"{ys}\t" +
						$"|\t{a}\t" +
						$"|\t{xs}\t" +
						$"|\t{ns}\t" +
						$"|\t{(dateTime2 - dateTime1).Ticks} ns\n";
					Console.WriteLine("Done");
				}
				
			}

			return result;
		}

		public static BigInteger GenerateRandomNumber(int fromBase, int digits)
		{
			BigInteger result = 0;
			Random rand = new Random();
			for (int i = 0; i < digits; i++)
			{
				result += BigInteger.Pow(fromBase, i) * rand.Next(0, fromBase);  
			}
			result += BigInteger.Pow(2, digits) * rand.Next(1, fromBase);
			return result;
		}
	}
}
