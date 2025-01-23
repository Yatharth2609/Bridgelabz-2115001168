using System;

public class FriendsComparison
{
    public static void Main(string[] args)
    {
        // Input for Amar
        Console.Write("Enter Amar's age: ");
        int amarAge = int.Parse(Console.ReadLine());
        Console.Write("Enter Amar's height in cm: ");
        double amarHeight = double.Parse(Console.ReadLine());

        // Input for Akbar
        Console.Write("Enter Akbar's age: ");
        int akbarAge = int.Parse(Console.ReadLine());
        Console.Write("Enter Akbar's height in cm: ");
        double akbarHeight = double.Parse(Console.ReadLine());

        // Input for Anthony
        Console.Write("Enter Anthony's age: ");
        int anthonyAge = int.Parse(Console.ReadLine());
        Console.Write("Enter Anthony's height in cm: ");
        double anthonyHeight = double.Parse(Console.ReadLine());

        // Find the youngest friend
        string youngest = FindYoungest(amarAge, akbarAge, anthonyAge);

        // Find the tallest friend
        string tallest = FindTallest(amarHeight, akbarHeight, anthonyHeight);

        // Display the results
        Console.WriteLine($"\nThe youngest friend is: {youngest}");
        Console.WriteLine($"The tallest friend is: {tallest}");
    }

    public static string FindYoungest(int amarAge, int akbarAge, int anthonyAge)
    {
        int minAge = Math.Min(amarAge, Math.Min(akbarAge, anthonyAge));
        
        if (minAge == amarAge)
            return "Amar";
        else if (minAge == akbarAge)
            return "Akbar";
        else
            return "Anthony";
    }

    public static string FindTallest(double amarHeight, double akbarHeight, double anthonyHeight)
    {
        double maxHeight = Math.Max(amarHeight, Math.Max(akbarHeight, anthonyHeight));
        
        if (maxHeight == amarHeight)
            return "Amar";
        else if (maxHeight == akbarHeight)
            return "Akbar";
        else
            return "Anthony";
    }
}
