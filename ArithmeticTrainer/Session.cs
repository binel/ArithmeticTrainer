using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ArithmeticTrainer
{
    public class Session
    {
        private readonly List<Problem> _problems = new List<Problem>();

        public void AddProblem(Problem p) => _problems.Add(p);

        public int GetSolvedProblems() => _problems.Count;

        public int GetCorrectAnswerCount() => _problems.FindAll(p => p.AnsweredCorrectly).Count;

        public int GetIncorrectAnswerCount() => _problems.FindAll(p => !p.AnsweredCorrectly).Count;

        public List<Problem> GetIncorrectAnswers() => _problems.FindAll(p => !p.AnsweredCorrectly); 

        public double GetCorrectAnswerPercentage() => ((double)GetCorrectAnswerCount() / (double)GetSolvedProblems()) * 100;

        public TimeSpan GetTotalTime()
        {
            TimeSpan totalTime = new TimeSpan();    
            foreach (Problem p in _problems)
            {
                totalTime += p.GetAnswerDelay();
            }
            return totalTime;
        }
    }
}
