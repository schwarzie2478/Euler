using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Problem28
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * ¹²³⁴⁵⁶⁷⁸⁹⁰
                The series, 1¹ + 2² + 3³ + ... + 10¹⁰ = 10405071317.
                Find the last ten digits of the series, 11 + 22 + 33 + ... + 10001000.
            */
            // n * 10 + n * 

            BigInteger sum = 0;
            sum += GetValue(1, 1000);
            //sum += GetValue(10, 100);
            //sum += GetValue(100, 1000);
            //sum += 10001000;

            string result = String.Concat(sum.ToString().ToCharArray().Reverse().Take(10).Reverse().ToList());

            Console.WriteLine($"Last digits : {result}");
            Console.ReadLine();
        }

        private static BigInteger GetValue(int start, int stop)
        {
            BigInteger sum = 0;
            for (int i = start; i <= stop; i++)
            {
                sum += BigInteger.Pow(i, i);
            }
            return sum;
        }
    }
}
