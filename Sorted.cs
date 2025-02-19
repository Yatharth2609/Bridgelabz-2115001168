using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        HashSet<int> set = new HashSet<int> { 5, 3, 9, 1 };
        List<int> sortedList = set.OrderBy(x => x).ToList();
        Console.WriteLine($"[{string.Join(", ", sortedList)}]");
    }
}