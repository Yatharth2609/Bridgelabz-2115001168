using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Xml.Linq;
using CsvHelper;
using System.Globalization;
using System.Data;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string jsonFilePath1 = "file1.json";
        string jsonFilePath2 = "file2.json";
        string csvFilePath = "data.csv";

        ReadJsonFile("data.json");
        ConvertListToJson();
        FilterJsonData("users.json");
        ValidateEmailUsingJsonSchema("{\"email\": \"test@example.com\"}");
        MergeJsonFiles(jsonFilePath1, jsonFilePath2);
        ConvertJsonToXml("data.json");
        ConvertCsvToJson(csvFilePath);
        GenerateJsonReportFromDatabase();
    }

    static void ReadJsonFile(string filePath)
    {
        string json = File.ReadAllText(filePath);
        JObject obj = JObject.Parse(json);
        foreach (var item in obj)
            Console.WriteLine($"{item.Key}: {item.Value}");
    }

    static void ConvertListToJson()
    {
        var users = new List<User>
        {
            new User { Id = 1, Name = "Alice", Age = 30 },
            new User { Id = 2, Name = "Bob", Age = 22 }
        };
        string json = JsonConvert.SerializeObject(users, Formatting.Indented);
        Console.WriteLine(json);
    }

    static void FilterJsonData(string filePath)
    {
        string json = File.ReadAllText(filePath);
        var users = JsonConvert.DeserializeObject<List<User>>(json);
        var filteredUsers = users.Where(u => u.Age > 25);
        Console.WriteLine(JsonConvert.SerializeObject(filteredUsers, Formatting.Indented));
    }

    static void ValidateEmailUsingJsonSchema(string json)
    {
        var obj = JObject.Parse(json);
        string email = obj["email"].ToString();
        bool isValid = Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        Console.WriteLine(isValid ? "Valid email" : "Invalid email");
    }

    static void MergeJsonFiles(string file1, string file2)
    {
        string json1 = File.ReadAllText(file1);
        string json2 = File.ReadAllText(file2);
        JObject obj1 = JObject.Parse(json1);
        JObject obj2 = JObject.Parse(json2);
        obj1.Merge(obj2);
        Console.WriteLine(JsonConvert.SerializeObject(obj1, Formatting.Indented));
    }

    static void ConvertJsonToXml(string filePath)
    {
        string json = File.ReadAllText(filePath);
        JObject obj = JObject.Parse(json);
        XDocument xml = JsonConvert.DeserializeXNode(obj.ToString(), "Root");
        Console.WriteLine(xml);
    }

    static void ConvertCsvToJson(string filePath)
    {
        using var reader = new StreamReader(filePath);
        using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
        var records = csv.GetRecords<dynamic>().ToList();
        string json = JsonConvert.SerializeObject(records, Formatting.Indented);
        Console.WriteLine(json);
    }

    static void GenerateJsonReportFromDatabase()
    {
        var table = new DataTable();
        table.Columns.Add("Id", typeof(int));
        table.Columns.Add("Name", typeof(string));
        table.Rows.Add(1, "Alice");
        table.Rows.Add(2, "Bob");
        var json = JsonConvert.SerializeObject(table, Formatting.Indented);
        Console.WriteLine(json);
    }
}

class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
}
