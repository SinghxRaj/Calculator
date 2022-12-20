internal class Program
{
    private static void Main(string[] args)
    {
        DisplayTitle();
        RunCalculator();
        DisplayExit();
    }

    private static void RunCalculator()
    {
        bool continueCalculator = true;
        while (continueCalculator)
        {
            continueCalculator = SingleCalculation();
            Console.WriteLine();
        }

        DisplayTotalCalculations();
    }

    private static void DisplayExit()
    {
        Console.WriteLine("Press any key to close the Calculator console app...");
        Console.ReadKey();
    }

    private static void DisplayTitle()
    {
        Console.WriteLine("Console Calculator in c#\r");
        Console.WriteLine("-------------------------\n");
    }

    private static bool SingleCalculation()
    {
        bool isCalculatorRunning;
        AskToViewPreviousCalculations();
        AskToClearCache();
        PerformCalculation();
        isCalculatorRunning = ContinueCalculator();

        return isCalculatorRunning;
    }

    private static void DisplayTotalCalculations()
    {
        Console.WriteLine($"Total number of operations: {Calculator.TotalOperations}");
    }

    private static bool ContinueCalculator()
    {
        bool isCalculatorRunning;
        Console.WriteLine("Would you like to go again (y or n).");
        string? response = Console.ReadLine();
        isCalculatorRunning = string.IsNullOrEmpty(response) && response![0] == 'y';
        return isCalculatorRunning;
    }

    private static void PerformCalculation()
    {
        double num1, num2;
        GetOperands(out num1, out num2);

        Console.WriteLine("Choose an option from the following list:");

        Console.WriteLine("\t+ - Add");
        Console.WriteLine("\t- - Subtract");
        Console.WriteLine("\t* - Multiple");
        Console.WriteLine("\t/ - Divide");
        Console.WriteLine("Your option?");

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
    }

    private static void GetOperands(out double num1, out double num2)
    {
        Console.WriteLine("Type a number, and then press Enter");
        while (!double.TryParse(Console.ReadLine(), out num1))
        {
            Console.WriteLine("Invalid input. Must enter a number:");
        }

        Console.WriteLine("Type another number, and then press Enter");
        while (!double.TryParse(Console.ReadLine(), out num2))
        {
            Console.WriteLine("Invalid input. Must enter a number:");
        }
    }

    private static void AskToClearCache()
    {
        Console.WriteLine("Would you like to clear previous calculations (y or n)?");
        string? response = Console.ReadLine();
        if (!string.IsNullOrEmpty(response) && response[0] == 'y')
        {
            Calculator.ClearCache();
            Console.WriteLine("Calculator has been cleared.");
        }
    }

    private static void AskToViewPreviousCalculations()
    {
        Console.WriteLine("Would you like to see previous calculations (y or n)?");
        string? response = Console.ReadLine();
        if (!string.IsNullOrEmpty(response) && response[0] == 'y')
        {
            string cache = Calculator.ViewCache();
            Console.WriteLine("List of previous operations:");
            Console.WriteLine(cache);
        }
    }
}