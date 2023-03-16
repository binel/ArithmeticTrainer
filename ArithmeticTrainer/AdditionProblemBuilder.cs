using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArithmeticTrainer
{
    public class AdditionProblemBuilder
    {

        private Random _rand;

        public int MaxLHS { get; set; } = 20;
        public int MinLHS { get; set; } = 1;
        public int MaxRHS { get; set; } = 20;
        public int MinRHS { get; set; } = 1;

        public AdditionProblemBuilder() 
        {
            _rand = new Random();   
        }

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
                        Op = Operation.ADDITION,
                        Solution = lhs + rhs
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



        public Problem GetNextProblem()
        {
            Problem p = new Problem
            {
                LHS = _rand.Next(MinLHS, MaxLHS),
                RHS = _rand.Next(MinRHS, MaxRHS),
                Op = Operation.ADDITION
            };

            p.Solution = p.LHS + p.RHS;

            return p;
        }

    }
}
