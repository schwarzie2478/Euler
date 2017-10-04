using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem43
{
    class Program
    {
        static void Main(string[] args)
        {
            //Sum all numbers of pan-digits0-9 that comply to divisibility of sub groups
            long total = 0;

            var combinator = new Combinator();
            Console.WriteLine(combinator.Next().Sum());
            Console.ReadLine();
        }
    }
}
