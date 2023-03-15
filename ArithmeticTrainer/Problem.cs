using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArithmeticTrainer
{
    public class Problem
    {
        public const string ADDITION_SYMBOL = "+";
        public const string SUBTRACTION_SYMBOL = "-";
        public const string MULTIPLICATION_SYMBOL = "×";
        public const string DIVISION_SYMBOL = "÷";

        public int LHS { get; set; }
        public int RHS { get; set; }

        public Operation Op { get; set; }

        public decimal Solution { get; set; }
        
        public string GetProblemStatement()
        {
            string opString;
            switch (Op)
            {
                case Operation.ADDITION:
                    opString = ADDITION_SYMBOL;
                    break;
                case Operation.SUBTRACTION:
                    opString = SUBTRACTION_SYMBOL;
                    break;
                case Operation.MULTIPLICATION:
                    opString = MULTIPLICATION_SYMBOL;
                    break;
                case Operation.DIVISION:
                    opString = DIVISION_SYMBOL;
                    break;
                default:
                    throw new ArgumentException($"Unsupported operation: {Op}");
            }

            return $"{LHS} {opString} {RHS} = ";
        }
    }
}
