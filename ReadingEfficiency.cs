using System;
using System.Diagnostics;
using System.IO;

class ReadingEfficiency
{
    static void Main()
    {
        string path = "largefile.txt";
        int bufferSize = 4096;

        Stopwatch sw = new Stopwatch();

        sw.Start();
        using (StreamReader sr = new StreamReader(path))
        {
            while (sr.ReadLine() != null) { }
        }
        sw.Stop();
        Console.WriteLine($"StreamReader time: {sw.ElapsedMilliseconds} ms");

        sw.Restart();
        using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
        using (StreamReader sr = new StreamReader(fs, Encoding.UTF8, true, bufferSize))
        {
            while (sr.ReadLine() != null) { }
        }
        sw.Stop();
        Console.WriteLine($"FileStream with StreamReader time: {sw.ElapsedMilliseconds} ms");
    }
}