using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class Parser
    {
        string input;
        public Parser(string input)
        {
            this.input = input;
        }
        char[] operands = { '+', '-', '*', '/', '%', '=' };
        public char operand { get; set; }
        public static Dictionary<string, int> Constants = new Dictionary<string, int>();
        public int[] results { get; set; }

        public void ParseInput()
        {
            var stringArr = SplitOnOperand();
            if (operand == '=')
            {
                AddKeyValuePair(stringArr);
            }
            else
            {
                this.results = ReplaceConstsandStringsWithIntValues(stringArr);
            }
        }


        public string[] SplitOnOperand()
        {
            foreach (char o in operands)
            {
                if (input.Contains(o))
                {
                    var values = input.Split(o);
                    this.operand = o;

                    if (values.Length > 2)
                    {
                        throw new ArgumentException("You can't use more than one operand per statement.");
                    }

                    else if (  values[0] == "" || values[1] == "")
                    {
                        throw new ArgumentException("You can't operate without two values, asshat.");
                    }
                    else
                    {
                        foreach (string val in values)
                        {
                            foreach (char c in operands)
                            {
                                if (val.Contains(c))
                                {
                                    throw new ArgumentException("You can't have more than one operand per statement.");
                                }
                            }
                        }
                        return values;
                    }
                }

            }
            throw new ArgumentException("There's not an operand in this input");
        }

        public void AddKeyValuePair(string[] values)
        {
            int result;
            if (int.TryParse(values[1], out result))
            {
                if (values[0].Length == 1)
                {
                    if (!Constants.ContainsKey(values[0]))
                    {
                        Constants.Add(values[0], int.Parse(values[1]));
                        return;
                    }
                    else
                    {
                        throw new ArgumentException("You can't change a constant's values after it has been initialized.");
                    }
                }
                else
                {
                    throw new ArgumentException("Variables can only be one character.");

                }
            }
            else
            {
                throw new ArgumentException("Invalid variable type. Variables must come first in an expression.");
            }
        }

        public int[] ReplaceConstsandStringsWithIntValues(string[] inputs)
        {
            var values = new int[2];
            for (var i = 0; i < inputs.Length; i++) 
            {
                int result;
                if (!int.TryParse(inputs[i], out result))
                {
                    if (Constants.ContainsKey(inputs[i]))
                    {
                       values[i] = Constants[inputs[i]];
                    }
                    else
                    {
                        throw new ArgumentException("You can't use a variable that hasn't been initialized.");
                    }
                }
                else
                {
                    values[i] = result;
                }
            }
            return values;
        }
    }
}
