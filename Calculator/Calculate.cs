using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class Calculate
    { 
        public Calculate(string initialInput)
        {
            staticInput = initialInput;
            Counter++;
            ParseInput(staticInput);
        }
        string staticInput { get; set; }
        public static string response { get; set; }

        public static int Counter;
        void ParseInput(string input)
        {
            var p = new Parser(input);
            try
            {
                p.ParseInput();
                var results = p.results;
                char operand = p.operand;
                response = CalculateResponse(results, operand);

                Stack.lastResponse = response;
                Stack.lastQuestion = staticInput;
            }
            catch (ArgumentException e)
            {
                response = e.Message;
                return;
            }
        }
        string CalculateResponse(int[] results, char operand)
        {
            switch (operand)
            {
                case ('='):
                    return String.Format("{0} has been added.", staticInput);
                case ('+'):
                    return (results[0] + results[1]).ToString();
                case ('-'):
                    return (results[0] - results[1]).ToString();
                case ('/'):
                    return (results[0] / results[1]).ToString();
                case ('*'):
                    return (results[0] * results[1]).ToString();
                case ('%'):
                    return (results[0] % results[1]).ToString();
                default:
                    throw new ArgumentException("I'm sorry, there was an error.");
            }
        }
    }
}
