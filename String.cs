using System;
using System.Diagnostics;
using System.Text;

class String
{
    static void Main()
    {
        int N = 1000000;
        Stopwatch sw = new Stopwatch();

        sw.Start();
        string result = "";
        for (int i = 0; i < N; i++)
        {
            result += "a";
        }
        sw.Stop();
        Console.WriteLine($"String concatenation time: {sw.ElapsedMilliseconds} ms");

        sw.Restart();
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < N; i++)
        {
            sb.Append("a");
        }
        string sbResult = sb.ToString();
        sw.Stop();
        Console.WriteLine($"StringBuilder time: {sw.ElapsedMilliseconds} ms");
    }
}