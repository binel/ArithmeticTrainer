using System;
using System.Collections.Generic;
using System.Linq;

namespace ArithmeticTrainer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Arithmetic Trainer. Enter 'Stop' to stop.");

            AdditionProblemBuilder builder = new AdditionProblemBuilder();
            List<Problem> problems = builder.GetAllProblemsOfType(1, 1);

            Random r = new Random();
            problems = problems.OrderBy(p => r.Next()).ToList();

            Session session = new Session();

            while (true)
            {
                Problem p = problems[0];
                problems.RemoveAt(0);
                session.AddProblem(p);
                Console.Write(p.GetProblemStatement());
                p.AskedAt = DateTime.UtcNow;

                var solution = Console.ReadLine();
                p.AnsweredAt = DateTime.UtcNow;
                p.Answer = solution;

                if (solution == "Stop")
                {
                    break;
                }

                bool parseSuccess = decimal.TryParse(solution, out decimal solutionDecimal);

                if (!parseSuccess)
                {
                    Console.WriteLine("Answer could not be parsed.");
                }

                if (solutionDecimal == p.Solution)
                {
                    p.AnsweredCorrectly = true;
                    Console.WriteLine($"Correct. Time: {p.GetAnswerDelay()}");
                }
                else 
                {
                    p.AnsweredCorrectly = false;
                    Console.WriteLine($"Incorrect. Should be {p.Solution}. Time: {p.GetAnswerDelay()}");
                }

                if (problems.Count == 0)
                {
                    Console.WriteLine("You did all the problems");
                    break;
                }
            }

            Console.WriteLine("Results:");
            Console.WriteLine($"\tTotal Answered: {session.GetSolvedProblems()}");
            Console.WriteLine($"\tCorrect %: {session.GetCorrectAnswerPercentage()} ({session.GetCorrectAnswerCount()} / {session.GetSolvedProblems()}");
            Console.WriteLine($"\tTotal Time: {session.GetTotalTime()}");

            Console.WriteLine("Incorrect Answers: ");
            foreach (Problem p in session.GetIncorrectAnswers())
            {
                Console.WriteLine($"\t{p.GetAnsweredString()}");
            }

        }
    }
}