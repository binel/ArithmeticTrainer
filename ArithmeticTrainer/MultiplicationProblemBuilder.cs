using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArithmeticTrainer
{
    public class MultiplicationProblemBuilder: BaseProblemBuilder
    {
        public override Operation Op => Operation.MULTIPLICATION;

        public override Func<int, int, decimal> SolutionMethod => (a, b) => a * b;
    }
}
