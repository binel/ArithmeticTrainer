using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArithmeticTrainer.Test
{
    [TestFixture]
    public class ProblemTests
    {
        [TestCase(1, 1, Operation.ADDITION, ExpectedResult = "1 + 1 = ")]
        [TestCase(100, 99, Operation.SUBTRACTION, ExpectedResult = "100 - 99 = ")]
        [TestCase(-1, 0, Operation.MULTIPLICATION, ExpectedResult = "-1 × 0 = ")]
        [TestCase(3, 7, Operation.DIVISION, ExpectedResult = "3 ÷ 7 = ")]
        public string ProblemStatementTests(int LHS, int RHS, Operation op)
        {
            Problem p = new Problem
            {
                LHS = LHS,
                RHS = RHS,
                Op = op
            };

            return p.GetProblemStatement();
        }
    }
}
