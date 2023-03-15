using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArithmeticTrainer
{
    public class AdditionProblemBuilder
    {

        private Random _rand;

        public int MaxLHS { get; set; } = 9;
        public int MinLHS { get; set; } = 1;
        public int MaxRHS { get; set; } = 9;
        public int MinRHS { get; set; } = 1;

        public AdditionProblemBuilder() 
        {
            _rand = new Random();   
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
