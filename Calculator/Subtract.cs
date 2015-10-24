using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class Subtract : ICalculator
    {
        public int Calculate(int first, int second)
        {
            return first - second;
        }
        public char Operator
        {
            get { return '-'; }
        }
    }
}
