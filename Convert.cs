using System;
using System.IO;
using System.Text;

class Program
{
    static void Main()
    {
        string sourceFile = "source.txt";
        string destinationFile = "destination.txt";

        try
        {
            using (FileStream sourceStream = new FileStream(sourceFile, FileMode.Open, FileAccess.Read))
            using (BufferedStream bufferedStream = new BufferedStream(sourceStream))
            using (StreamReader reader = new StreamReader(bufferedStream, Encoding.UTF8))
            using (FileStream destinationStream = new FileStream(destinationFile, FileMode.Create, FileAccess.Write))
            using (StreamWriter writer = new StreamWriter(destinationStream, Encoding.UTF8))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    writer.WriteLine(line.ToLower());
                }
            }
            
            Console.WriteLine("File conversion completed successfully.");
        }
        catch (IOException ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
