using System;

public class LongestWord
{
    // Function to find the longest word in a sentence
    static string Compute(string str)
    {
        string[] words = str.Split(' ');

        string res = "";
        int maxLen = 0;

        foreach (string word in words)
        {
            if (word.Length > maxLen)
            {
                maxLen = word.Length;
                res = word;
            }
        }

        return res;
    }

    public static void Main(string[] args)
    {
        Console.Write("Enter a sentence: ");
        string str = Console.ReadLine();

        string res = Compute(str);

        Console.WriteLine($"The longest word in the sentence is: {res}");
    }
}
