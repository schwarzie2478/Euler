using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Win32.SafeHandles;

namespace Problem41
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
            for (int i = v; i > 0; i--)
            {
                digits.Add(i);
            }


            foreach (var generateNumber in GenerateNumbers(digits))
            {
                yield return generateNumber;
            }

        }

        private IEnumerable<int> GenerateNumbers(List<int> tempdigist)
        {
            if (tempdigist.Count == 1)
            {
                yield return tempdigist[0];
            }
            else
            {
                int ordinal = 0;
                int length = tempdigist.Count;
                int rank = (int) Math.Pow(10, length -1);

                for (int i = 0; i < length; i++)
                {
                    //Put previous back in sequence at the and
                    if (ordinal != 0)
                        tempdigist.Add(ordinal);
                    //Take the top of the Sequence
                    ordinal = tempdigist[0];
                    tempdigist.RemoveAt(0);
                    //Generate numbers with the rest
                    foreach (var total in GenerateNumbers(tempdigist))
                    {
                        if (total % 2 == 0)
                            continue;
                        yield return rank * ordinal + total;
                    }
                }
                tempdigist.Add(ordinal);

            }

        }
    }
}