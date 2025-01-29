using System;

public class Fibonacci
{
    static void Main(string[] args)
    {
		Console.Write("Enter a number: ");
        int terms = Convert.ToInt32(Console.ReadLine());
        GenerateFibonacci(terms);
    }
	
	//The function is used to calculate and print fibonacci series
    private static void GenerateFibonacci(int terms)
    {
        int first = 0, second = 1, next;
        Console.WriteLine("Fibonacci Sequence:");
        
        for (int i = 0; i < terms; i++)
        {
            Console.Write(first + " ");
            next = first + second;
            first = second;
            second = next;
        }
        Console.WriteLine();
    }
}
