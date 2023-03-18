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

        public virtual Func<decimal, bool> AcceptableSolutionChecker { get; set; } = (sol) => true;

        public List<Problem> GetAllProblemsOfType(int LHS_Size, int RHS_Size)
        {
            List<Problem> result = new List<Problem>();

            int starting_rhs = DigitCounter.GetSmallestIntOfLength(RHS_Size);

            int lhs = DigitCounter.GetSmallestIntOfLength(LHS_Size);
            int rhs = starting_rhs;
            while (true)
            {
                while (true)
                {
                    Problem p = new Problem
                    {
                        LHS = lhs,
                        RHS = rhs,
                        Op = Op,
                        Solution = SolutionMethod(lhs, rhs)
                    };

                    if (AcceptableSolutionChecker(p.Solution)) {
                        result.Add(p);
                    }

                    rhs += 1;

                    if (DigitCounter.GetNumDigits(rhs) > RHS_Size)
                    {
                        break;
                    }
                }
                rhs = starting_rhs;
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
