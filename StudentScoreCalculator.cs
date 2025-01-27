using System;

public class StudentScoreCalculator
{
    private const int MAX_SCORE = 100; 
    private const int MIN_SCORE = 0;    

    // Generate random scores for Physics, Chemistry, and Math
    public static int[,] GenerateScores(int numStudents)
    {
        Random rand = new Random();
        int[,] scores = new int[numStudents, 3];

        for (int i = 0; i < numStudents; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                scores[i, j] = rand.Next(0, 100);
            }
        }

        return scores;
    }

    // Calculate total, average, and percentage for each student
    public static double[,] CalculateStatistics(int[,] scores, int numStudents)
    {
        double[,] statistics = new double[numStudents, 3];

        for (int i = 0; i < numStudents; i++)
        {
            double total = scores[i, 0] + scores[i, 1] + scores[i, 2];

            double average = total / 3.0;

            double percentage = (total / (3.0 * MAX_SCORE)) * 100;

            statistics[i, 0] = Math.Round(total, 2);
            statistics[i, 1] = Math.Round(average, 2);
            statistics[i, 2] = Math.Round(percentage, 2);
        }

        return statistics;
    }

    // Get grade based on percentage
    private static string GetGrade(double percentage)
    {
        if (percentage >= 80) return "A";
        if (percentage >= 70) return "B";
        if (percentage >= 60) return "C";
        if (percentage >= 50) return "D";
        if (percentage >= 40) return "E";
        return "R";
    }

    // Display scorecard in tabular format
    public static void DisplayScorecard(int[,] scores, double[,] statistics, int numStudents)
    {

        Console.WriteLine("\nStudent Scorecard");
        Console.WriteLine("================");
        Console.WriteLine("Student\tPhysics\tChem\tMath\tTotal\tAvg\tPercentage\tGrade");
        Console.WriteLine("----------------------------------------------------------------");

        for (int i = 0; i < numStudents; i++)
        {
            Console.WriteLine($"{i + 1}\t{scores[i, 0]}\t{scores[i, 1]}\t{scores[i, 2]}\t" +
                            $"{statistics[i, 0]}\t{statistics[i, 1]}\t{statistics[i, 2]}%\t" +
                            $"{GetGrade(statistics[i, 2])}");
        }

        double classAvgPhysics = 0, classAvgChem = 0, classAvgMath = 0;
        double classAvgTotal = 0, classAvgPercentage = 0;

        for (int i = 0; i < numStudents; i++)
        {
            classAvgPhysics += scores[i, 0];
            classAvgChem += scores[i, 1];
            classAvgMath += scores[i, 2];
            classAvgTotal += statistics[i, 0];
            classAvgPercentage += statistics[i, 2];
        }

        Console.WriteLine("\nClass Statistics");
        Console.WriteLine("===============");
        Console.WriteLine($"Average Physics Score: {Math.Round(classAvgPhysics / numStudents, 2)}");
        Console.WriteLine($"Average Chemistry Score: {Math.Round(classAvgChem / numStudents, 2)}");
        Console.WriteLine($"Average Math Score: {Math.Round(classAvgMath / numStudents, 2)}");
        Console.WriteLine($"Average Total Score: {Math.Round(classAvgTotal / numStudents, 2)}");
        Console.WriteLine($"Average Percentage: {Math.Round(classAvgPercentage / numStudents, 2)}%");
    }

    public static void Main(string[] args)
    {
            Console.Write("Enter the number of students: ");
            int numStudents = int.Parse(Console.ReadLine());

            if (numStudents <= 0)
            {
                Console.WriteLine("Please enter a positive number of students.");
                return;
            }

            int[,] scores = GenerateScores(numStudents);

            double[,] statistics = CalculateStatistics(scores, numStudents);

            DisplayScorecard(scores, statistics, numStudents);
   
    }
}