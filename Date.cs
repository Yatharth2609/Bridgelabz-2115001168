using System;

public class Date
{
    public static void Main(string[] args)
    {
        Console.Write("Enter a date (yyyy-MM-dd): ");
        if (DateTime.TryParse(Console.ReadLine(), out DateTime inputDate))
        {
            DateTime modifiedDate = PerformDateArithmetic(inputDate);
            Console.WriteLine("Final Date after operations: " + modifiedDate.ToString("yyyy-MM-dd"));
        }
        else
        {
            Console.WriteLine("Invalid date format. Please use yyyy-MM-dd.");
        }
    }

	//The function is used to take a date as input and adds 7 days, 1 month, and 2 years to it. 
    private static DateTime PerformDateArithmetic(DateTime date)
    {
        date = date.AddDays(7);
        date = date.AddMonths(1);
        date = date.AddYears(2);
        date = date.AddDays(-21); // Subtracting 3 weeks
        return date;
    }
}
