using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace ArithmeticTrainer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Arithmetic Trainer. Enter 'Stop' to stop.");

            BaseProblemBuilder builder;
            while (true)
            {
                Console.WriteLine("Enter '+', '-', '/', or '*'");
                var entry = Console.ReadLine();
                if (entry == "+")
                {
                    builder = new AdditionProblemBuilder();
                    break;
                }
                if (entry == "-")
                {
                    builder = new SubtractionProblemBuilder();
                    break;
                }
                if (entry == "/")
                {
                    builder = new NoRemainderDivisionProblemBuilder();
                    break;
                }
                if (entry == "*")
                {
                    builder = new MultiplicationProblemBuilder();
                    break;
                }
                else {
                    Console.WriteLine($"{entry} is not a valid choice");
                }
            }


            int lhs, rhs;
            while (true)
            {
                Console.WriteLine("Enter <left-hand side size> <right-hand side size>");
                var input = Console.ReadLine();

                var split = input.Split(" ");
                if (split.Length != 2)
                {
                    Console.WriteLine($"{input} is not a valid choice");
                    continue;
                }

                bool success = int.TryParse(split[0], out lhs);
                success &= int.TryParse(split[1], out rhs);
            
                if (!success)
                {
                    Console.WriteLine("Could not parse numbers");
                }
                else 
                {
                    break;
                }
            }

            List<Problem> problems = builder.GetAllProblemsOfType(lhs, rhs);

            Random r = new Random();
            problems = problems.OrderBy(p => r.Next()).ToList();

            Session session = new Session(problems);

            while (true)
            {
                Console.Write(session.GetNextProblemQuestion());

                var solution = Console.ReadLine();
                if (solution == "Stop")
                {
                    break;
                }

                bool correct = session.AnswerProblem(solution);

                if (!correct)
                {
                    Console.WriteLine("\tWrong");
                }

                if (!session.HasMoreProblems())
                {
                    Console.WriteLine("You did all the problems");
                    break;
                }
            }

            Console.WriteLine("Results:");
            Console.WriteLine($"\tTotal Answered: {session.GetSolvedProblemCount()}");
            Console.WriteLine($"\tThere are {session.GetUnsolvedProblemCount()} problems left in this set");
            Console.WriteLine($"\tCorrect %: {session.GetCorrectAnswerPercentage()} ({session.GetCorrectAnswerCount()} / {session.GetSolvedProblemCount()})");
            Console.WriteLine($"\tTotal Time: {session.GetTotalTime()}");

            Console.WriteLine("Incorrect Answers: ");
            foreach (Problem p in session.GetIncorrectAnswers())
            {
                Console.WriteLine($"\t{p.GetAnsweredString()}");
            }

        }
    }
}