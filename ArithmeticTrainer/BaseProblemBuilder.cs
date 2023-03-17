using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArithmeticTrainer
{
    public abstract class BaseProblemBuilder
    {
        public abstract Operation Op { get; }

        public abstract Func<int, int, decimal> SolutionMethod { get; }

        public List<Problem> GetAllProblemsOfType(int LHS_Size, int RHS_Size)
        {
            List<Problem> result = new List<Problem>();

            int lhs = 1;
            int rhs = 1;
            while (true)
            {
                while (true)
                {
                    result.Add(new Problem
                    {
                        LHS = lhs,
                        RHS = rhs,
                        Op = Op,
                        Solution = SolutionMethod(lhs, rhs)
                    });

                    rhs += 1;

                    if (DigitCounter.GetNumDigits(rhs) > RHS_Size)
                    {
                        break;
                    }
                }
                rhs = 1;
                lhs += 1;

                if (DigitCounter.GetNumDigits(lhs) > LHS_Size)
                {
                    break;
                }
            }

            return result;
        }
    }
}
