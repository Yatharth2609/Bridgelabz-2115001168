using System;

public class Perimeter {
    public static void Main(string[] args) {
        Console.Write("Enter the length of the rectangle: ");
        int l = int.Parse(Console.ReadLine());

        Console.Write("Enter the width of the rectangle: ");
        int w = int.Parse(Console.ReadLine());

        int peri = 2 * (l + w);

        Console.WriteLine("Perimeter of the rectangle: " + peri);
    }
}





