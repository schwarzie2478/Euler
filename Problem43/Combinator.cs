using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Microsoft.Win32.SafeHandles;

namespace Problem43
{
    internal class Combinator
    {

        public Combinator()
        {

        }

        public IEnumerable<long> Next()
        {
            List<int> sourceDigits = new List<int>();
            List<int> usedDigits = new List<int>();
            //Iterate from highest to lowest
            //Skip when Last digit is even
            for (int i = 0; i < 10; i++)
            {
                sourceDigits.Add(i);
            }


            foreach (var generateNumber in GenerateNumbers(sourceDigits,usedDigits))
            {
                Console.WriteLine(generateNumber);
                yield return generateNumber;
            }

        }

        private IEnumerable<long> GenerateNumbers(List<int> sourceDigitsStart, List<int> usedDigitsStart)
        {
            if (sourceDigitsStart.Count == 0)
            {
                yield return usedDigitsStart.ToNumber() ;
            }
            else
            {
                List<int> sourceDigits = new List<int>(sourceDigitsStart);
                List<int> usedDigits = new List<int>(usedDigitsStart);

                int length = sourceDigits.Count;
                int usedDigit = -1;
                for (int i = 0; i < length; i++)
                {
                    //Put previous back in sequence at the and
                    if (usedDigit != -1)
                    {
                        //Remove last used digit and add to source at the end
                        usedDigit = usedDigits.Last();
                        usedDigits.Remove(usedDigit);
                        sourceDigits.Add(usedDigit);
                    }

                    //Take the top of the Sequence
                    usedDigit = sourceDigits[0];
                    usedDigits.Add(sourceDigits[0]);
                    sourceDigits.RemoveAt(0);
                    if (!AreUsedDigitsValid(usedDigits))
                    {
                        //Not a valid solution
                        continue;
                    }
                    //Generate numbers with the rest
                    foreach (var total in GenerateNumbers(sourceDigits, usedDigits))
                    {
                        yield return  total;
                    }
                }
                usedDigit = usedDigits.Last();
                usedDigits.Remove(usedDigit);
                sourceDigits.Add(usedDigit);

            }
            

        }

        private bool AreUsedDigitsValid(List<int> usedDigits)
        {
            if (!IsPartDivisableBy(usedDigits, 1, 2)) return false;
            if (!IsPartDivisableBy(usedDigits, 2, 3)) return false;
            if (!IsPartDivisableBy(usedDigits, 3, 5)) return false;
            if (!IsPartDivisableBy(usedDigits, 4, 7)) return false;
            if (!IsPartDivisableBy(usedDigits, 5, 11)) return false;
            if (!IsPartDivisableBy(usedDigits, 6, 13)) return false;
            if (!IsPartDivisableBy(usedDigits, 7, 17)) return false;
            return true;
        }

        private bool IsPartDivisableBy(List<int> usedDigits, int index,int prime)
        {
            if (usedDigits.Count > index + 2)
            {
                //Check if d2d3d4 is divisble by 2
                if (usedDigits.GetRange(index, 3).ToNumber() % prime != 0)
                {
                    //Console.WriteLine($"{usedDigits.ToNumber()} is not good");
                    return false;
                }
            }
            return true;
        }
    }

    internal static class CombinatorHelper
    {
        internal static long ToNumber(this List<int> numbers)
        {
            int total = 0;
            foreach (var number in numbers)
            {
                total = 10 * total + number;
            }
            return total;
        }
    }
}