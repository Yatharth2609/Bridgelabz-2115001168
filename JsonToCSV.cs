using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

class Program
{
    static void Main()
    {
        string jsonFilePath = "students.json";
        string csvFilePath = "students.csv";
        string outputJsonFilePath = "students_converted.json";

        ConvertJsonToCsv(jsonFilePath, csvFilePath);
        ConvertCsvToJson(csvFilePath, outputJsonFilePath);
    }

    static void ConvertJsonToCsv(string jsonFilePath, string csvFilePath)
    {
        if (File.Exists(jsonFilePath))
        {
            var students = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(File.ReadAllText(jsonFilePath));
            if (students == null || students.Count == 0)
            {
                Console.WriteLine("No data found in JSON file.");
                return;
            }
            
            var headers = string.Join(",", students.First().Keys);
            var csvLines = new List<string> { headers };
            csvLines.AddRange(students.Select(student => string.Join(",", student.Values)));
            
            File.WriteAllLines(csvFilePath, csvLines);
            Console.WriteLine("JSON converted to CSV successfully.");
        }
        else
        {
            Console.WriteLine("JSON file not found.");
        }
    }

    static void ConvertCsvToJson(string csvFilePath, string outputJsonFilePath)
    {
        if (File.Exists(csvFilePath))
        {
            var lines = File.ReadAllLines(csvFilePath);
            if (lines.Length < 2)
            {
                Console.WriteLine("No data found in CSV file.");
                return;
            }

            var headers = lines[0].Split(',');
            var students = lines.Skip(1)
                .Select(line => line.Split(','))
                .Select(values => headers.Zip(values, (key, value) => new { key, value })
                    .ToDictionary(pair => pair.key, pair => pair.value))
                .ToList();
            
            File.WriteAllText(outputJsonFilePath, JsonConvert.SerializeObject(students, Formatting.Indented));
            Console.WriteLine("CSV converted to JSON successfully.");
        }
        else
        {
            Console.WriteLine("CSV file not found.");
        }
    }
}
