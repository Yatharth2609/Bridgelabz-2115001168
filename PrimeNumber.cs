using System;

public class PrimeNumber
{
    // Method to check if a number is prime
    public static bool IsPrime(int number)
    {
        if (number <= 1)
        {
            return false; 
        }

        for (int i = 2; i <= Math.Sqrt(number); i++)
        {
            if (number % i == 0) 
            {
                return false;
            }
        }
        return true; 
    }

    // Method to display the result
    public static void DisplayResult(bool isPrime)
    {
        if (isPrime)
        {
            Console.WriteLine("The number is prime.");
        }
        else
        {
            Console.WriteLine("The number is not prime.");
        }
    }

    static void Main(string[] args)
    {
        Console.Write("Enter a number to check if it's prime: ");
        int number = int.Parse(Console.ReadLine());

        bool isPrime = IsPrime(number);
        DisplayResult(isPrime);
    }
}
