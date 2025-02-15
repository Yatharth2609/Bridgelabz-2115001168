using System;
using System.Diagnostics;
using System.Text;

class Program
{
    static void Main()
    {
        int iterations = 100000;
        Stopwatch sw = new Stopwatch();

        sw.Start();
        string result = "";
        for (int i = 0; i < iterations; i++)
        {
            result += "a";
        }
        sw.Stop();
        Console.WriteLine("String concatenation time: " + sw.ElapsedMilliseconds + " ms");

        sw.Restart();
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < iterations; i++)
        {
            sb.Append("a");
        }
        sw.Stop();
        Console.WriteLine("StringBuilder concatenation time: " + sw.ElapsedMilliseconds + " ms");
    }
}