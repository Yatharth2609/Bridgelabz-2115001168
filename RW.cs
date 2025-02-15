using System;
using System.IO;

class RW
{
    static void Main()
    {
        Console.WriteLine("Enter text to write to file:");
        string userInput = Console.ReadLine();
        string filePath = "output.txt";

        using (StreamWriter writer = new StreamWriter(filePath))
        {
            writer.Write(userInput);
        }

        Console.WriteLine("Text written to file.");
    }
}