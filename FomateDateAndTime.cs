using System;

public class FomateDateAndTime
{
    public static void Main(string[] args)
    {
        DateTime currentDate = DateTime.Now;
        
        Console.WriteLine("Current Date in different formats:");
        Console.WriteLine("dd/MM/yyyy: " + currentDate.ToString("dd/MM/yyyy"));
        Console.WriteLine("yyyy-MM-dd: " + currentDate.ToString("yyyy-MM-dd"));
        Console.WriteLine("EEE, MMM dd, yyyy: " + currentDate.ToString("ddd, MMM dd, yyyy"));
    }
}
