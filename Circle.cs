using System;

public class Circle
{
    private double radius;

    public Circle(double radius)
    {
        this.radius = radius;
    }

    public double Area()
    {
        return Math.PI * radius * radius;
    }

    public double Circumference()
    {
        return 2 * Math.PI * radius;
    }

    public void Display()
    {
        Console.WriteLine("Circle Details:");
        Console.WriteLine($"Radius: {radius}");
        Console.WriteLine($"Area: {Math.Round(Area(), 2)}");
        Console.WriteLine($"Circumference: {Math.Round(Circumference(), 2)}");
    }
    public static void Main(string[] args)
    {
        Console.Write("Enter the radius of the circle: ");
        double radius = Convert.ToDouble(Console.ReadLine());
        Circle circle = new Circle(radius);
        circle.Display();

    }
}