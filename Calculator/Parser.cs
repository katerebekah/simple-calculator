using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class Parser
    {
        public Parser(string input)
        {
            this.input = input;
            cursorCount++;
            GenerateResponse();
        }

        public static int cursorCount;

        public int result { get; set; }
        public string input { get; set; }
        public string response { get; set; }

        public void GenerateResponse()
        {
            if (input.Contains("="))
            {

            } else if (input == "quit" || input == "exit") {
                this.response = "Goodbye. Thanks for using my calculator.";
            } else if (input == "last")
            {
                //the response stays the same
            }
            
            else
            {
                var calc = new Calculate(input);
                this.result = calc.getResult();
                this.response = this.result.ToString();
            }
            
        }
    }
}
