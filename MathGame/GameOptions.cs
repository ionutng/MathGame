namespace MathGame
{
    internal class GameOptions
    {
        Helpers helper = new Helpers();
        List<string> previousGames = new List<string>();

        internal void Addition(string difficulty)
        {
            int result;
            int[] numbers = helper.GetRandomNumbers(difficulty);
            bool correctAnswer;

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Question: {numbers[0]} + {numbers[1]} = ?");

            do
            {
                Console.Write("Answer: ");
            } while (!Int32.TryParse(Console.ReadLine(), out result));

            if (result == numbers[0] + numbers[1])
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Correct!");
                correctAnswer = true;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("That's not right!");
                correctAnswer = false;
            }

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine();
            helper.AddGameToList(numbers, result, correctAnswer, "+", previousGames);
        }

        internal void Subtraction(string difficulty)
        {
            int result;
            int[] numbers = helper.GetRandomNumbers(difficulty);
            bool correctAnswer;

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Question: {numbers[0]} - {numbers[1]} = ?");

            do
            {
                Console.Write("Answer: ");
            } while (!Int32.TryParse(Console.ReadLine(), out result));

            if (result == numbers[0] - numbers[1])
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Correct!");
                correctAnswer = true;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("That's not right!");
                correctAnswer = false;
            }

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine();
            helper.AddGameToList(numbers, result, correctAnswer, "-", previousGames);
        }

        internal void Multiplication(string difficulty)
        {
            int result;
            int[] numbers = helper.GetRandomNumbers(difficulty);
            bool correctAnswer;

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Question: {numbers[0]} * {numbers[1]} = ?");

            do
            {
                Console.Write("Answer: ");
            } while (!Int32.TryParse(Console.ReadLine(), out result));

            if (result == numbers[0] * numbers[1])
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Correct!");
                correctAnswer = true;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("That's not right!");
                correctAnswer = false;
            }

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine();
            helper.AddGameToList(numbers, result, correctAnswer, "*", previousGames);
        }

        internal void Division(string difficulty)
        {
            int result;
            int[] numbers;
            bool correctAnswer;

            do
            {
                numbers = helper.GetRandomNumbers(difficulty);
            } while (numbers[1] == 0 || numbers[0] % numbers[1] != 0);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Question: {numbers[0]} / {numbers[1]} = ?");

            do
            {
                Console.Write("Answer: ");
            } while (!Int32.TryParse(Console.ReadLine(), out result));

            if (result == numbers[0] / numbers[1])
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Correct!");
                correctAnswer = true;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("That's not right!");
                correctAnswer = false;
            }

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine();
            helper.AddGameToList(numbers, result, correctAnswer, "/", previousGames);
        }

        internal void RandomOperations(string difficulty)
        {
            Random random = new Random();
            int operationNumber = random.Next(4);
            if (operationNumber == 0)
                Addition(difficulty);
            else if (operationNumber == 1)
                Subtraction(difficulty);
            else if (operationNumber == 2)
                Multiplication(difficulty);
            else if (operationNumber == 3)
                Division(difficulty);
        }

        internal void ShowPreviousGames()
        {
            int counter = 0;
            if (previousGames.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("There are no previous games!");
            }
            else
            {
                foreach (string game in previousGames)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    if (game.Substring(game.Length - 5) == "WRONG")
                        Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Game #{++counter}: {game}");
                }
            }
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
