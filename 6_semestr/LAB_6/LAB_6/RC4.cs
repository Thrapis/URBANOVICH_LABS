using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_6
{
	public class RC4
	{
		public int[] S { get; private set; }
		public int[] SReserve { get; private set; }
		public int I { get; private set; }
		public int J { get; private set; }
		public int N { get; private set; }
		public int Mod { get; private set; }

		public RC4(int n, params int[] secretKeys)
		{
			N = n;
			Mod = (int)Math.Pow(2, n);
			S = new int[Mod];
			int[] SK = new int[Mod];
			for (int i = 0; i < S.Length; i++)
			{
				S[i] = i;
				SK[i] = secretKeys[i % secretKeys.Length];
			}
			for (int i = 0, j = 0; i < Mod; i++)
			{
				j = (j + S[i] + SK[i]) % Mod;
				Swap(S, i, j);
			}
			SReserve = new int[Mod];
			S.CopyTo(SReserve, 0);
		}

		public void Reset()
		{
			I = 0;
			J = 0;
			SReserve.CopyTo(S, 0);
		}

		public string Crypt(string text)
        {
			List<char> crypted = new List<char>();
			for (int i = 0; i < text.Length; i++)
            {
				crypted.Add((char)(text[i] ^ GetNext()));
            }
			return new string(crypted.ToArray());
        }

		public int GetNext()
        {
			I = (I + 1) % Mod;
			J = (J + S[I]) % Mod;
			Swap(S, I, J);
			int a = (S[I] + S[J]) % Mod;
			return S[a];
		}

		public string GetNextBits() => GetBits(GetNext(), N);

		public static string GetBits(int x, int bitsCount) => Convert.ToString(x, 2).PadLeft(bitsCount, '0');

		private static void Swap(int[] arr, int i, int j) => (arr[i], arr[j]) = (arr[j], arr[i]);
	}
}
