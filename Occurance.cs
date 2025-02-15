using System;
using System.IO;

class Occurance
{
    static void Main()
    {
        string filePath = "example.txt";
        string targetWord = "hello";
        int count = 0;

        using (StreamReader reader = new StreamReader(filePath))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] words = line.Split(' ');
                foreach (string word in words)
                {
                    if (word.Equals(targetWord, StringComparison.OrdinalIgnoreCase))
                    {
                        count++;
                    }
                }
            }
        }

        Console.WriteLine($"The word '{targetWord}' appears {count} times.");
    }
}