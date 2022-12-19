using System.Text;

internal class Calculator
{
    public static int TotalOperations { get; private set; } = 0;
    private static List<Tuple<double, double, string?, double>> CachedOperations { get; set; } = 
        new List<Tuple<double, double, string?, double>>();
    public static double DoOperation(double num1, double num2, string? op)
    {
        IncrementOperations();

        double result;

        switch (op)
        {
            case "+":
                result = num1 + num2;
                break;
            case "-":
                result = num1 - num2;
                break;
            case "*":
                result = num1 * num2;
                break;
            case "/":
                if (num2 == 0)
                {
                    throw new DivideByZeroException("Second Argument can not be zero when dividing.");
                }
                result = num1 / num2;
                break;
            default:
                result = double.NaN;
                break;
        }

        CacheOperation(num1, num2, op, result);
        return result;

    }

    private static void CacheOperation(double num1, double num2, string? op, double result)
    {
        CachedOperations.Add(Tuple.Create(num1, num2, op, result));
    }

    private static void IncrementOperations()
    {
        TotalOperations++;
    }

    public static string ViewCache()
    {
        var sb = new StringBuilder();
        foreach(var op in CachedOperations)
        {
            sb.AppendLine($"{op.Item1} {op.Item3} {op.Item2} = {op.Item4}");
        }
        return sb.ToString();
        
    }

    public static void ClearCache()
    {
        CachedOperations.Clear();
    }
}
