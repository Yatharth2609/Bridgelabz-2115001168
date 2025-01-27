using System;

public class CollinearPointsChecker
{
    // Structure to represent a point
    public struct Point
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return $"({X}, {Y})";
        }
    }

    // Calculate slope between two points
    private static double CalculateSlope(Point p1, Point p2)
    {
        if (p1.X == p2.X)
            return double.MaxValue;

        return (p2.Y - p1.Y) / (p2.X - p1.X);
    }

    // Check collinearity using slopes method
    public static bool AreCollinearUsingSlopes(Point p1, Point p2, Point p3)
    {
        
        double slopeAB = CalculateSlope(p1, p2);
        double slopeBC = CalculateSlope(p2, p3);
        double slopeAC = CalculateSlope(p1, p3);

        const double epsilon = 0.0000001;
        
        if (slopeAB == double.MaxValue && slopeBC == double.MaxValue && slopeAC == double.MaxValue)
            return true;

        return Math.Abs(slopeAB - slopeBC) < epsilon && 
               Math.Abs(slopeBC - slopeAC) < epsilon;
    }

    // Check collinearity using area method
    public static bool AreCollinearUsingArea(Point p1, Point p2, Point p3)
    {
        
        double area = 0.5 * (
            p1.X * (p2.Y - p3.Y) +
            p2.X * (p3.Y - p1.Y) +
            p3.X * (p1.Y - p2.Y)
        );

        const double epsilon = 0.0000001;
        return Math.Abs(area) < epsilon;
    }

    public static void Main(string[] args)
    {
           
            Point[] points = new Point[3];
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"\nEnter coordinates for point {i + 1}:");
                Console.Write($"x{i + 1}: ");
                double x = double.Parse(Console.ReadLine());
                Console.Write($"y{i + 1}: ");
                double y = double.Parse(Console.ReadLine());
                points[i] = new Point(x, y);
            }

            bool collinearBySlopes = AreCollinearUsingSlopes(points[0], points[1], points[2]);
            bool collinearByArea = AreCollinearUsingArea(points[0], points[1], points[2]);

          
            Console.WriteLine("\nResults:");
            Console.WriteLine($"Points: {points[0]}, {points[1]}, {points[2]}");
            Console.WriteLine($"Collinear by slopes method: {collinearBySlopes}");
            Console.WriteLine($"Collinear by area method: {collinearByArea}");

            
    }
}