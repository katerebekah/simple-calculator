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
            parseComponents(input);


        }

        public int firstNumeral { get; set; }
        public int secondNumeral { get; set; }
        public char operand { get; set; }
        public int result { get; set; }

        public void parseComponents( string input)
        {
            string result = "";
            int number;
            foreach (char c in input)
            {
                if ("*/+-".Contains(c))
                {
                    operand = c;
                    int.TryParse(result, out number);
                    firstNumeral = number;
                    result = "";
                }
                else
                {
                    result = String.Format("{0}{1}", result, c);
                }
            }
            int.TryParse(result, out number);
            secondNumeral = number;
        }
        
    }
}
