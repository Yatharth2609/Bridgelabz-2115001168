using System;

public class Calculator
{

    // Method to perform addition
    public static double Add(double a, double b)
    {
        return a + b;
    }

    // Method to perform subtraction
    public static double Subtract(double a, double b)
    {
        return a - b;
    }

    // Method to perform multiplication
    public static double Multiply(double a, double b)
    {
        return a * b;
    }

    // Method to perform division
    public static double Divide(double a, double b)
    {
        if (b == 0)
        {
            Console.WriteLine("Error: Division by zero is not allowed.");
            return double.NaN;
        }
        return a / b;
    }

    // Method to display the result
    public static void DisplayResult(double result, string operation)
    {
        if (!double.IsNaN(result))
        {
            Console.WriteLine($"The result of {operation} is: {result}");
        }
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Select an operation:");
        Console.WriteLine("1. Addition");
        Console.WriteLine("2. Subtraction");
        Console.WriteLine("3. Multiplication");
        Console.WriteLine("4. Division");

        string choice = Console.ReadLine();

        Console.Write("Enter the first number: ");
        double num1 = double.Parse(Console.ReadLine());
        Console.Write("Enter the second number: ");
        double num2 = double.Parse(Console.ReadLine());
		
        double result = 0;
        string operation = "";

        switch (choice)
        {
            case "1":
                result = Add(num1, num2);
                operation = "addition";
                break;
            case "2":
                result = Subtract(num1, num2);
                operation = "subtraction";
                break;
            case "3":
                result = Multiply(num1, num2);
                operation = "multiplication";
                break;
            case "4":
                result = Divide(num1, num2);
                operation = "division";
                break;
            default:
                Console.WriteLine("Invalid choice.");
                return;
        }
		
        DisplayResult(result, operation);
    }
}
