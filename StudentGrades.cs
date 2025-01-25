using System;

public class StudentGrades
{
    // Method to calculate percentage
    private static double CalculatePercentage(int physics, int chemistry, int maths)
    {
        return (physics + chemistry + maths) / 3.0;
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

        int[] physicsMarks = new int[numStudents];
        int[] chemistryMarks = new int[numStudents];
        int[] mathsMarks = new int[numStudents];
        double[] percentages = new double[numStudents];
        string[] grades = new string[numStudents];

        for (int i = 0; i < numStudents; i++)
        {
            Console.WriteLine($"\nStudent {i + 1}:");

            // Physics marks input
            Console.Write("Enter marks in Physics: ");
            while (!int.TryParse(Console.ReadLine(), out physicsMarks[i]) || physicsMarks[i] < 0)
            {
                Console.WriteLine("Invalid input! Marks must be a non-negative number.");
                Console.Write("Enter marks in Physics: ");
            }

            // Chemistry marks input
            Console.Write("Enter marks in Chemistry: ");
            while (!int.TryParse(Console.ReadLine(), out chemistryMarks[i]) || chemistryMarks[i] < 0)
            {
                Console.WriteLine("Invalid input! Marks must be a non-negative number.");
                Console.Write("Enter marks in Chemistry: ");
            }

            // Maths marks input
            Console.Write("Enter marks in Maths: ");
            while (!int.TryParse(Console.ReadLine(), out mathsMarks[i]) || mathsMarks[i] < 0)
            {
                Console.WriteLine("Invalid input! Marks must be a non-negative number.");
                Console.Write("Enter marks in Maths: ");
            }


            percentages[i] = CalculatePercentage(physicsMarks[i], chemistryMarks[i], mathsMarks[i]);
            grades[i] = DetermineGrade(percentages[i]);
        }

        Console.WriteLine("\n--- Students Report ---");
        Console.WriteLine("Student\tPhysics\tChemistry\tMaths\tPercentage\tGrade");
        for (int i = 0; i < numStudents; i++)
        {
            Console.WriteLine($"{i + 1}\t{physicsMarks[i]}\t{chemistryMarks[i]}\t\t{mathsMarks[i]}\t{percentages[i]:0.00}\t\t{grades[i]}");
        }
    }
}
