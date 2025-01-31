using System;
class EmployeeDetails
{
    private string name;
    private int id;
    private double salary;

    public EmployeeDetails(string name, int id, double salary) {
        this.name = name;
        this.id = id;
        this.salary = salary;
    }

    public void Display() {
        Console.WriteLine("Employee Personal Details:");
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"ID: {id}");
            Console.WriteLine($"Salary: {salary:C}");

    }

    public static void Main(string[] args) {
        EmployeeDetails emp1 = new EmployeeDetails("Vishal", 101, 50000.00);
        EmployeeDetails emp2 = new EmployeeDetails("Divyanshu", 102, 60000.00);
        EmployeeDetails emp3 = new EmployeeDetails("Kislay", 103, 80000.00);

        emp1.Display();
        Console.WriteLine();

        emp2.Display();
        Console.WriteLine();

        emp3.Display();

    }
}