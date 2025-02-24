using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string file1 = "students1.csv";
        string file2 = "students2.csv";
        string outputFile = "merged_students.csv";
        
        if (File.Exists(file1) && File.Exists(file2))
        {
            var students1 = File.ReadAllLines(file1).Skip(1)
                .Select(line => line.Split(','))
                .ToDictionary(values => values[0], values => new { ID = values[0], Name = values[1], Age = values[2] });
            
            var students2 = File.ReadAllLines(file2).Skip(1)
                .Select(line => line.Split(','))
                .ToDictionary(values => values[0], values => new { Marks = values[1], Grade = values[2] });
            
            var mergedData = new List<string> { "ID,Name,Age,Marks,Grade" };
            
            foreach (var id in students1.Keys)
            {
                if (students2.ContainsKey(id))
                {
                    var student1 = students1[id];
                    var student2 = students2[id];
                    mergedData.Add($"{student1.ID},{student1.Name},{student1.Age},{student2.Marks},{student2.Grade}");
                }
            }
            
            File.WriteAllLines(outputFile, mergedData);
            Console.WriteLine("CSV files merged successfully.");
        }
        else
        {
            Console.WriteLine("One or both input files not found.");
        }
    }
}
