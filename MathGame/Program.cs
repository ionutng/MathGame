using System.Diagnostics;

List<string> previousGames = new List<string>();
string difficulty = string.Empty;
int numberOfQuestions;

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

    if (option != "6")
    {
        difficulty = GetDifficultyLevel();
        numberOfQuestions = GetNumberOfQuestions();
    }
    else
        numberOfQuestions = 1;

    Stopwatch stopwatch = Stopwatch.StartNew();

    for (int i = 0; i < numberOfQuestions; i++)
    {
        switch (option)
        {
            case "1":
                {
                    Addition();
                    break;
                }
            case "2":
                {
                    Subtraction();
                    break;
                }
            case "3":
                {
                    Multiplication();
                    break;
                }
            case "4":
                {
                    Division();
                    break;
                }
            case "5":
                {
                    RandomOperations();
                    break;
                }
            case "6":
                {
                    ShowPreviousGames();
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

    if (option != "6")
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"It took you {Math.Round(elapsedTime.TotalSeconds, 2)} seconds to finish answering.");
        Console.ForegroundColor = ConsoleColor.Gray;
    }

    Console.Write("Do you wish to keep playing? (y for yes): ");
} while (Console.ReadLine() == "y");

int[] GetRandomNumbers()
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

string GetDifficultyLevel()
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
                return "";
            }
    }
}

int GetNumberOfQuestions()
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

void Addition()
{
    int result;
    int[] numbers = GetRandomNumbers();
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
    AddGameToList(numbers, result, correctAnswer, "+");
}

void Subtraction()
{
    int result;
    int[] numbers = GetRandomNumbers();
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
    AddGameToList(numbers, result, correctAnswer, "-");
}

void Multiplication()
{
    int result;
    int[] numbers = GetRandomNumbers();
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
    AddGameToList(numbers, result, correctAnswer, "*");
}

void Division()
{
    int result;
    int[] numbers;
    bool correctAnswer;

    do
    {
        numbers = GetRandomNumbers();
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
    AddGameToList(numbers, result, correctAnswer, "/");
}

void RandomOperations()
{
    Random random = new Random();
    int operationNumber = random.Next(4);
    if (operationNumber == 0)
        Addition();
    else if (operationNumber == 1)
        Subtraction();
    else if (operationNumber == 2)
        Multiplication();
    else if (operationNumber == 3)
        Division();
}

void ShowPreviousGames()
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

void AddGameToList(int[] numbers, int result, bool correctAnswer, string operand)
{
    string game;
    if (correctAnswer)
        game = numbers[0] + " " + operand + " " + numbers[1] + " = " + result + " -> CORRECT";
    else
        game = numbers[0] + " " + operand + " " + numbers[1] + " = " + result + " -> WRONG";
    previousGames.Add(game);
}