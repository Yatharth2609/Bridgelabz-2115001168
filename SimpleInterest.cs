using System;

public class SimpleInterest {
    public static void Main(string[] args) {
        Console.Write("Enter the principle amount: ");
        int p = int.Parse(Console.ReadLine());

        Console.Write("Enter the time duration: ");
        int t = int.Parse(Console.ReadLine());

	Console.Write("Enter the rate: ");
	int r = int.Parse(Console.ReadLine());

        double si = (p * t * r) / 100;

        Console.WriteLine("Area of circle is: " + Math.Round(si, 2));
    }
}





