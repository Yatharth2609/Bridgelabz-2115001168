using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        PriorityQueue<string, int> triage = new PriorityQueue<string, int>(Comparer<int>.Create((x, y) => y.CompareTo(x)));
        triage.Enqueue("Rakesh", 3);
        triage.Enqueue("Priya", 5);
        triage.Enqueue("Suresh", 2);

        while (triage.Count > 0)
        {
            triage.TryDequeue(out string patient, out int severity);
            Console.WriteLine(patient);
        }
    }
}