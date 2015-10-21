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
                this.results = Stack.ReplaceConstsandStringsWithIntValues(stringArr);
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
                        throw new ArgumentException("You can't use more than one operand per statement. Do I ask you to do two things at once?");
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
            throw new ArgumentException("There's not an operand in this input. What exactly am I supposed to do with this??");
        }

        public void AddKeyValuePair(string[] values)
        {
            int result;
            if (int.TryParse(values[1], out result))
            {
                if (values[0].Length == 1)
                {
                    if (!Stack.Constants.ContainsKey(values[0]))
                    {
                        Stack.Constants.Add(values[0], int.Parse(values[1]));
                        return;
                    }
                    else
                    {
                        throw new ArgumentException("You can't change the value of a variable. They're not phoenixes being reborn from the ashes of your last calculation.");
                    }
                }
                else
                {
                    throw new ArgumentException("Variables can only be one character. Because MATH.");

                }
            }
            else
            {
                throw new ArgumentException("Invalid variable type. Variables must come first in an expression. I know it's dumb, but this is my rodeo.");
            }
        }

       
    }
}
