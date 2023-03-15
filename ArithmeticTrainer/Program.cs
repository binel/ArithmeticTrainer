using System;

namespace ArithmeticTrainer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Arithmetic Trainer. Enter 'Stop' to stop.");

            AdditionProblemBuilder builder = new AdditionProblemBuilder();
            Session session = new Session();

            while (true)
            {
                Problem p = builder.GetNextProblem();
                session.AddProblem(p);
                Console.Write(p.GetProblemStatement());
                p.AskedAt = DateTime.UtcNow;

                var solution = Console.ReadLine();
                p.AnsweredAt = DateTime.UtcNow;            

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
            }

            Console.WriteLine($"Total Answered: {session.GetSolvedProblems()}. Correct %: {session.GetCorrectAnswerPercentage()}");
        }
    }
}