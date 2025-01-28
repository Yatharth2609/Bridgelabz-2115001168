using System;

public class ConvertUnit
{
    // This function converts kilometers to miles
    private static double Km2Miles(double km)
    {
        double kmTomiles = 0.621371;
        return km * kmTomiles;
    }
	
    // This function converts miles to kilometers
    private static double Miles2Km(double miles)
    {
        double milesTokm = 1.60934;
        return miles * milesTokm;
    }
	
    // This function converts meters to feet
    private static double Mtrs2Feet(double mtrs)
    {
        double mtrsToft = 3.28084;
        return mtrs * mtrsToft;
    }
	
    // This function converts feet to meters
    private static double Feet2Mtrs(double ft)
    {
        double feetTomtrs = 0.3048;
        return ft * feetTomtrs;
    }
	
    public static void Main(string[] args)
    {
        Console.WriteLine("Unit Converter Utility\n");
        Console.Write("Enter distance in kilometers: ");
        double km = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine($"{km} kilometers is equal to {Km2Miles(km)} miles.\n");
        Console.Write("Enter distance in miles: ");
        double miles = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine($"{miles} miles is equal to {Miles2Km(miles)} kilometers.\n");
        Console.Write("Enter distance in meters: ");
        double mtrs = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine($"{mtrs} meters is equal to {Feet2Mtrs(mtrs)} feet.\n");
        Console.Write("Enter distance in feet: ");
        double ft = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine($"{ft} feet is equal to {Feet2Mtrs(ft)} meters.\n");
    }
}
