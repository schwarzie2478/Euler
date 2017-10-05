using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Win32.SafeHandles;

namespace Problem50
{
    internal class Combinator
    {
        private int v;

        public Combinator(int v)
        {
            this.v = v;
        }

        public IEnumerable<int> Next()
        {
            //Iterate from highest to lowest
            //Skip when Last digit is even
            var digits = new List<Int32>();
            var pickedDigits = new List<int>();
            for (int i = v; i > 0; i--)
            {
                digits.Add(i);
            }


            foreach (var generateNumber in PickNumbers(digits,pickedDigits))
            {
                yield return generateNumber;
            }

        }

        private IEnumerable<int> PickNumbers(List<int> tempdigist, List<int> pickedDigits)
        {
            if (pickedDigits.Count == 4)
            {
                yield return pickedDigits.ToNumber();
            }
            else
            {
                for (int i = 1; i < v; i++)
                {
                    
                }



            }

        }
    }

    internal static class CombinatorHelper
    {
        internal static int ToNumber(this List<int> pickedDigits)
        {
            int total = 0;
            foreach (var pickedDigit in pickedDigits)
            {
                total = total * 10 + pickedDigit;
            }
            return total;
        }

    }
}