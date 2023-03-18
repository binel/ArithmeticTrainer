using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArithmeticTrainer
{
    public class NoRemainderDivisionProblemBuilder: BaseProblemBuilder
    {
        public override Operation Op => Operation.DIVISION;

        public override Func<int, int, decimal> SolutionMethod => (a, b) => (decimal)a / b;

        public override Func<decimal, bool> AcceptableSolutionChecker => (sol) => sol % 1 == 0;
    }
}
