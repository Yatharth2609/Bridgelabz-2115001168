using System;

public class CompareDates
{
    public static void Main(string[] args)
    {
        Console.Write("Enter first date (yyyy-MM-dd): ");
        DateTime date1 = DateTime.Parse(Console.ReadLine());
        
        Console.Write("Enter second date (yyyy-MM-dd): ");
        DateTime date2 = DateTime.Parse(Console.ReadLine());
        
        CompareDates(date1, date2);
    }

	//The function is used to compare two dates
    private static void CompareDates(DateTime date1, DateTime date2)
    {
        int result = date1.CompareTo(date2);
        
        if (result < 0)
            Console.WriteLine("The first date is before the second date.");
        else if (result > 0)
            Console.WriteLine("The first date is after the second date.");
        else
            Console.WriteLine("Both dates are the same.");
    }
}
