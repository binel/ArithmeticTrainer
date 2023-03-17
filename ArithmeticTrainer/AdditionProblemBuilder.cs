using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArithmeticTrainer
{
    public class AdditionProblemBuilder : BaseProblemBuilder
    {
        public override Operation Op { get; } = Operation.ADDITION;

        public override Func<int, int, decimal> SolutionMethod => (a, b) => a + b;
    }
}
