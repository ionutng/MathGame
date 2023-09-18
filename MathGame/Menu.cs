using System.Diagnostics;

namespace MathGame
{
    internal class Menu
    {
        internal static void ShowMenu()
        {
            int numberOfQuestions;
            string difficulty = string.Empty;
            Helpers helper = new Helpers();
            GameOptions gameOptions = new GameOptions();

            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("Welcome to ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("THE MATH GAME!");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Please choose your option:");
                Console.WriteLine("1 - Addition");
                Console.WriteLine("2 - Subtraction");
                Console.WriteLine("3 - Multiplication");
                Console.WriteLine("4 - Division");
                Console.WriteLine("5 - Random Operations");
                Console.WriteLine("6 - Show previous games");

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("Your option (1-6): ");
                string option = Console.ReadLine();
                Console.WriteLine();

                if (Convert.ToInt32(option) < 6)
                {
                    difficulty = helper.GetDifficultyLevel();
                    numberOfQuestions = helper.GetNumberOfQuestions();
                }
                else
                    numberOfQuestions = 1;

                Stopwatch stopwatch = Stopwatch.StartNew();

                for (int i = 0; i < numberOfQuestions; i++)
                {
                    switch (option?.Trim())
                    {
                        case "1":
                            {
                                gameOptions.Addition(difficulty);
                                break;
                            }
                        case "2":
                            {
                                gameOptions.Subtraction(difficulty);
                                break;
                            }
                        case "3":
                            {
                                gameOptions.Multiplication(difficulty);
                                break;
                            }
                        case "4":
                            {
                                gameOptions.Division(difficulty);
                                break;
                            }
                        case "5":
                            {
                                gameOptions.RandomOperations(difficulty);
                                break;
                            }
                        case "6":
                            {
                                gameOptions.ShowPreviousGames();
                                break;
                            }
                        default:
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Please select an available option: 1-6");
                                Console.ForegroundColor = ConsoleColor.Gray;
                                break;
                            }
                    }
                }

                stopwatch.Stop();
                TimeSpan elapsedTime = stopwatch.Elapsed;

                if (Convert.ToInt32(option) < 6)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"It took you {Math.Round(elapsedTime.TotalSeconds, 2)} seconds to finish answering.");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }

                Console.Write("Do you wish to keep playing? (y for yes): ");
            } while (Console.ReadLine() == "y");
        }
    }
}
