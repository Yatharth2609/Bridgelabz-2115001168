using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string filePath = "employees.csv";
        string emailPattern = @""^[^@\s]+@[^@\s]+\.[^@\s]+$"";
        string phonePattern = @""^\d{10}$"";
        
        if (File.Exists(filePath))
        {
            string[] lines = File.ReadAllLines(filePath);
            Console.WriteLine("Validating records:");
            
            foreach (var line in lines.Skip(1))
            {
                string[] values = line.Split(',');
                string email = values[4];
                string phone = values[5];
                
                bool isEmailValid = Regex.IsMatch(email, emailPattern);
                bool isPhoneValid = Regex.IsMatch(phone, phonePattern);
                
                if (!isEmailValid || !isPhoneValid)
                {
                    Console.WriteLine($"Invalid record: {line}");
                    if (!isEmailValid) Console.WriteLine(" -> Invalid email format");
                    if (!isPhoneValid) Console.WriteLine(" -> Phone number must be 10 digits");
                }
            }
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }
}
