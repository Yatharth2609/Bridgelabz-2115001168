using System;

public class Volume {
    public static void Main(string[] args) {
        Console.Write("Enter the radius of the cylinder: ");
        int rad = int.Parse(Console.ReadLine());

	Console.Write("Enter the height of cylinder: ");
	int h = int.Parse(Console.ReadLine());

        double vol = Math.PI * rad * rad * h;

        Console.WriteLine("Area of circle is: " + vol);
    }
}
