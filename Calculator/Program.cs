using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello! Welcome to my Calculator. What would you like me to Calculate?");
            var input = Console.ReadLine();
            var p = new Parser(input);
            Console.WriteLine(p.getResult());
            Console.ReadLine();
        }
    }
}
