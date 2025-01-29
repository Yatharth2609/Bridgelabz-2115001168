using System;

public class FactorialCalculator
{

    // Recursive method to calculate factorial
    public static int CalculateFactorial(int n)
    {
        if (n == 0 || n == 1) // Base case
        {
            return 1;
        }
        else
        {
            return n * CalculateFactorial(n - 1); // Recursive call
        }
    }

    // Method to display the result
    public static void DisplayResult(int result)
    {
        Console.WriteLine("The factorial is: " + result);
    }

    public static void Main(string[] args)
    {
         Console.Write("Enter a number to calculate its factorial: ");
         int number = int.Parse(Console.ReadLine());
		 
         int result = CalculateFactorial(number);
         DisplayResult(result);
    }
}
