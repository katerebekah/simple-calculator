using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Kate-tastic Calculator. Begin.");
            bool keepGoing = true;
            while (keepGoing)
            {
                Console.Write(String.Format("[{0}]>", Calculate.Counter));
                var input = Regex.Replace(Console.ReadLine().ToLower(), @"\s+", "");
                var c = new Calculate(input);
                if (Calculate.response == "goodbye, fool")
                {
                    keepGoing = false;
                }
                Console.WriteLine(Calculate.response);

            }
        }
    }
}
