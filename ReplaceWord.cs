
using System;

public class ReplaceWord
{
    // Function to replace a word in a sentence with another word
    private static string Replace(string text, string Word, string newWord)
    {
        char[] Arr = text.ToCharArray();
        string res = "";

        int i = 0;
        while (i < Arr.Length)
        {
            int j = 0;
            while (i + j < Arr.Length && j < Word.Length && Arr[i + j] == Word[j])
            {
                j++;
            }
            if (j == Word.Length)
            {
                res += newWord;
                i += Word.Length; 
            }
            else
            {
                res += Arr[i];
                i++; 
            }
        }

        return res;
    }

    public static void Main(string[] args)
    {
        Console.Write("Enter a sentence: ");
        string text = Console.ReadLine();

        Console.Write("Enter the word to replace: ");
        string Word = Console.ReadLine();

        Console.Write("Enter the new word: ");
        string newWord = Console.ReadLine();

        string newText = Replace(text, Word, newWord);

        Console.WriteLine($"Modified Sentence: {newText}");
    }
}


