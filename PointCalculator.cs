using System;

public class PointCalculator
{
    // Calculate Euclidean distance between two points
    public static double CalculateDistance(double x1, double y1, double x2, double y2)
    {
        double xDiff = Math.Pow(x2 - x1, 2);
        double yDiff = Math.Pow(y2 - y1, 2);
        return Math.Sqrt(xDiff + yDiff);
    }

    // Calculate line equation (returns array with slope and y-intercept)
    public static double[] CalculateLineEquation(double x1, double y1, double x2, double y2)
    {

        double slope = (y2 - y1) / (x2 - x1);
        

        double yIntercept = y1 - (slope * x1);
        
        return new double[] { slope, yIntercept };
    }

    // Format line equation as string
    public static string FormatLineEquation(double slope, double yIntercept)
    {
        string equation = "y = ";
        

        equation += slope == 1 ? "x" : 
                   slope == -1 ? "-x" : 
                   $"{slope:F2}x";

        if (yIntercept > 0)
            equation += $" + {yIntercept:F2}";
        else if (yIntercept < 0)
            equation += $" - {Math.Abs(yIntercept):F2}";
        
        return equation;
    }

    static void Main(string[] args)
    {

            Console.WriteLine("Enter coordinates for first point:");
            Console.Write("x1: ");
            double x1 = double.Parse(Console.ReadLine());
            Console.Write("y1: ");
            double y1 = double.Parse(Console.ReadLine());

            Console.WriteLine("\nEnter coordinates for second point:");
            Console.Write("x2: ");
            double x2 = double.Parse(Console.ReadLine());
            Console.Write("y2: ");
            double y2 = double.Parse(Console.ReadLine());

            double distance = CalculateDistance(x1, y1, x2, y2);
            Console.WriteLine($"\nEuclidean distance: {distance:F2} units");

           
            if (x1 == x2 && y1 == y2)
            {
                Console.WriteLine("Points are the same - no unique line equation exists.");
                return;
            }

            
            if (x1 == x2)
            {
                Console.WriteLine($"Vertical line equation: x = {x1:F2}");
                return;
            }

            double[] lineEquation = CalculateLineEquation(x1, y1, x2, y2);
            string equation = FormatLineEquation(lineEquation[0], lineEquation[1]);
            Console.WriteLine($"Line equation: {equation}");
        
    }
}