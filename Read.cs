using System;
using System.IO;

class Program
{
    static void Main()
    {
        string filePath = "students.csv";
        if (File.Exists(filePath))
        {
            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                string[] values = line.Split(',');
                Console.WriteLine($"ID: {values[0]}, Name: {values[1]}, Age: {values[2]}, Marks: {values[3]}");
            }
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }
}