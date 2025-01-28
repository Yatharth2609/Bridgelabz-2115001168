using System;

public class QuadraticEquation
{
    // This function finds the roots of the quadratic equation
    private static void Compute(double a, double b, double c)
    {
        double delta = Math.Pow(b, 2) - 4 * a * c;
        if (delta > 0)
        {
            double rt1 = (-b + Math.Sqrt(delta)) / (2 * a);
            double rt2 = (-b - Math.Sqrt(delta)) / (2 * a);
            Console.WriteLine($"The two roots are: root1 = {rt1:F2} and root2 = {rt2:F2}");
        }
        else if (delta == 0)
        {
            double rt = -b / (2 * a);
            Console.WriteLine($"There is only one root: root = {rt:F2}");
        }
        else
        {
            Console.WriteLine("There are no real roots (delta is negative).");
        }
    }
	
    public static void Main(string[] args)
    {
        Console.Write("Enter the value of a: ");
        double a = Convert.ToDouble(Console.ReadLine());
        Console.Write("Enter the value of b: ");
        double b = Convert.ToDouble(Console.ReadLine());
        Console.Write("Enter the value of c: ");
        double c = Convert.ToDouble(Console.ReadLine());
        Compute(a, b, c);
    }
}
