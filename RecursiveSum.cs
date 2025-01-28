using System;
public class RecursiveSum
{
    public static void Main(string[] args)
    {
        Console.Write("Enter a natural number: ");
        int n = Convert.ToInt32(Console.ReadLine());
        if (n <= 0)
        {
            Console.WriteLine("The entered number is not a natural number. Exiting the program.");
            return;
        }
        int sumRecurse = RecursiveSum(n);
        int sumForm = NaturalNumSum(n);
        Console.WriteLine($"Sum of the first {n} natural numbers using recursion: {sumRecurse}");
        Console.WriteLine($"Sum of the first {n} natural numbers using formula: {sumForm}");
        if (sumRecurse == sumForm)
        {
            Console.WriteLine("Both methods give the same result. The computation is correct.");
        }
        else
        {
            Console.WriteLine("There is a discrepancy between the two methods. Please check the logic.");
        }
    }

    // This function finds the sum of n natural numbers using recursion
    private static int RecursiveSum(int n)
    {
        if (n == 1)
            return 1;
        return n + RecursiveSum(n - 1); 
    }

    // This function finds the sum of n natural numbers using the formula
    private static int NaturalNumSum(int n)
    {
        return n * (n + 1) / 2;
    }
}
