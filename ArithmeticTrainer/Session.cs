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

        public int GetCorrectAnswers() => _problems.FindAll(p => p.AnsweredCorrectly).Count;

        public int GetIncorrectAnswers() => _problems.FindAll(p => !p.AnsweredCorrectly).Count;

        public double GetCorrectAnswerPercentage() => ((double)GetCorrectAnswers() / (double)GetSolvedProblems()) * 100;
    }
}
