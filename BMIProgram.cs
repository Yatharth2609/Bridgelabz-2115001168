using System;

public class BMIProgram
{
    // Method to calculate BMI
    private static double CalculateBMI(double weight, double height)
    {
        return weight / (height * height);
    }

    // Method to determine weight status based on BMI
    private static string GetWeightStatus(double bmi)
    {
        if (bmi < 18.5)
            return "Underweight";
        else if (bmi >= 18.5 && bmi <= 24.9)
            return "Normal weight";
        else if (bmi >= 25.0 && bmi <= 29.9)
            return "Overweight";
        else
            return "Obesity";
    }

    public static void Main(string[] args)
    {
       
        Console.Write("Enter the number of persons: ");
        int numPersons;
        while (!int.TryParse(Console.ReadLine(), out numPersons) || numPersons <= 0)
        {
            Console.WriteLine("Invalid input! Please enter a positive integer.");
            Console.Write("Enter the number of persons: ");
        }

        double[] weights = new double[numPersons];
        double[] heights = new double[numPersons];
        double[] bmis = new double[numPersons];
        string[] statuses = new string[numPersons];

        for (int i = 0; i < numPersons; i++)
        {
            Console.WriteLine($"\nPerson {i + 1}:");

            // Weight input
            Console.Write("Enter weight (in kg): ");
            while (!double.TryParse(Console.ReadLine(), out weights[i]) || weights[i] <= 0)
            {
                Console.WriteLine("Invalid input! Weight must be a positive number.");
                Console.Write("Enter weight (in kg): ");
            }

            // Height input
            Console.Write("Enter height (in meters): ");
            while (!double.TryParse(Console.ReadLine(), out heights[i]) || heights[i] <= 0)
            {
                Console.WriteLine("Invalid input! Height must be a positive number.");
                Console.Write("Enter height (in meters): ");
            }


            bmis[i] = CalculateBMI(weights[i], heights[i]);
            statuses[i] = GetWeightStatus(bmis[i]);
        }

        Console.WriteLine("\n--- BMI Report ---");
        Console.WriteLine("Person\tHeight(m)\tWeight(kg)\tBMI\t\tStatus");
        for (int i = 0; i < numPersons; i++)
        {
            Console.WriteLine($"{i + 1}\t{heights[i]:0.00}\t\t{weights[i]:0.00}\t\t{bmis[i]:0.00}\t\t{statuses[i]}");
        }
    }
}
