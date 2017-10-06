using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem49
{
    class Program
    {
        static void Main(string[] args)
        {
            var primes = GetPrimes(10000);
            bool bFound = false;
            int result = -1;
            for(int i = 1235; i < 9876;i++)
            {
                if (!primes.Get(i)) continue;

                //Others
                int digit1 = i % 10;
                int remainder = i / 10;
                int digit2 = remainder % 10;
                remainder /= 10;
                int digit3 = remainder % 10;
                int digit4 = remainder / 10;
                var combinations = new List<int>();
                if (digit1 == 0 || digit2 == 0 || digit3 == 0 || digit4 == 0) continue;

                combinations.Add(MakeNumber(digit1, digit2, digit4, digit3));
                combinations.Add(MakeNumber(digit1, digit2, digit3, digit4));
                combinations.Add(MakeNumber(digit1, digit3, digit2, digit4));
                combinations.Add(MakeNumber(digit1, digit3, digit4, digit2));
                combinations.Add(MakeNumber(digit1, digit4, digit2, digit3));
                combinations.Add(MakeNumber(digit1, digit4, digit3, digit2));

                combinations.Add(MakeNumber(digit2, digit1, digit3, digit4));
                combinations.Add(MakeNumber(digit2, digit1, digit4, digit3));
                combinations.Add(MakeNumber(digit2, digit3, digit4, digit1));
                combinations.Add(MakeNumber(digit2, digit3, digit1, digit4));
                combinations.Add(MakeNumber(digit2, digit4, digit3, digit1));
                combinations.Add(MakeNumber(digit2, digit4, digit1, digit3));

                combinations.Add(MakeNumber(digit3, digit1, digit2, digit4));
                combinations.Add(MakeNumber(digit3, digit1, digit4, digit2));
                combinations.Add(MakeNumber(digit3, digit2, digit4, digit1));
                combinations.Add(MakeNumber(digit3, digit2, digit1, digit4));
                combinations.Add(MakeNumber(digit3, digit4, digit2, digit1));
                combinations.Add(MakeNumber(digit3, digit4, digit1, digit2));

                combinations.Add(MakeNumber(digit4, digit1, digit3, digit2));
                combinations.Add(MakeNumber(digit4, digit1, digit2, digit3));
                combinations.Add(MakeNumber(digit4, digit3, digit2, digit1));
                combinations.Add(MakeNumber(digit4, digit3, digit1, digit2));
                combinations.Add(MakeNumber(digit4, digit2, digit3, digit1));
                combinations.Add(MakeNumber(digit4, digit2, digit1, digit3));

                if(combinations.Where(p => primes.Get(p)).Count() >=3)
                {
                    List<int> results = combinations.Where(p => primes.Get(p)).ToList();
                    results.Sort();
                    for (int k = 0; k < results.Count-1; k++)
                    {
                        
                        for (int j = k + 1; j < results.Count; j++)
                        {
                            int diff = results[j] - results[k];
                            if (diff == 0) continue;
                            for (int l = j + 1; l < results.Count; l++)
                            {
                                if (results[l] == results[k] + 2 * diff)
                                {
                                    bFound = true;
                                    break;
                                }

                            }

                        }
                    }
                    result = results[0];
                }


            }
            Console.WriteLine($"The result is {result}");
            Console.ReadLine();
        }

        private static int MakeNumber(int digit1, int digit2, int digit3, int digit4)
        {
            return ((((digit1 * 10) + digit2) * 10 + digit3) * 10) + digit4;
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
