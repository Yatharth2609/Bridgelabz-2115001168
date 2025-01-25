using System;

public class StudentGrades2
{
    // Method to calculate percentage using 2D array
    private static double CalculatePercentage(int[] subjectMarks)
    {
        double total = 0;
        for (int i = 0; i < subjectMarks.Length; i++)
        {
            total += subjectMarks[i];
        }
        return total / subjectMarks.Length;
    }

    // Method to determine grade based on percentage
    private static string DetermineGrade(double percentage)
    {
        if (percentage >= 80)
            return "A";
        else if (percentage >= 70)
            return "B";
        else if (percentage >= 60)
            return "C";
        else if (percentage >= 50)
            return "D";
        else if (percentage >= 40)
            return "E";
        else
            return "R";
    }

    public static void Main(string[] args)
    {
        Console.Write("Enter the number of students: ");
        int numStudents;
        while (!int.TryParse(Console.ReadLine(), out numStudents) || numStudents <= 0)
        {
            Console.WriteLine("Invalid input! Please enter a positive integer.");
            Console.Write("Enter the number of students: ");
        }

       
        int[,] studentMarks = new int[numStudents, 3];
        double[] percentages = new double[numStudents];
        string[] grades = new string[numStudents];
        string[] subjects = { "Physics", "Chemistry", "Maths" };

       
        for (int i = 0; i < numStudents; i++)
        {
            Console.WriteLine($"\nStudent {i + 1}:");
            for (int j = 0; j < subjects.Length; j++)
            {
                Console.Write($"Enter marks in {subjects[j]}: ");
                while (!int.TryParse(Console.ReadLine(), out studentMarks[i, j]) || studentMarks[i, j] < 0)
                {
                    Console.WriteLine("Invalid input! Marks must be a non-negative number.");
                    Console.Write($"Enter marks in {subjects[j]}: ");
                }
            }

            
            int[] currentStudentMarks = new int[3];
            for (int j = 0; j < 3; j++)
            {
                currentStudentMarks[j] = studentMarks[i, j];
            }

            percentages[i] = CalculatePercentage(currentStudentMarks);
            grades[i] = DetermineGrade(percentages[i]);
        }

        // Display results
        Console.WriteLine("\n--- Students Report ---");
        Console.WriteLine("Student\tPhysics\tChemistry\tMaths\tPercentage\tGrade");
        for (int i = 0; i < numStudents; i++)
        {
            Console.WriteLine($"{i + 1}\t{studentMarks[i, 0]}\t{studentMarks[i, 1]}\t\t{studentMarks[i, 2]}\t{percentages[i]:0.00}\t\t{grades[i]}");
        }
    }
}