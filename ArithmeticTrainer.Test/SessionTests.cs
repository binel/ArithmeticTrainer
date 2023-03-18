using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArithmeticTrainer.Test
{
    [TestFixture]
    public class SessionTests
    {

        // Added after finding bug
        [Test]
        public void TotalTimeWithUnsolvedProblems()
        {
            List<Problem> problems = new List<Problem>{
                new Problem()
            };

            Session s = new Session(problems);
            s.GetNextProblemQuestion();

            Assert.That(s.GetTotalTime(), Is.EqualTo(new TimeSpan(0)));
        }
    }
}
