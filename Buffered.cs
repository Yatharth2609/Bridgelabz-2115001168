using System;
using System.Diagnostics;
using System.IO;

class Program
{
    static void Main()
    {
        string sourceFile = "largefile.dat";
        string destinationFileBuffered = "destination_buffered.dat";
        string destinationFileUnbuffered = "destination_unbuffered.dat";

        if (!File.Exists(sourceFile))
        {
            Console.WriteLine("Source file does not exist.");
            return;
        }

        Stopwatch stopwatch = new Stopwatch();

        stopwatch.Start();
        using (FileStream sourceStream = new FileStream(sourceFile, FileMode.Open, FileAccess.Read))
        using (FileStream destinationStream = new FileStream(destinationFileUnbuffered, FileMode.Create, FileAccess.Write))
        {
            sourceStream.CopyTo(destinationStream);
        }
        stopwatch.Stop();
        Console.WriteLine($"Unbuffered Copy Time: {stopwatch.ElapsedMilliseconds} ms");

        stopwatch.Restart();
        using (FileStream sourceStream = new FileStream(sourceFile, FileMode.Open, FileAccess.Read))
        using (FileStream destinationStream = new FileStream(destinationFileBuffered, FileMode.Create, FileAccess.Write))
        using (BufferedStream bufferedStream = new BufferedStream(destinationStream, 4096))
        {
            byte[] buffer = new byte[4096];
            int bytesRead;
            while ((bytesRead = sourceStream.Read(buffer, 0, buffer.Length)) > 0)
            {
                bufferedStream.Write(buffer, 0, bytesRead);
            }
        }
        stopwatch.Stop();
        Console.WriteLine($"Buffered Copy Time: {stopwatch.ElapsedMilliseconds} ms");
    }
}