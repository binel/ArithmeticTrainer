using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArithmeticTrainer.Test
{
    [TestFixture]
    public class SessionTest
    {
        [Test]
        public void PercentageTest_100Percent()
        {
            Session s = new Session();
            Problem p = new Problem();
            p.AnsweredCorrectly = true;

            s.AddProblem(p);

            Assert.That(s.GetCorrectAnswerPercentage(), Is.EqualTo(100));
        }

        [Test]
        public void PercentageTest_0Percent()
        {
            Session s = new Session();
            Problem p = new Problem();
            p.AnsweredCorrectly = false;

            s.AddProblem(p);

            Assert.That(s.GetCorrectAnswerPercentage(), Is.EqualTo(0));
        }

        [Test]
        public void PercentageTest_50Percent()
        {
            Session s = new Session();
            Problem p1 = new Problem();
            p1.AnsweredCorrectly = true;
            s.AddProblem(p1);

            Problem p2 = new Problem();
            p2.AnsweredCorrectly = false;
            s.AddProblem(p2);

            Assert.That(s.GetCorrectAnswerPercentage(), Is.EqualTo(50));
        }
    }
}
