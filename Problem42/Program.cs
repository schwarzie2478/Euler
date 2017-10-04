using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem42
{
    class Program
    {
        static void Main(string[] args)
        {
            int counter = 0;
            //ReadFile
            string line = System.IO.File.ReadAllText("p042_words.txt");
            string[] lines = line.Replace("\"", "").Split(',');
            foreach (var readLine in lines)
            {
                int number = Calcuate(readLine.ToLower());
                var generator = new TriangleNumberGenerator(number + 1);
                if (generator.Next().Any(i => i == number))
                {
                    counter++;
                }
            }
            Console.WriteLine(counter);
            Console.ReadLine();
        }

        private static int Calcuate(string readLine)
        {
            int total = 0;
            foreach (var letter in readLine.ToCharArray())
            {
                total += (int) letter - (int)'a' + 1;
            }
            return total;
        }
    }
}
