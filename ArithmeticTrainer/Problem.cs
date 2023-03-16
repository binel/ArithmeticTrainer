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
        
        public DateTime AskedAt { get; set; }

        public DateTime AnsweredAt { get; set; }

        public string Answer { get; set; }

        public bool AnsweredCorrectly { get; set; }
        
        public TimeSpan GetAnswerDelay()
        {
            return AnsweredAt - AskedAt;
        }

        private string GetOpSymbol(Operation op)
        {
            switch (Op)
            {
                case Operation.ADDITION:
                    return ADDITION_SYMBOL;
                case Operation.SUBTRACTION:
                    return SUBTRACTION_SYMBOL;
                case Operation.MULTIPLICATION:
                    return MULTIPLICATION_SYMBOL;
                case Operation.DIVISION:
                    return DIVISION_SYMBOL;
                default:
                    throw new ArgumentException($"Unsupported operation: {Op}");
            }
        }

        public string GetProblemStatement()
        {
            return $"{LHS} {GetOpSymbol(Op)} {RHS} = ";
        }

        public string GetAnsweredString()
        {
            if (AnsweredCorrectly)
            {
                return this.ToString();
            }

            return $"{LHS} {GetOpSymbol(Op)} {RHS} = {Solution} (You answered: {Answer})";
        }

        public override string ToString()
        {
            return $"{LHS} {GetOpSymbol(Op)} {RHS} = {Solution}";
        }
    }
}
