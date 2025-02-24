using System;
using System.IO;

class Program
{
    static void Main()
    {
        string filePath = "employees.csv";
        string[] employees =
        {
            "ID,Name,Department,Salary",
            "1,Rajiv Singh,HR,50000",
            "2,Priya Sharma,IT,60000",
            "3,Suresh Kumar,Finance,55000",
            "4,Dhananjay Kumar,Marketing,58000",
            "5,Priyanka ,Operations,62000"
        };
        File.WriteAllLines(filePath, employees);
        Console.WriteLine("CSV file created successfully.");
    }
}
