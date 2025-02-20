using System;
using System.IO;

class Program
{
    static void Main()
    {
        string sourceImagePath = "source.jpg";
        string destinationImagePath = "destination.jpg";

        try
        {
            byte[] imageBytes = File.ReadAllBytes(sourceImagePath);
            File.WriteAllBytes(destinationImagePath, imageBytes);
            Console.WriteLine("Image successfully converted to byte array and written back to a new file.");
        }
        catch (IOException ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
