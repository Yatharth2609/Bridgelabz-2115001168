using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        string filePath = "data.csv";
        
        if (File.Exists(filePath))
        {
            var records = new Dictionary<string, List<string>>();
            var duplicates = new List<string>();
            
            foreach (var line in File.ReadLines(filePath).Skip(1))
            {
                string[] values = line.Split(',');
                string id = values[0];
                
                if (records.ContainsKey(id))
                {
                    duplicates.Add(line);
                }
                else
                {
                    records[id] = new List<string> { line };
                }
            }
            
            if (duplicates.Count > 0)
            {
                Console.WriteLine("Duplicate records found:");
                foreach (var duplicate in duplicates)
                {
                    Console.WriteLine(duplicate);
                }
            }
            else
            {
                Console.WriteLine("No duplicate records found.");
            }
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }
}
