using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Problem47
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
                The first two consecutive numbers to have two distinct prime factors are:
                14 = 2 × 7
                15 = 3 × 5
                The first three consecutive numbers to have three distinct prime factors are:
                644 = 2² × 7 × 23
                645 = 3 × 5 × 43
                646 = 2 × 17 × 19.
                Find the first four consecutive integers to have four distinct prime factors each. What is the first of these numbers?
            */
            bool bFound = false;
            int consecutiveNumbersFound = 0;
            int currentInteger = 629; //2*3*5*7 smallest possible number with 4 distinct factors
            var primes = GetPrimes(1000000);
            while (!bFound)
            {
                //Take next integer
                currentInteger++;

                int distinctFactors = DetermineDistinctFactors(primes, currentInteger);
                if (distinctFactors != 4)
                {
                    consecutiveNumbersFound = 0;
                    continue;
                }

                consecutiveNumbersFound++;
                if (consecutiveNumbersFound == 4)
                {
                    bFound = true;
                }
            }
            Console.WriteLine($"Last number of sequence found is {currentInteger}");

        }

        private static int DetermineDistinctFactors(BitArray primes, int currentInteger)
        {
            //SearchStart
            int startingPoint = (int) Math.Floor(Math.Pow(currentInteger, 0.5));
            var factors = new HashSet<int>();
            int remainder = currentInteger;
            for (int i = startingPoint; i > 1; i--)
            {
                if (!primes.Get(i)) continue;

                if (remainder % i != 0) continue;
                while (remainder % i == 0)
                {
                    remainder /= i;
                }
                factors.Add(i);
            }
            if (primes.Get(remainder))
            {
                factors.Add(remainder);
            }

            return factors.Count;

        }

        public static BitArray GetPrimes(int upperLimit)
        {
            var primes = new BitArray(upperLimit);
            primes.SetAll(true);
            primes.Set(0, false);
            primes.Set(1, false);
            for (int i = 0; i * i < upperLimit; i++)
            {
                if (primes.Get(i))
                {
                    for (int j = i * i; j < upperLimit; j += i)
                    {
                        primes.Set(j, false);
                    }
                }
            }
            return primes;
        }
    }
}
