using System;

public class PrimeNumber
{
    public static void Main(string[] args)
    {
        Console.Write("Enter a number to check if it is prime: ");
        int number = int.Parse(Console.ReadLine());

        if (IsPrime(number))
        {
            Console.WriteLine($"{number} is a Prime Number.");
        }
        else
        {
            Console.WriteLine($"{number} is not a Prime Number.");
        }
    }

	// The function checks whether the number is prime or not
    private static bool IsPrime(int num)
    {
        if (num <= 1)
            return false;

        for (int i = 2; i <= Math.Sqrt(num); i++)
        {
            if (num % i == 0)
                return false;
        }
        return true;
    }

}
