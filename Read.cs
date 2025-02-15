using System;
using System.IO;

class Read
{
    static void Main()
    {
        string filePath = "example.txt";
        using (StreamReader reader = new StreamReader(filePath))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                Console.WriteLine(line);
            }
        }
    }
}