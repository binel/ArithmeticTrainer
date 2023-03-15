namespace ArithmeticTrainer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Arithmetic Trainer. Enter 'Stop' to stop.");

            AdditionProblemBuilder builder = new AdditionProblemBuilder();

            while (true)
            {
                Problem p = builder.GetNextProblem();

                Console.Write(p.GetProblemStatement());

                var solution = Console.ReadLine();

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
                    Console.WriteLine("Correct");
                }
                else {
                    Console.WriteLine($"Incorrect. Should be {p.Solution}");
                }
            }

            Console.WriteLine("Done");
        }
    }
}