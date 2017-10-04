using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem41
{
    class Program
    {
        static void Main(string[] args)
        {
            //Search for largest in all Possibilities for pandigital n-digit primes 
            // n > 9 not enough digits
            // n = 9, 8 always divisable by 3!
            // start at n= 7!
            // n= 6 divisable by 3
            // n = 5 diviable by 3
            // n = 3,2,1 we have an example for n=4 already given 2143

            var comb = new Combinator(7);
            foreach (var i in comb.Next())
            {
                if (IsPrime(i))
                {
                    Console.WriteLine(i);
                    break;
                }
            }
            Console.ReadLine();
        }
        
        public static bool IsPrime(int number)
        {
            if (number == 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;

            var boundary = (int)Math.Floor(Math.Sqrt(number));

            for (int i = 3; i <= boundary; i += 2)
            {
                if (number % i == 0) return false;
            }

            return true;
        }

    }
}
