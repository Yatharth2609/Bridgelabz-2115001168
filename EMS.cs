// using System;
// using System.Collections.Generic;

// abstract class Employee
// {
//     private int employeeId;
//     private string name;
//     private double baseSalary;

//     public int EmployeeId
//     {
//         get { return employeeId; }
//         set { employeeId = value; }
//     }

//     public string Name
//     {
//         get { return name; }
//         set { name = value; }
//     }

//     public double BaseSalary
//     {
//         get { return baseSalary; }
//         set { baseSalary = value; }
//     }

//     public abstract double CalculateSalary();

//     public void DisplayDetails()
//     {
//         Console.WriteLine($"Employee ID: {EmployeeId}");
//         Console.WriteLine($"Name: {Name}");
//         Console.WriteLine($"Base Salary: {BaseSalary}");
//         Console.WriteLine($"Calculated Salary: {CalculateSalary()}");
//     }
// }

// class FullTimeEmployee : Employee
// {
//     public override double CalculateSalary()
//     {
//         return BaseSalary;
//     }
// }

// class PartTimeEmployee : Employee
// {
//     private int hoursWorked;
//     private double hourlyRate;

//     public int HoursWorked
//     {
//         get { return hoursWorked; }
//         set { hoursWorked = value; }
//     }

//     public double HourlyRate
//     {
//         get { return hourlyRate; }
//         set { hourlyRate = value; }
//     }

//     public override double CalculateSalary()
//     {
//         return HoursWorked * HourlyRate;
//     }
// }

// interface IDepartment
// {
//     void AssignDepartment(string department);
//     string GetDepartmentDetails();
// }

// class Department : IDepartment
// {
//     private string department;

//     public void AssignDepartment(string department)
//     {
//         this.department = department;
//     }

//     public string GetDepartmentDetails()
//     {
//         return department;
//     }
// }

// class Program
// {
//     static void Main(string[] args)
//     {
//         List<Employee> employees = new List<Employee>();

//         FullTimeEmployee fullTimeEmployee = new FullTimeEmployee();
//         fullTimeEmployee.EmployeeId = 1;
//         fullTimeEmployee.Name = "Rajesh";
//         fullTimeEmployee.BaseSalary = 50000;
//         employees.Add(fullTimeEmployee);

//         PartTimeEmployee partTimeEmployee = new PartTimeEmployee();
//         partTimeEmployee.EmployeeId = 2;
//         partTimeEmployee.Name = "Priyanka";
//         partTimeEmployee.HoursWorked = 20;
//         partTimeEmployee.HourlyRate = 25;
//         employees.Add(partTimeEmployee);

//         foreach (var employee in employees)
//         {
//             employee.DisplayDetails();
//         }
//     }
// }