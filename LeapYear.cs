using System;

public class LeapYear
{
    public static void Main(string[] args)
    {
        Console.Write("Enter a year (>= 1582): ");
        int yr = Convert.ToInt32(Console.ReadLine());
        if (yr < 1582)
        {
            Console.WriteLine("The program only works for years >= 1582. Exiting.");
            return;
        }
        bool isLeap = CheckLeap(yr);
        if (isLeap)
        {
            Console.WriteLine($"The year {yr} is a Leap Year.");
        }
        else
        {
            Console.WriteLine($"The year {yr} is NOT a Leap Year.");
        }
    }
    // This function checks if a year is a leap year
    private static bool CheckLeap(int yr)
    {
        return (yr % 4 == 0) && (yr % 100 != 0 || yr % 400 == 0);
    }
}
