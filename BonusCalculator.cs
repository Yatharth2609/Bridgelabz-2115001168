using System;

public class BonusCalculator
{
    // Method to calculate bonus and update new salary
    private static void Compute(double[] salaries, double[] yearsOfService, double[] bonuses, double[] newSalaries, out double totalBonus, out double totalOldSalary, out double totalNewSalary)
    {
        totalBonus = 0;
        totalOldSalary = 0;
        totalNewSalary = 0;

        for (int i = 0; i < salaries.Length; i++)
        {
            if (yearsOfService[i] > 5)
            {
                bonuses[i] = 0.05 * salaries[i];
            }
            else
            {
                bonuses[i] = 0.02 * salaries[i];
            }

            newSalaries[i] = salaries[i] + bonuses[i];
            totalBonus += bonuses[i];
            totalOldSalary += salaries[i];
            totalNewSalary += newSalaries[i];
        }
    }

    public static void Main(string[] args)
    {
        const int numberOfEmployees = 10;
        double[] salaries = new double[numberOfEmployees];
        double[] yearsOfService = new double[numberOfEmployees];
        double[] bonuses = new double[numberOfEmployees];
        double[] newSalaries = new double[numberOfEmployees];
        double totalBonus, totalOldSalary, totalNewSalary;

        for (int i = 0; i < numberOfEmployees; i++)
        {
            Console.WriteLine($"Enter details for Employee {i + 1}:");

            while (true)
            {
                Console.Write("Salary: ");
                if (double.TryParse(Console.ReadLine(), out salaries[i]) && salaries[i] > 0)
                    break;
                Console.WriteLine("Invalid input! Salary must be a positive number. Please try again.");
            }

            while (true)
            {
                Console.Write("Years of Service: ");
                if (double.TryParse(Console.ReadLine(), out yearsOfService[i]) && yearsOfService[i] >= 0)
                    break;
                Console.WriteLine("Invalid input! Years of service must be a non-negative number. Please try again.");
            }
        }

        Compute(salaries, yearsOfService, bonuses, newSalaries, out totalBonus, out totalOldSalary, out totalNewSalary);

 
        Console.WriteLine("\n--- Employee Bonus and Salary Details ---");
        for (int i = 0; i < numberOfEmployees; i++)
        {
            Console.WriteLine($"Employee {i + 1}:");
            Console.WriteLine($"  Old Salary: {salaries[i]:C}");
            Console.WriteLine($"  Bonus: {bonuses[i]:C}");
            Console.WriteLine($"  New Salary: {newSalaries[i]:C}");
        }

        Console.WriteLine("\n--- Total Details ---");
        Console.WriteLine($"Total Old Salary: {totalOldSalary:C}");
        Console.WriteLine($"Total Bonus Payout: {totalBonus:C}");
        Console.WriteLine($"Total New Salary: {totalNewSalary:C}");
    }
}
