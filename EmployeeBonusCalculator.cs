using System;

public class EmployeeBonusCalculator
{
    private const int NUM_EMPLOYEES = 10;
    private const double BONUS_RATE_SENIOR = 0.05;  
    private const double BONUS_RATE_JUNIOR = 0.02; 
    private const int COMPANY_AGE = 10; 

    public static double[,] GenerateEmployeeData()
    {
        Random rand = new Random();
        double[,] employeeData = new double[NUM_EMPLOYEES, 2];  // [salary, years]

        for (int i = 0; i < NUM_EMPLOYEES; i++)
        {
           
            employeeData[i, 0] = rand.Next(10000, 100000);
            employeeData[i, 1] = rand.Next(0, COMPANY_AGE + 1);
        }

        return employeeData;
    }

    // Calculate new salaries and bonuses
    public static double[,] CalculateNewSalariesAndBonuses(double[,] employeeData)
    {
        double[,] results = new double[NUM_EMPLOYEES, 2];  // [new salary, bonus]

        for (int i = 0; i < NUM_EMPLOYEES; i++)
        {
            double currentSalary = employeeData[i, 0];
            double yearsOfService = employeeData[i, 1];
            
            
            double bonusRate = yearsOfService > 5 ? BONUS_RATE_SENIOR : BONUS_RATE_JUNIOR;
            double bonus = currentSalary * bonusRate;

            double newSalary = currentSalary + bonus;
            
            results[i, 0] = newSalary;
            results[i, 1] = bonus;
        }

        return results;
    }

    public static void DisplayResults(double[,] employeeData, double[,] results)
    {
        double totalOldSalary = 0;
        double totalNewSalary = 0;
        double totalBonus = 0;

        Console.WriteLine("\n{0,-5} {1,-12} {2,-8} {3,-12} {4,-12}", 
            "Emp#", "Old Salary", "Years", "Bonus", "New Salary");
        Console.WriteLine(new string('-', 55));

        for (int i = 0; i < NUM_EMPLOYEES; i++)
        {
            double oldSalary = employeeData[i, 0];
            double years = employeeData[i, 1];
            double bonus = results[i, 1];
            double newSalary = results[i, 0];

            Console.WriteLine("{0,-5} {1,-12:C2} {2,-8:F1} {3,-12:C2} {4,-12:C2}", 
                i + 1, oldSalary, years, bonus, newSalary);

            totalOldSalary += oldSalary;
            totalNewSalary += newSalary;
            totalBonus += bonus;
        }

        Console.WriteLine(new string('-', 55));
        Console.WriteLine("\nSummary:");
        Console.WriteLine($"Total Old Salary: {totalOldSalary:C2}");
        Console.WriteLine($"Total New Salary: {totalNewSalary:C2}");
        Console.WriteLine($"Total Bonus Amount: {totalBonus:C2}");
        Console.WriteLine($"Percentage Increase: {((totalNewSalary - totalOldSalary) / totalOldSalary * 100):F2}%");
    }

    public static void Main(string[] args)
    {
            Console.WriteLine($"Calculating bonuses for {NUM_EMPLOYEES} employees at Zara ({COMPANY_AGE} years old)");
            Console.WriteLine($"Bonus rates: {BONUS_RATE_SENIOR * 100}% for >5 years, {BONUS_RATE_JUNIOR * 100}% for ≤5 years");

            double[,] employeeData = GenerateEmployeeData();

s
            double[,] results = CalculateNewSalariesAndBonuses(employeeData);

            DisplayResults(employeeData, results);
        
    }
}