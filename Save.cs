using System;
using System.IO;

class Program
{
    static void Main()
    {
        string filePath = "user_data.txt";

        try
        {
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();
            
            Console.Write("Enter your age: ");
            string age = Console.ReadLine();
            
            Console.Write("Enter your favorite programming language: ");
            string language = Console.ReadLine();

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine($"Name: {name}");
                writer.WriteLine($"Age: {age}");
                writer.WriteLine($"Favorite Programming Language: {language}");
            }

            Console.WriteLine("User data has been saved successfully.");
        }
        catch (IOException ex)
        {
            Console.WriteLine("An error occurred while writing to the file: " + ex.Message);
        }
    }
}
