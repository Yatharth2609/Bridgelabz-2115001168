using System;

public class UnitConvertor
{
    // This function converts yards to feet
    private static double YardsToFt(double yardLen)
    {
        return yardLen * 3;
    }

    // This function converts feet to yards
    private static double FtToYards(double ftLen)
    {
        return ftLen * 0.333333;
    }

    // This function converts meters to inches
    private static double MtrsToInches(double mtrLen)
    {
        return mtrLen * 39.3701;
    }

    // This function converts inches to meters
    private static double InchesToMtrs(double inchLen)
    {
        return inchLen * 0.0254;
    }

    // This function converts inches to centimeters
    private static double InchesToCm(double inchLen)
    {
        return inchLen * 2.54;
    }
	
	
    public static void Main(string[] args)
    {
        Console.WriteLine("Extended Unit Converter Utility\n");

        Console.Write("Enter length in yards: ");
        double userYards = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine($"{userYards} yards is equal to {YardsToFt(userYards):F2} feet.\n");

        Console.Write("Enter length in feet: ");
        double userFt = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine($"{userFt} feet is equal to {FtToYards(userFt):F6} yards.\n");

        Console.Write("Enter length in meters: ");
        double userMtrs = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine($"{userMtrs} meters is equal to {MtrsToInches(userMtrs):F2} inches.\n");

        Console.Write("Enter length in inches: ");
        double userInches = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine($"{userInches} inches is equal to {InchesToMtrs(userInches):F4} meters.\n");

        Console.Write("Enter length in inches: ");
        double userInches_Cm = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine($"{userInches_Cm} inches is equal to {InchesToCm(userInches_Cm):F2} centimeters.\n");
    }
}
