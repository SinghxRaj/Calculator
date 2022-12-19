﻿internal class Program
{
    private static void Main(string[] args)
    {
        double num1, num2;

        // Display title as the c# console calculator app.
        Console.WriteLine("Console Calculator in c#\r");
        Console.WriteLine("-------------------------\n");

        bool isCalculatorRunning = true;
        while (isCalculatorRunning)
        {
            Console.WriteLine("Would you like to see previous calculations (y or n)?");
            string? response = Console.ReadLine();
            if (!string.IsNullOrEmpty(response) && response[0] == 'y')
            {
                string cache = Calculator.ViewCache();
                Console.WriteLine("List of previous operations:");
                Console.WriteLine(cache);
            }

            Console.WriteLine("Would you like to clear previous calculations (y or n)?");
            response = Console.ReadLine();
            if (!string.IsNullOrEmpty(response) && response[0] == 'y')
            {
                Calculator.ClearCache();
                Console.WriteLine("Calculator has been cleared.");
            }

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
                }
                else
                {
                    Console.WriteLine($"{num1} {op} {num2} = {result}");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid input.");
            }

            // See whether user would like to continue.
            Console.WriteLine("Would you like to go again (y or n).");
            response = Console.ReadLine();
            isCalculatorRunning = string.IsNullOrEmpty(response) && response![0] == 'y';

            Console.WriteLine();
        }

        Console.WriteLine($"Total number of operations: {Calculator.TotalOperations}");


        // Wait for the user to respond before closing.
        Console.WriteLine("Press any key to close the Calculator console app...");
        Console.ReadKey();
    }
}