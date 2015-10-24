using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class Calc
    {
        public Calc(IEnumerable<ICalculator> Calculators)
        {
            AddCalculatorsToDictionary(Calculators);
        }

        Dictionary<char, ICalculator> Calcs = new Dictionary<char, ICalculator>();

        void AddCalculatorsToDictionary(IEnumerable<ICalculator> Calculators)
        {
            foreach (var cal in Calculators)
            {
                Calcs.Add(cal.Operator, cal);
            }
        }

        public int Calculator(int first, int second, char oper)
        {
            ICalculator Calculate = Calcs[oper];
            return Calculate.Calculate(first, second);
        }
    }
}
