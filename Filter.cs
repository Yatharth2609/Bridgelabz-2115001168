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
            Console.WriteLine("Students who scored more than 80 marks:");
            for (int i = 1; i < lines.Length; i++)
            {
                string[] values = lines[i].Split(',');
                if (int.TryParse(values[3], out int marks) && marks > 80)
                {
                    Console.WriteLine($"ID: {values[0]}, Name: {values[1]}, Age: {values[2]}, Marks: {values[3]}");
                }
            }
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }
}
