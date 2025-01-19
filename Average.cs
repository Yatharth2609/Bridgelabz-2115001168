using System;

public class Average {
    public static void Main(string[] args) {
        Console.Write("Enter the first number: ");
        int a = int.Parse(Console.ReadLine());

        Console.Write("Enter the second number: ");
        int b = int.Parse(Console.ReadLine());

	Console.Write("Enter the third number: ");
	int c = int.Parse(Console.ReadLine());

        double avg = (a + b + c) / 3;

        Console.WriteLine("The average of numbers are: " + avg);
    }
}

