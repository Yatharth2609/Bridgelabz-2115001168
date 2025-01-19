using System;

public class Power {
    public static void Main(string[] args) {
        Console.Write("Enter the base number: ");
        double b = int.Parse(Console.ReadLine());

        Console.Write("Enter the exponent number: ");
        double p = int.Parse(Console.ReadLine());

        double pow = Math.Pow(b, p);

        Console.WriteLine("The value of the exponent is: " + pow);
    }
}
