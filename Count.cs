using System;
using System.IO;

class Program
{
    static void Main()
    {
        string filePath = "employees.csv";
        if (File.Exists(filePath))
        {
            string[] lines = File.ReadAllLines(filePath);
            int recordCount = lines.Length > 1 ? lines.Length - 1 : 0;
            Console.WriteLine($"Number of records: {recordCount}");
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }
}
