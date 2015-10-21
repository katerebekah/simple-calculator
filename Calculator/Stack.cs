using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public static class Stack
    {
        public static string lastQuestion { get; set; }
        public static string lastResponse { get; set; }
        public static Dictionary<string, int> Constants = new Dictionary<string, int>();


        public static int[] ReplaceConstsandStringsWithIntValues(string[] inputs)
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
                        throw new ArgumentException("You can't use a variable that hasn't been initialized. You need to set the value equal to something before you call on it.");
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
