Console.WriteLine("Welcome to THE MATH GAME!");
Console.WriteLine("Please choose your option:");
Console.WriteLine("1 - Addition");
Console.WriteLine("2 - Subtraction");
Console.WriteLine("3 - Multiplication");
Console.WriteLine("4 - Division");
Console.WriteLine("5 - Show previous games");

List<string> previousGames = new List<string>();

do
{
    Console.Write("Your option (1-5): ");
    string option = Console.ReadLine();

    switch (option)
    {
        case "1":
            {
                Console.WriteLine("You chose addition");
                Addition();
                break;
            }
        case "2":
            {
                Console.WriteLine("You chose Subtraction");
                Subtraction();
                break;
            }
        case "3":
            {
                Console.WriteLine("You chose Multiplication");
                Multiplication();
                break;
            }
        case "4":
            {
                Console.WriteLine("You chose Division");
                Division();
                break;
            }
        case "5":
            {
                Console.WriteLine("You chose to see the previous games");
                ShowPreviousGames();
                break;
            }
        default:
            {
                Console.WriteLine("Please select an available option: 1-5");
                break;
            }
    }
    Console.Write("Do you wish to keep playing? (y for yes): ");
} while (Console.ReadLine() == "y");

int[] GetRandomNumbers()
{
    string difficulty = GetDifficultyLevel();
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
    Console.WriteLine("What level of difficulty do you want?");
    Console.WriteLine("1 - Easy");
    Console.WriteLine("2 - Medium");
    Console.WriteLine("3 - Hard");

    Console.Write("Level: ");
    string difficulty = Console.ReadLine();

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
                Console.WriteLine("Please select a level of difficulty: easy, medium, hard.");
                return "";
            }
    }
}

void Addition()
{
    int result;
    int[] numbers = GetRandomNumbers();

    Console.WriteLine($"Question: {numbers[0]} + {numbers[1]} = ?");

    do
    {
        Console.Write("Answer: ");
    } while (!Int32.TryParse(Console.ReadLine(), out result));

    if (result == numbers[0] + numbers[1])
        Console.WriteLine("Correct!");
    else
        Console.WriteLine("That's not right!");

    AddGameToList(numbers, result);
}

void Subtraction()
{
    int result;
    int[] numbers = GetRandomNumbers();

    Console.WriteLine($"Question: {numbers[0]} - {numbers[1]} = ?");

    do
    {
        Console.Write("Answer: ");
    } while (!Int32.TryParse(Console.ReadLine(), out result));

    if (result == numbers[0] - numbers[1])
        Console.WriteLine("Correct!");
    else
        Console.WriteLine("That's not right!");

    AddGameToList(numbers, result);
}

void Multiplication()
{
    int result;
    int[] numbers = GetRandomNumbers();

    Console.WriteLine($"Question: {numbers[0]} * {numbers[1]} = ?");

    do
    {
        Console.Write("Answer: ");
    } while (!Int32.TryParse(Console.ReadLine(), out result));

    if (result == numbers[0] * numbers[1])
        Console.WriteLine("Correct!");
    else
        Console.WriteLine("That's not right!");

    AddGameToList(numbers, result);
}

void Division()
{
    int result;
    int[] numbers;

    do
    {
        numbers = GetRandomNumbers();
    } while (numbers[1] == 0 || numbers[0] % numbers[1] != 0);

    Console.WriteLine($"Question: {numbers[0]} / {numbers[1]} = ?");

    do
    {
        Console.Write("Answer: ");
    } while (!Int32.TryParse(Console.ReadLine(), out result));

    if (result == numbers[0] / numbers[1])
        Console.WriteLine("Correct!");
    else
        Console.WriteLine("That's not right!");

    AddGameToList(numbers, result);
}

void AddGameToList(int[] numbers, int result)
{
    string game;
    game = numbers[0] + " + " + numbers[1] + " = " + result;
    previousGames.Add(game);
}

void ShowPreviousGames()
{
    int counter = 0;
    if (previousGames.Count == 0)
        Console.WriteLine("There are no previous games!");
    else
    {
        foreach (string game in previousGames)
        {
            Console.WriteLine($"Game #{++counter}: {game}");
        }
    }
}