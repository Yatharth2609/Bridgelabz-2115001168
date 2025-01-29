using System;

public class TimeZone
{
    public static void Main(string[] args)
    {
        DateTimeOffset utcTime = DateTimeOffset.UtcNow;
        Console.WriteLine("Current UTC Time: " + utcTime.ToString("yyyy-MM-dd HH:mm:ss"));

        Compute(utcTime, "GMT Standard Time", "GMT Time");
        Compute(utcTime, "India Standard Time", "IST Time");
        Compute(utcTime, "Pacific Standard Time", "PST Time");
    }

    private static void Compute(DateTimeOffset utcTime, string timeZoneId, string label)
    {
        TimeZoneInfo timeZone = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
        DateTimeOffset localTime = TimeZoneInfo.ConvertTime(utcTime, timeZone);
        Console.WriteLine($"{label}: {localTime:yyyy-MM-dd HH:mm:ss}");
    }
}