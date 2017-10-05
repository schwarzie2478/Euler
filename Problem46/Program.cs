using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;

namespace Problem46
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
                It was proposed by Christian Goldbach that every odd composite number can be written as 
                the sum of a prime and twice a square.

                9 = 7 + 2×1²
                15 = 7 + 2×2²
                21 = 3 + 2×3²
                25 = 7 + 2×3²
                27 = 19 + 2×2²
                33 = 31 + 2×1²

                It turns out that the conjecture was false.
                What is the smallest odd composite that cannot be written as the sum of a prime and twice a square?
        */
            int upperLimit = 10000;
            var primes = GetPrimes(upperLimit);
            var bFound = false;
            var result = -1;
            for (var i = 33; i < upperLimit && !bFound; i += 2)
            {
                if (primes.Get(i))
                {
                    //skip primes
                    continue;
                }
                int matchingPrime;
                //test all smaller primes for matches
                for (matchingPrime = i; matchingPrime > 1 ; matchingPrime -= 1)
                {
                    if (!primes.Get(matchingPrime)) continue;

                    //search matching square
                    var sq = 1;
                    var sum = matchingPrime + 2 * (long) Math.Pow(sq, 2);
                    while (sum < i)
                    {
                        //take next one
                        sq++;
                        sum = matchingPrime + 2 * (long)Math.Pow(sq, 2);
                    }
                    // if no solution was found --> found first
                    if (sum == i)
                    {
                        //Don't look further, has at least one solution
                        break;
                    }
                }
                if (matchingPrime == 1)
                {
                    bFound = true;
                    result = i;
                }
            }
            Console.WriteLine($"The result is {result}");
            Console.ReadLine();

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
