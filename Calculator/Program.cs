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
            bool keepgoing = true;
            int Counter = 0;

            var CalcList = new List<ICalculator>();
            CalcList.Add(new Add());
            CalcList.Add(new Subtract());
            CalcList.Add(new Multiply());
            CalcList.Add(new Divide());
            CalcList.Add(new Modulus());

            var c = new Calc(CalcList);
            var p = new Parser();
            while (keepgoing)
            {
                Console.Write(String.Format("[{0}]>", Counter));
                var input = Console.ReadLine();
                
                string response = "";
                try {
                    int[] values = p.Parse(input);
                    char op = p.operand;
                    response = c.Calculator(values[0], values[1], op).ToString();
                }
                catch (Exception e)
                {
                    response = e.Message;
                }
                Console.WriteLine(response);
                Counter += 1;
            }
            
        }
            
    }
}
