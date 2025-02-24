using System;
using System.IO;

class Program
{
    static void Main()
    {
        string filePath = "largefile.csv";
        int chunkSize = 100;
        int totalRecords = 0;
        
        if (File.Exists(filePath))
        {
            using (var reader = new StreamReader(filePath))
            {
                reader.ReadLine();
                while (!reader.EndOfStream)
                {
                    int count = 0;
                    while (count < chunkSize && !reader.EndOfStream)
                    {
                        reader.ReadLine();
                        count++;
                        totalRecords++;
                    }
                    Console.WriteLine($"Processed {totalRecords} records so far.");
                }
            }
            Console.WriteLine("Finished processing all records.");
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }
}
