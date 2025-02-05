using System;
using System.Collections.Generic;

class Employee
{
    public string Name { get; }
    public string Position { get; }

    public Employee(string name, string position)
    {
        Name = name;
        Position = position;
    }

    public void DisplayEmployee()
    {
        Console.WriteLine($" - Employee: {Name}, Position: {Position}");
    }
}

class Department
{
    public string Name { get; }
    private List<Employee> employees;

    public Department(string name)
    {
        Name = name;
        employees = new List<Employee>();
    }

    public void AddEmployee(string name, string position)
    {
        employees.Add(new Employee(name, position));
    }

    public void DisplayDepartment()
    {
        Console.WriteLine($"Department: {Name}");
        if (employees.Count == 0)
        {
            Console.WriteLine(" No employees in this department.");
            return;
        }
        foreach (var emp in employees)
        {
            emp.DisplayEmployee();
        }
    }
}

class Company
{
    public string Name { get; }
    private List<Department> departments;

    public Company(string name)
    {
        Name = name;
        departments = new List<Department>();
    }

    public void AddDepartment(string departmentName)
    {
        departments.Add(new Department(departmentName));
    }

    public void AddEmployeeToDepartment(string departmentName, string employeeName, string position)
    {
        foreach (var dept in departments)
        {
            if (dept.Name == departmentName)
            {
                dept.AddEmployee(employeeName, position);
                return;
            }
        }
        Console.WriteLine($"Department '{departmentName}' not found.");
    }

    public void DisplayCompany()
    {
        Console.WriteLine($"\nCompany: {Name}");
        if (departments.Count == 0)
        {
            Console.WriteLine(" No departments found.");
            return;
        }
        foreach (var dept in departments)
        {
            dept.DisplayDepartment();
        }
    }

    ~Company()
    {
        Console.WriteLine($"\nCompany '{Name}' is being deleted, removing all departments and employees.");
    }
}

class Program
{
    static void Main()
    {
        Company myCompany = new Company("Capgemini");

        myCompany.AddDepartment("Software Development");
        myCompany.AddDepartment("Human Resources");

        myCompany.AddEmployeeToDepartment("Software Development", "Rajiv", "Software Engineer");
        myCompany.AddEmployeeToDepartment("Software Development", "Priyanka", "Tech Lead");
        myCompany.AddEmployeeToDepartment("Human Resources", "Ganesh", "HR Manager");

        myCompany.DisplayCompany();

        // Deleting Company (Automatically removes Departments & Employees)
        myCompany = null;
        GC.Collect(); // Forces garbage collection to demonstrate composition
    }
}
