using System;

public class Grading
{
    static void Main(string[] args)
    {
        // Input marks
        Console.Write("Enter marks for Physics: ");
        double physics = double.Parse(Console.ReadLine());

        Console.Write("Enter marks for Chemistry: ");
        double chemistry = double.Parse(Console.ReadLine());

        Console.Write("Enter marks for Maths: ");
        double maths = double.Parse(Console.ReadLine());

        // Calculate average and percentage
        double average = CalculateAverage(physics, chemistry, maths);
        double percentage = CalculatePercentage(physics, chemistry, maths);

        // Get grade and remarks
        (string grade, string remarks) = GetGradeAndRemarks(percentage);

        // Display results
        Console.WriteLine($"\nAverage Marks: {average:F2}");
        Console.WriteLine($"Percentage: {percentage:F2}%");
        Console.WriteLine($"Grade: {grade}");
        Console.WriteLine($"Remarks: {remarks}");
    }

    public static double CalculateAverage(double physics, double chemistry, double maths)
    {
        return (physics + chemistry + maths) / 3; // Average calculation
    }

    public static double CalculatePercentage(double physics, double chemistry, double maths)
    {
        return ((physics + chemistry + maths) / 300) * 100; // Percentage calculation
    }

    public static (string, string) GetGradeAndRemarks(double percentage)
    {
        if (percentage >= 80)
            return ("A", "Level 4, above agency-normalized standards");
        else if (percentage >= 70)
            return ("B", "Level 3, at agency-normalized standards");
        else if (percentage >= 60)
            return ("C", "Level 2, below but approaching agency-normalized standards");
        else if (percentage >= 50)
            return ("D", "Level 1, well below agency-normalized standards");
        else if (percentage >= 40)
            return ("E", "Level 1-, too below agency-normalized standards");
        else
            return ("R", "Remedial standards");
    }
}
