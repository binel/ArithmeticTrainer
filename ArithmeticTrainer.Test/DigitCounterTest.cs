using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArithmeticTrainer.Test
{
    [TestFixture]
    public class DigitCounterTest
    {
        [TestCase(0, ExpectedResult = 1)]
        [TestCase(1, ExpectedResult = 1)]
        [TestCase(9, ExpectedResult = 1)]
        [TestCase(-1, ExpectedResult = 1)]
        [TestCase(-9, ExpectedResult = 1)]
        [TestCase(10, ExpectedResult = 2)]
        [TestCase(-10, ExpectedResult = 2)]
        [TestCase(99, ExpectedResult = 2)]
        [TestCase(-99, ExpectedResult = 2)]
        [TestCase(100, ExpectedResult = 3)]
        [TestCase(-100, ExpectedResult = 3)]
        [TestCase(5000, ExpectedResult = 4)]
        [TestCase(-5000, ExpectedResult = 4)]
        public int DigitCountTest(int n)
        {
            return DigitCounter.GetNumDigits(n);
        }

    }
}
