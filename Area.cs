using System;

public class Area {
    public static void Main(string[] args) {
        Console.Write("Enter the radius of the cirlce: ");
        int rad = int.Parse(Console.ReadLine());

        double area = Math.PI * rad * rad;

        Console.WriteLine("Area of circle is: " + area);
    }
}


