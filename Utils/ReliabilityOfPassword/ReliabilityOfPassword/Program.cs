using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReliabilityOfPassword
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] N = { 26, 26, 52, 52, 52, 100, 100, 100 };
            double[] S = { 2, 8, 2, 8, 10, 2, 8, 10 };
            double[] T = { 1, 7, 30, 360 };

            Console.WriteLine($"N\tS\tT\tP_0");
            Console.WriteLine($"------------------------------");
            for (int i = 0; i < N.Length; i++)
            {
                for (int j = 0; j < T.Length; j++)
                {
                    double P_0 = T[j] * 24 * 60 * 100_000_000 / ((8 * S[i] + 144) * Math.Pow(N[i], S[i]));
                    Console.WriteLine($"{N[i]}\t{S[i]}\t{T[j]}\t{P_0}");
                }
                Console.WriteLine("---------------------------------------------");
            }
            Console.ReadLine();
        }
    }
}
