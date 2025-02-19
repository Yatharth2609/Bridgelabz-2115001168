using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int N = 5;
        Queue<string> queue = new Queue<string>();
        queue.Enqueue("1");

        List<string> result = new List<string>();
        for (int i = 0; i < N; i++)
        {
            string current = queue.Dequeue();
            result.Add(current);
            queue.Enqueue(current + "0");
            queue.Enqueue(current + "1");
        }

        Console.WriteLine($"{{\"{string.Join("\", \"", result)}\"}}");
    }
}