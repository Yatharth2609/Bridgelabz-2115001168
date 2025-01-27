using System;

public class Calendar {
    private static readonly string[] months = {
        "January", "February", "March", "April", "May", "June",
        "July", "August", "September", "October", "November", "December"
    };
    
    private static readonly int[] daysInMonth = {
        31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31
    };

    // Get month name
    private static string GetMonthName(int month) {
        return months[month - 1];
    }

    // Check if year is leap year
    private static bool IsLeapYear(int year) {
        return (year % 4 == 0 && year % 100 != 0) || (year % 400 == 0);
    }

    // Get number of days in month
    private static int GetDaysInMonth(int month, int year) {
        if (month == 2 && IsLeapYear(year))
            return 29;
        return daysInMonth[month - 1];
    }

    // Get first day of month using Gregorian calendar algorithm
    private static int GetFirstDayOfMonth(int month, int year) {
        int y0 = year - (14 - month) / 12;
        int x = y0 + y0/4 - y0/100 + y0/400;
        int m0 = month + 12 * ((14 - month) / 12) - 2;
        return (1 + x + (31 * m0) / 12) % 7;
    }

    public static void DisplayCalendar(int month, int year) {
        Console.WriteLine($"\n{GetMonthName(month)} {year}");
        Console.WriteLine("Sun Mon Tue Wed Thu Fri Sat");

        int firstDay = GetFirstDayOfMonth(month, year);
        int daysInMonth = GetDaysInMonth(month, year);


        for (int i = 0; i < firstDay; i++) {
            Console.Write("   ");
        }

        for (int day = 1; day <= daysInMonth; day++) {
            Console.Write($"{day,3}");
            
            if ((day + firstDay) % 7 == 0 || day == daysInMonth) {
                Console.WriteLine();
            }
        }
    }

    static void Main(string[] args) {
        Console.Write("Enter month (1-12): ");
        int month = int.Parse(Console.ReadLine());
        
        Console.Write("Enter year: ");
        int year = int.Parse(Console.ReadLine());

        if (month < 1 || month > 12) {
            Console.WriteLine("Invalid month. Please enter a number between 1 and 12.");
            return;
        }

        DisplayCalendar(month, year);
    }
}