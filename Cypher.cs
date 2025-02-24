using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;

class Program
{
    static void Main()
    {
        string csvFilePath = "employees_encrypted.csv";
        string decryptedFilePath = "employees_decrypted.csv";

        var employees = new List<Dictionary<string, string>>
        {
            new Dictionary<string, string> { {"ID", "1"}, {"Name", "Priya"}, {"Department", "IT"}, {"Salary", "50000"}, {"Email", "priya@gmail.com"} },
            new Dictionary<string, string> { {"ID", "2"}, {"Name", "Ravi"}, {"Department", "HR"}, {"Salary", "60000"}, {"Email", "ravi@gmail.com"} }
        };
        
        EncryptAndWriteCsv(csvFilePath, employees);
        DecryptAndReadCsv(csvFilePath, decryptedFilePath);
    }

    static void EncryptAndWriteCsv(string csvFilePath, List<Dictionary<string, string>> data)
    {
        if (data.Count == 0) return;
        var headers = string.Join(",", data.First().Keys);
        var csvLines = new List<string> { headers };
        
        csvLines.AddRange(data.Select(row => string.Join(",", row.Select(kv => kv.Key == "Salary" || kv.Key == "Email" ? Encrypt(kv.Value) : kv.Value))));
        
        File.WriteAllLines(csvFilePath, csvLines);
        Console.WriteLine("Encrypted data written to CSV.");
    }

    static void DecryptAndReadCsv(string encryptedFilePath, string decryptedFilePath)
    {
        if (!File.Exists(encryptedFilePath))
        {
            Console.WriteLine("File not found.");
            return;
        }
        
        var lines = File.ReadAllLines(encryptedFilePath);
        var headers = lines[0].Split(',');
        var decryptedLines = new List<string> { lines[0] };
        
        foreach (var line in lines.Skip(1))
        {
            var values = line.Split(',');
            var decryptedValues = values.Select((v, i) => headers[i] == "Salary" || headers[i] == "Email" ? Decrypt(v) : v).ToArray();
            decryptedLines.Add(string.Join(",", decryptedValues));
        }
        
        File.WriteAllLines(decryptedFilePath, decryptedLines);
        Console.WriteLine("Decrypted data written to CSV.");
    }

    static string Encrypt(string text)
    {
        using (Aes aes = Aes.Create())
        {
            aes.Key = Encoding.UTF8.GetBytes("abcdefghijklmnopabcdefghijklmnop");
            aes.IV = Encoding.UTF8.GetBytes("1234567890123456");
            using (var encryptor = aes.CreateEncryptor())
            {
                byte[] input = Encoding.UTF8.GetBytes(text);
                byte[] output = encryptor.TransformFinalBlock(input, 0, input.Length);
                return Convert.ToBase64String(output);
            }
        }
    }

    static string Decrypt(string encryptedText)
    {
        using (Aes aes = Aes.Create())
        {
            aes.Key = Encoding.UTF8.GetBytes("abcdefghijklmnopabcdefghijklmnop");
            aes.IV = Encoding.UTF8.GetBytes("1234567890123456");
            using (var decryptor = aes.CreateDecryptor())
            {
                byte[] input = Convert.FromBase64String(encryptedText);
                byte[] output = decryptor.TransformFinalBlock(input, 0, input.Length);
                return Encoding.UTF8.GetString(output);
            }
        }
    }
}
