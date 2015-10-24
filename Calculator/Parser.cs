using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Calculator
{
    public class Parser
    {
        public Parser() { }
        char[] operands = { '+', '-', '*', '/', '%', '=' };
        public char operand { get; set; }

        public int[] Parse(string input)
        {
            input = Regex.Replace(input, @"\s+", "").ToLower();
            var stringArr = SplitOnOperand(input);
            if (operand == '=')
            {
                AddKeyValuePair(stringArr);
                throw new ArgumentException(String.Format("{0} has been added to the dictionary.", input));
            }
            else
            {
                return parseStringArrToIntArr(stringArr);
            }
        }

        public int[] parseStringArrToIntArr(string[] inputs)
        {
            var values = new int[2];
            for (var i = 0; i < inputs.Length; i++)
            {
                int result;
                if (!int.TryParse(inputs[i], out result))
                {
                    values[i] = findConstantInDictionary(inputs[i]);
                }
                else
                {
                    values[i] = result;
                }
            }
            return values;
        }

        public int findConstantInDictionary(string constant)
        {
            if (Stack.Constants.ContainsKey(constant))
            {
                return Stack.Constants[constant];
            }
            else
            {
                throw new ArgumentException("You can't use a variable that hasn't been initialized. You need to set the value equal to something before you call on it.");
            }
        }

        public string[] SplitOnOperand(string input)
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
                throw new ArgumentException("Invalid input. There's a number of very good reasons why this failed. Your number is too big, you didn't put your variable first, you're using a two variables you haven't instantiated, etc.");
            }
        }

       
    }
}
