using System;

class Search
{
    static void Main()
    {
        string[] sentences = { "Hello world", "This is a test", "C# programming is fun", "Search for a word" };
        string targetWord = "C#";
        string result = null;

        foreach (string sentence in sentences)
        {
            if (sentence.Contains(targetWord))
            {
                result = sentence;
                break;
            }
        }

        Console.WriteLine("First sentence containing the word: " + result);
    }
}