using System;

class Employee
{

    private static string companyName = "Google";
    private static int totalEmployees = 0;

    public readonly int Id;
    public string Name;
    public string Designation;

    public static string CompanyName
    {
        get { return companyName; }
        set
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                companyName = value;
                Console.WriteLine($"Company name updated to: {companyName}");
            }
            else
            {
                Console.WriteLine("Company name cannot be empty.");
            }
        }
    }

    public Employee(string Name, int Id, string Designation)
    {
        this.Name = Name;
        this.Id = Id;
        this.Designation = Designation;
        totalEmployees++;
    }

    // Static method to display total number of employees
    public static void DisplayTotalEmployees()
    {
        Console.WriteLine($"Total Employees: {totalEmployees}");
    }

    // Method to display employee details using 'is' operator
    public void DisplayEmployeeDetails()
    {
        if (this is Employee)
        {
            Console.WriteLine($"Company: {companyName}");
            Console.WriteLine($"Employee Name: {Name}");
            Console.WriteLine($"Employee ID: {Id}");
            Console.WriteLine($"Designation: {Designation}");
        }
    }
}

class Program
{
    static void Main()
    {

        Employee emp1 = new Employee("Yatharth", 101, "Software Engineer");
        Employee emp2 = new Employee("Aman", 102, "Project Manager");

        Console.WriteLine("Before Changing Company Name:");
        emp1.DisplayEmployeeDetails();
        Console.WriteLine();
        emp2.DisplayEmployeeDetails();

        Console.WriteLine("\nChanging Company Name...\n");

        Employee.CompanyName = "Tesla";

        Console.WriteLine("\nAfter Changing Company Name:");
        emp1.DisplayEmployeeDetails();
        Console.WriteLine();
        emp2.DisplayEmployeeDetails();

        Console.WriteLine();

        Employee.DisplayTotalEmployees();
    }
}
