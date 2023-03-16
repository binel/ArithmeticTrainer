using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArithmeticTrainer.Test
{
    [TestFixture]
    public class AdditionProblemBuilderTest
    {
        [TestCase(1, 1, ExpectedResult = 81)]
        [TestCase(1, 2, ExpectedResult = 891)]
        [TestCase(2, 2, ExpectedResult = 9801)]
        public int GetAllProblems(int lhs_digits, int rhs_digits)
        {
            AdditionProblemBuilder b = new AdditionProblemBuilder();
            return b.GetAllProblemsOfType(lhs_digits, rhs_digits).Count;
        }

    }
}
