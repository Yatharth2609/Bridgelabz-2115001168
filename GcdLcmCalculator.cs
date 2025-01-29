using System;

public class GcdLcmCalculator
{

    // Method to calculate the GCD using Euclidean algorithm
    public static int CalculateGCD(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }

    // Method to calculate the LCM
    public static int CalculateLCM(int a, int b)
    {
        return Math.Abs(a * b) / CalculateGCD(a, b); // Using the formula LCM(a, b) = |a * b| / GCD(a, b)
    }

    // Method to display the result
    public static void DisplayResult(int gcd, int lcm)
    {
        Console.WriteLine($"The GCD is: {gcd}");
        Console.WriteLine($"The LCM is: {lcm}");
    }

    public static void Main(string[] args)
    {
 
        Console.Write("Enter the first number: ");
        int num1 = int.Parse(Console.ReadLine());
        Console.Write("Enter the second number: ");
        int num2 = int.Parse(Console.ReadLine());
		
        int gcd = CalculateGCD(num1, num2);
        int lcm = CalculateLCM(num1, num2);
        DisplayResult(gcd, lcm);
    }
}
