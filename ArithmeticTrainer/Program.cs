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

            BaseProblemBuilder builder;
            while (true)
            {
                Console.WriteLine("Enter '+' for addition, '-' for subtraction");
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
                else {
                    Console.WriteLine($"{entry} is not a valid choice");
                }
            }
            
            List<Problem> problems = builder.GetAllProblemsOfType(1, 1);

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
            Console.WriteLine($"\tTotal Answered: {session.GetSolvedProblems()}");
            Console.WriteLine($"\tCorrect %: {session.GetCorrectAnswerPercentage()} ({session.GetCorrectAnswerCount()} / {session.GetSolvedProblems()})");
            Console.WriteLine($"\tTotal Time: {session.GetTotalTime()}");

            Console.WriteLine("Incorrect Answers: ");
            foreach (Problem p in session.GetIncorrectAnswers())
            {
                Console.WriteLine($"\t{p.GetAnsweredString()}");
            }

        }
    }
}