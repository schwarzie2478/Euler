using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Project51
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
                By replacing the 1st digit of the 2-digit number *3, it turns out that six of the nine possible values: 13, 23, 43, 53, 73, and 83, are all prime.
                By replacing the 3rd and 4th digits of 56**3 with the same digit, this 5-digit number is the first example having seven primes among the ten generated numbers, yielding the family: 56003, 56113, 56333, 56443, 56663, 56773, and 56993. Consequently 56003, being the first member of this family, is the smallest prime with this property.
                Find the smallest prime which, by replacing part of the number (not necessarily adjacent digits) with the same digit, is part of an eight prime value family.
            */
            var primes = GetPrimes(10000000);
            bool bFound = true;
            int foundPrime = -1;
            for (int i = 100000; i < 1000000; i++)
            {
                if (!primes.Get(i)) continue;

                var matchPatterns = new Dictionary<string, HashSet<int>>();
                for (int j = i + 1; j < 1000000; j++)
                {
                    if (!primes.Get(j)) continue;
                    var match = Match(i, j);
                    if (match != "")
                    {
                        if (!matchPatterns.ContainsKey(match))
                        {
                            matchPatterns.Add(match,new HashSet<int>());
                        }
                        matchPatterns[match].Add(i);
                        matchPatterns[match].Add(j);
                        if (matchPatterns[match].Count >= 8)
                        {
                            bFound = true;
                            foundPrime = matchPatterns[match].Min();
                        }
                    }
                }
            }
            Console.WriteLine($"Found smallest prime {foundPrime}");
            Console.ReadLine();

        }

        public static string Match(int i, int j)
        {
            var iNumber = i.ToString().ToCharArray();
            var jNumber = j.ToString().ToCharArray();
            int differenceDigitOniString = -1;
            int differenceDigitOnjString = -1;
            var bld = new StringBuilder();
            for(int k = 0; k < iNumber.Length; k++)
            {
                if (iNumber[k] == jNumber[k])
                {
                    bld.Append(iNumber[k]);
                }
                else
                {
                    bld.Append('*');
                    if (differenceDigitOniString == -1) differenceDigitOniString = iNumber[k];
                    if (differenceDigitOnjString == -1) differenceDigitOnjString = jNumber[k];

                    if (differenceDigitOniString != iNumber[k] || differenceDigitOnjString != jNumber[k])
                    {
                        return "";
                    }
                }

            }

            return bld.ToString();
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
