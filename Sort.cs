using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        string filePath = "employees.csv";
        
        if (File.Exists(filePath))
        {
            string[] lines = File.ReadAllLines(filePath);
            var sortedEmployees = lines.Skip(1)
                .Select(line => line.Split(','))
                .Where(values => decimal.TryParse(values[3], out _))
                .OrderByDescending(values => decimal.Parse(values[3]))
                .Take(5)
                .ToList();
            
            Console.WriteLine("Top 5 highest-paid employees:");
            foreach (var values in sortedEmployees)
            {
                Console.WriteLine($"ID: {values[0]}, Name: {values[1]}, Department: {values[2]}, Salary: {values[3]}");
            }
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }
}
