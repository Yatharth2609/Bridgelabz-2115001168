using System;
using System.IO;

class Program
{
    static void Main()
    {
        string filePath = "employees.csv";
        Console.Write("Enter employee name to search: ");
        string searchName = Console.ReadLine();
        
        if (File.Exists(filePath))
        {
            string[] lines = File.ReadAllLines(filePath);
            bool found = false;
            for (int i = 1; i < lines.Length; i++)
            {
                string[] values = lines[i].Split(',');
                if (values[1].Equals(searchName, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"Department: {values[2]}, Salary: {values[3]}");
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                Console.WriteLine("Employee not found.");
            }
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }
}