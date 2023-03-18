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
        [TestCase(1, 2, ExpectedResult = 810)]
        [TestCase(2, 2, ExpectedResult = 8100)]
        public int GetAllProblems(int lhs_digits, int rhs_digits)
        {
            AdditionProblemBuilder b = new AdditionProblemBuilder();
            return b.GetAllProblemsOfType(lhs_digits, rhs_digits).Count;
        }

        // Added after finding a bug
        [Test]
        public void ProblemSizeDoubleCheck()
        {
            AdditionProblemBuilder b = new AdditionProblemBuilder();
            var problems = b.GetAllProblemsOfType(1, 2);

            Predicate<Problem> predicate = (p) => DigitCounter.GetNumDigits(p.RHS) < 2;

            Assert.That(problems.Find(predicate), Is.Null, message: $"{problems.Find(predicate)}");
        }

    }
}
