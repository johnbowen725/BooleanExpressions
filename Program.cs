//Console.WriteLine("a" == "a");
//Console.WriteLine("a" == "A");
//Console.WriteLine("a" == " a");
//Console.WriteLine(1 == 2);

//string myValue = "a";
//Console.WriteLine(myValue == "a");

//string value1 = " a";
//string value2 = "A ";
//Console.WriteLine(value1.Trim().ToLower() == value2.Trim().ToLower());
// 1. _a
// 2. a
// 3. a
// 4. A_
// 5. A
// 6. a
// 7. "a" == "a"

//Console.WriteLine("a" != "a"); // returns false, "a" == "a"
//Console.WriteLine("a" != "A"); // returns true, "a" != "A"
//Console.WriteLine(1 != 2); // returns true, 1 != 2

//string myValue = "a";
//Console.WriteLine(myValue != "a"); // returns false, myValue "a" == "a"

//Console.WriteLine(1 > 2); // false
//Console.WriteLine(1 < 2); // true
//Console.WriteLine(1 >= 1); // true
//Console.WriteLine(1 <= 1); // true

//string pangram = "The quick brown fox jumps over the lazy dog.";
//Console.WriteLine(pangram.Contains("fox")); // true
//Console.WriteLine(pangram.Contains("cow")); // false
//Console.WriteLine(pangram.Contains("fox") == false); // this statement is the same as the statement below,                                                       just less concise
//Console.WriteLine(!pangram.Contains("fox")); // the ! operator reverses the statement and checks to see if                                               its opposite is true
//string pangram = "The quick brown fox jumps over the lazy dog.";
//Console.WriteLine(!pangram.Contains("fox"));
//Console.WriteLine(!pangram.Contains("cow"));

// Inequality Operator Versus Logical Negation
// != is not the same as !, != returns true if operands aren't equal, false if they are equal
// e.g. x != y checks if x is not the same value as y, returning true if so
// x != y can be written as a logical negation as !(x == y)

// Conditional Operator
//int purchaseAmount = 1001;
//int discountAmount = purchaseAmount > 1000 ? 100 : 50;
// 1. Evaluate the expression purchaseAmount > 1000
// 2. If true, assign the first value to discountAmount
// 3. If false, assign the second value
// Console.WriteLine($"Discount: {(purchaseAmount > 1000 ? 100 : 50)}"); 
// This statement is more condensed, but less readable. It's not always a good idea to combine code like this, especially when it impacts the readability. After all, programming involves more reading than it does writing.

// Complete a challenge activity using conditional operators
Console.WriteLine("Welcome. To begin, press [Y], or press any other key to exit.");
ConsoleKey userInput = GetUserKeyInput();

if (userInput == ConsoleKey.Y)
    MainMenu();
else
{
    Console.WriteLine("Exiting application...");
    Environment.Exit(0);
}
    
void MainMenu()
{
    Console.Title = "Main Menu";
    Console.Clear();
    Console.WriteLine("\t\t\t~~~ MAIN MENU ~~~");
    Console.WriteLine("\nPress [1] to begin the Coin Flipper. \nOtherwise, press [Backspace] to exit the application.");
    userInput = GetUserKeyInput();

    if (userInput == ConsoleKey.D1)
    {
        FlipCoin();
    }
    else if (userInput == ConsoleKey.Backspace)
    {
        Console.WriteLine("\nExiting application. Goodbye!");
        Environment.Exit(0);
    }
}

void FlipCoin()
{
    Console.Title = "Coin Flipper";
    Console.BackgroundColor = ConsoleColor.Green;
    Console.ForegroundColor = ConsoleColor.Black;
    Console.Clear();
    Console.WriteLine("\t\t\t~~~ COIN FLIPPER ~~~");

    Random coin = new Random();

    int coinFlipTimes = 0;
    int headsFlipped = 0;
    int tailsFlipped = 0;
    decimal headsPercentage = 0;
    decimal tailsPercentage = 0;

    Console.WriteLine("\nPress [F] to flip a coin, or press the [Enter] key to exit and return to the main menu.\nYou can also press [C] to check how many coins have resulted in Heads or Tails!");
    

    while (true)
    {
        int coinFlip = coin.Next(1, 3);
        string coinSide = coinFlip == 1 ? "Heads" : "Tails";
        userInput = GetUserKeyInput();

        if (userInput == ConsoleKey.Enter)
        {
            Console.WriteLine("Exiting the Coin Flipper...\n");
            Console.WriteLine("Returning to Main Menu...\n");
            MainMenu();
            break;
        }
        else if (userInput == ConsoleKey.F)
        {
            Thread.Sleep(200);
            Console.WriteLine("Flipping coin...\n");
            Console.Beep(988, 100);
            Console.Beep(1319, 200);

            Console.WriteLine($"Coin Flip {++coinFlipTimes} result: {coinSide}");
            if (coinSide == "Heads") headsFlipped++;
            else if (coinSide == "Tails") tailsFlipped++;

            continue;
        }
        else if (userInput == ConsoleKey.C)
        {
            Console.Beep(247, 500);

            headsPercentage = ((decimal)headsFlipped / coinFlipTimes) * 100;
            tailsPercentage = ((decimal)tailsFlipped / coinFlipTimes) * 100;
            Console.WriteLine($"\nNumber of Heads flipped: {headsFlipped} ({headsPercentage:0.00}%)\nNumber of Tails flipped: {tailsFlipped} ({tailsPercentage:0.00}%)\n");

            continue;
        }
    }
}

void PermissionsChecker()
{
    Console.WriteLine("Please enter your title (e.g. Admin, Manager).\n");

    string permission = Console.ReadLine().ToLower();

    Console.WriteLine("Please enter your clearance level.\n");
    int level = Convert.ToInt32(Console.ReadLine());

    if (permission.Contains("admin"))
    {
        if (level > 55)
            Console.WriteLine("Welcome, Super Admin user. You have god privileges.");
        else
            Console.WriteLine("Welcome, Admin user. You have most privileges.");
    }
    else if (permission.Contains("manager"))
    {
        if (level >= 20)
            Console.WriteLine("Hello, Big Manager. You must contact an Admin or Super Admin for access.");
        else
            Console.WriteLine("Hi, Manager. You do not have sufficient privileges.");
    }
    else
        Console.WriteLine("You do not have sufficient privileges.");
}

ConsoleKey GetUserKeyInput()
{
    var key = Console.ReadKey(true).Key;
    Thread.Sleep(300);
    return key;
}