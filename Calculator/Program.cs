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
            Console.WriteLine("Welcome to the Kate-tastic Calculator. Begin.");
            bool keepGoing = true;
            while (keepGoing)
            {
                Console.Write(String.Format("[{0}]>", Calculate.Counter));
                var input = Console.ReadLine().ToLower();
                if(input == "quit" || input == "exit")
                {
                    keepGoing = false;
                    break;
                } else if (input == "lastq")
                {
                    Console.WriteLine(Stack.lastQuestion);
                }
                else if (input == "last")
                {
                    Console.WriteLine(Stack.lastResponse);
                }
                else
                {
                    var c = new Calculate(input);
                    Console.WriteLine(Calculate.response);
                }

            }
        }
    }
}
