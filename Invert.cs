using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        Dictionary<string, int> map = new Dictionary<string, int>
        {
            { "A", 1 },
            { "B", 2 },
            { "C", 1 }
        };

        Dictionary<int, List<string>> invertedMap = new Dictionary<int, List<string>>();
        foreach (var pair in map)
        {
            if (!invertedMap.ContainsKey(pair.Value))
                invertedMap[pair.Value] = new List<string>();
            invertedMap[pair.Value].Add(pair.Key);
        }

        Console.Write("{ ");
        foreach (var pair in invertedMap)
        {
            Console.Write($"{pair.Key}=[{string.Join(", ", pair.Value)}], ");
        }
        Console.WriteLine("}");
    }
}