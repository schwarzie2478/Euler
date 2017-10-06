using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project50
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
                The prime 41, can be written as the sum of six consecutive primes:

                41 = 2 + 3 + 5 + 7 + 11 + 13
                This is the longest sum of consecutive primes that adds to a prime below one-hundred.

                The longest sum of consecutive primes below one-thousand that adds to a prime, contains 21 terms, and is equal to 953.

                Which prime, below one-million, can be written as the sum of the most consecutive primes?
            */
            var primes = GetPrimes(1000000);
            var maxTermsFound = -1;
            var primeFound = -1;
            var lastPrimeInSequence = -1;
            for (int i = 999999; i > 100; i--)
            {
                if (!primes.Get(i)) continue;

                //Search sums of consecutive primes, starting from 2
                int limit = i / 2;
                for (int j = 2; j < limit; j++)
                {
                    if (primeFound == i) break;
                    if (!primes.Get(j)) continue;
                    int remainder = i;
                    int termsUsed = 0;
                    for (int k = j; k < limit; k++)
                    {
                        if (!primes.Get(k)) continue;
                        remainder -= k;
                        termsUsed++;
                        if (remainder == 0)
                        {
                            if (termsUsed > maxTermsFound)
                            {
                                maxTermsFound = termsUsed;
                                primeFound = i;
                                lastPrimeInSequence = k;
                            }
                            break;
                        }
                        if (remainder < 0)
                        {
                            break;
                        }
                    }
                }
            }
            Console.WriteLine($"Prime {primeFound} has {maxTermsFound} terms, last one was {lastPrimeInSequence}");
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
