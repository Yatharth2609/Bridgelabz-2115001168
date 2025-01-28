using System;

public class UnitConvertor2
{
    // This function converts Fahrenheit to Celsius
    public static double FahrenToCel(double fahren)
    {
        return (fahren - 32) * 5 / 9;
    }
	
    // This function converts Celsius to Fahrenheit
    pubilc static double CelToFahren(double cel)
    {
        return (cel * 9 / 5) + 32;
    }
	
    // This function converts pounds to kilograms
    public static double PoundsToKgs(double pounds)
    {
        double pounds2kgs = 0.453592;
        return pounds * pounds2kgs;
    }
	
    // This function converts kilograms to pounds
    public static double KgsToPounds(double kgs)
    {
        double kgs2pounds = 2.20462;
        return kgs * kgs2pounds;
    }
	
    // This function converts gallons to liters
    public static double GalnsToLtrs(double galns)
    {
        double galns2ltrs = 3.78541;
        return galns * galns2ltrs;
    }
	
    // This function converts liters to gallons
    public static double LtrsToGalns(double ltrs)
    {
        double ltrs2galns = 0.264172;
        return ltrs * ltrs2galns;
    }
	
	
    public static void Main(string[] args)
    {
        Console.WriteLine("Extended Unit Converter Utility\n");
        Console.Write("Enter temperature in Fahrenheit: ");
        double fahren = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine($"{fahren}°F is equal to {FahrenToCel(fahren):F2}°C.\n");
        Console.Write("Enter temperature in Celsius: ");
        double cel = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine($"{cel}°C is equal to {CelToFahren(cel):F2}°F.\n");

        Console.Write("Enter weight in pounds: ");
        double pounds = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine($"{pounds} pounds is equal to {PoundsToKgs(pounds):F2} kilograms.\n");

        Console.Write("Enter weight in kilograms: ");
        double kgs = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine($"{kgs} kilograms is equal to {KgsToPounds(kgs):F2} pounds.\n");

        Console.Write("Enter volume in gallons: ");
        double galns = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine($"{galns} gallons is equal to {GalnsToLtrs(galns):F2} liters.\n");
        Console.Write("Enter volume in liters: ");
        double ltrs = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine($"{ltrs} liters is equal to {LtrsToGalns(ltrs):F2} gallons.\n");
    }
}
