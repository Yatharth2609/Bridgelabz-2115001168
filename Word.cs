using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        string text = File.ReadAllText("input.txt").ToLower();
        string[] words = text.Split(new[] { ' ', '.', ',', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);

        Dictionary<string, int> frequency = new Dictionary<string, int>();
        foreach (string word in words)
        {
            if (frequency.ContainsKey(word))
                frequency[word]++;
            else
                frequency[word] = 1;
        }

        Console.Write("{ ");
        foreach (var pair in frequency)
        {
            Console.Write($"\"{pair.Key}\": {pair.Value}, ");
        }
        Console.WriteLine("}");
    }
}