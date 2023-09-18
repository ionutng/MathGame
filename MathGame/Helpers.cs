namespace MathGame
{
    internal class Helpers
    {
        internal int[] GetRandomNumbers(string difficulty)
        {
            int[] numbers = new int[2];
            Random random = new Random();

            if (difficulty == "easy")
            {
                numbers[0] = random.Next(10);
                numbers[1] = random.Next(10);
            }
            else if (difficulty == "medium")
            {
                do
                {
                    numbers[0] = random.Next(100);
                    numbers[1] = random.Next(100);
                } while (numbers[0] < 10 || numbers[1] < 10);
            }
            else if (difficulty == "hard")
            {
                do
                {
                    numbers[0] = random.Next(1000);
                    numbers[1] = random.Next(1000);
                } while (numbers[0] < 100 || numbers[1] < 100);
            }

            return numbers;
        }

        internal string GetDifficultyLevel()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("What level of difficulty do you want?");
            Console.WriteLine("1 - Easy");
            Console.WriteLine("2 - Medium");
            Console.WriteLine("3 - Hard");

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("Level: ");
            string difficulty = Console.ReadLine();
            Console.WriteLine();

            switch (difficulty)
            {
                case "1":
                    return "easy";
                case "2":
                    return "medium";
                case "3":
                    return "hard";
                default:
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Please select a level of difficulty: 1 for easy, 2 for medium, 3 for hard.");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Environment.Exit(0);
                        return "";
                    }
            }
        }

        internal int GetNumberOfQuestions()
        {
            int numberOfQuestions;

            do
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("How many questions would you like to solve? ");
            } while (!Int32.TryParse(Console.ReadLine(), out numberOfQuestions));
            Console.WriteLine();

            return numberOfQuestions;
        }

        internal void AddGameToList(int[] numbers, int result, bool correctAnswer, string operand, List<string> previousGames)
        {
            string game;
            if (correctAnswer)
                game = numbers[0] + " " + operand + " " + numbers[1] + " = " + result + " -> CORRECT";
            else
                game = numbers[0] + " " + operand + " " + numbers[1] + " = " + result + " -> WRONG";
            previousGames.Add(game);
        }
    }
}
