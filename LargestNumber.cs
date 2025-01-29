using System;

public class LargestNumber
{
    public static void Main(string[] args)
    {
        int num1 = GetIntegerInput("Enter first number: ");
        int num2 = GetIntegerInput("Enter second number: ");
        int num3 = GetIntegerInput("Enter third number: ");
        
        int max = FindMaximum(num1, num2, num3);
        Console.WriteLine("The maximum number is: " + max);
    }

	//The function is used to find largest between the 3 given numbers
    private static int GetIntegerInput(string message)
    {
        Console.Write(message);
        while (!int.TryParse(Console.ReadLine(), out int number))
        {
            Console.Write("Invalid input. Please enter a valid integer: ");
        }
        return number;
    }

    private static int FindMaximum(int a, int b, int c)
    {
        return Math.Max(a, Math.Max(b, c));
    }
}
