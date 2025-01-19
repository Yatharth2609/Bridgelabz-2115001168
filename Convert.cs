using System;

public class Convert {
    public static void Main(string[] args) {
        Console.Write("Enter the distance in kilometers: ");
        int km = int.Parse(Console.ReadLine());

        double miles = km * 0.621371;

        Console.WriteLine("The distance in Miles is: " + Math.Round(miles, 2));
    }
}

