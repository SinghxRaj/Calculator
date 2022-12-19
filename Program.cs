// See https://aka.ms/new-console-template for more information

double num1, num2;

// Display title as the c# console calculator app.
Console.WriteLine("Console Calculator in c#\r");
Console.WriteLine("-------------------------\n");

bool isCalculatorRunning = true;
while (isCalculatorRunning)
{
    // Ask the user to type the first number.
    Console.WriteLine("Type a number, and then press Enter");
    while (!double.TryParse(Console.ReadLine(), out num1))
    {
        Console.WriteLine("Invalid input. Must enter a number:");
    }

    // Ask the user to type the second number.
    Console.WriteLine("Type another number, and then press Enter");
    while (!double.TryParse(Console.ReadLine(), out num2))
    {
        Console.WriteLine("Invalid input. Must enter a number:");
    }

    // Ask the user to choose an option.
    Console.WriteLine("Choose an option from the following list:");
    Console.WriteLine("\t+ - Add");
    Console.WriteLine("\t- - Subtract");
    Console.WriteLine("\t* - Multiple");
    Console.WriteLine("\t/ - Divide");
    Console.WriteLine("Your option?");

    // Use a switch statement to do the math.
    try
    {
        string? op = Console.ReadLine();
        double result = Calculator.DoOperation(num1, num2, op);
        if (double.IsNaN(result))
        {
            Console.WriteLine("Invalid Operator.");
        } else
        {
            Console.WriteLine($"{num1} {op} {num2} = {result}");
        }
    } catch (Exception)
    {
        Console.WriteLine("Invalid input.");
    }

    // See whether user would like to continue.
    Console.WriteLine("Would you like to go again (y or n).");
    string? response = Console.ReadLine();
    isCalculatorRunning = string.IsNullOrEmpty(response) && response![0] == 'y';

    Console.WriteLine();
}


// Wait for the user to respond before closing.
Console.WriteLine("Press any key to close the Calculator console app...");
Console.ReadKey();
