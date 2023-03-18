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
        private readonly List<Problem> _askedProblems = new List<Problem>();

        private readonly List<Problem> _problemPool;

        private Problem WorkingProblem
        {
            get
            {
                if (!HasMoreProblems())
                {
                    throw new InvalidOperationException("No more available problems");
                }
                return _problemPool[0];    
            }
        }

        public Session(List<Problem> problems)
        {
            _problemPool = problems;
        }

        public bool HasMoreProblems()
        {
            return _problemPool.Any();
        }

        /// <summary>
        /// Gets the next problem from the problem pool. Also sets the Asked time 
        /// of the problem. 
        /// </summary>
        /// <returns>The problem statement</returns>
        public string GetNextProblemQuestion()
        {
            WorkingProblem.AskedAt = DateTime.UtcNow;
            _askedProblems.Add(WorkingProblem);
            return _problemPool[0].GetProblemStatement();
        }

        public void CloseSession()
        {
            WorkingProblem.AskedAt = DateTime.MinValue;
            _problemPool.Add(WorkingProblem);
            _askedProblems.Remove(WorkingProblem);
        }

        public bool AnswerProblem(string solution)
        {
            WorkingProblem.AnsweredAt = DateTime.UtcNow;
            WorkingProblem.Answer = solution;
            bool parseSuccess = decimal.TryParse(solution, out decimal solutionDecimal);

            if (parseSuccess && solutionDecimal == WorkingProblem.Solution)
            {
                WorkingProblem.AnsweredCorrectly = true;
            }
            else
            {
                WorkingProblem.AnsweredCorrectly = false;
            }
            var ret = WorkingProblem.AnsweredCorrectly;

            _problemPool.RemoveAt(0);
            return ret;
        }

        public void AddProblem(Problem p) => _askedProblems.Add(p);

        public int GetSolvedProblemCount() => _askedProblems.Count;

        public int GetUnsolvedProblemCount() => _problemPool.Count;

        public int GetCorrectAnswerCount() => _askedProblems.FindAll(p => p.AnsweredCorrectly).Count;

        public int GetIncorrectAnswerCount() => _askedProblems.FindAll(p => !p.AnsweredCorrectly).Count;

        public List<Problem> GetIncorrectAnswers() => _askedProblems.FindAll(p => !p.AnsweredCorrectly); 

        public double GetCorrectAnswerPercentage() => ((double)GetCorrectAnswerCount() / (double)GetSolvedProblemCount()) * 100;

        public TimeSpan GetTotalTime()
        {
            TimeSpan totalTime = new TimeSpan();    
            foreach (Problem p in _askedProblems)
            {
                totalTime += p.GetAnswerDelay();
            }
            return totalTime;
        }
    }
}
