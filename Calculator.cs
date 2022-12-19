using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
internal class Calculator
{
    public static double DoOperation(double num1, double num2, string? op)
    {
        switch (op)
        {
            case "+":
                return num1 + num2;
            case "-":
                return num1 - num2;
            case "*":
                return num1 * num2;
            case "/":
                if (num2 == 0)
                {
                    throw new DivideByZeroException("Second Argument can not be zero when dividing.");
                }
                return num1 / num2;
            default:
                return double.NaN;
        }
    }

}
