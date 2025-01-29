using System;

public class RemoveAllOccurrences
{
    // Function to remove all occurrences of a specific character from a string
    private static string Compute(string str, char removeChar)
    {
        char[] res = new char[str.Length];
        int idx = 0;
		
        for (int i = 0; i < str.Length; i++)
        {
            if (str[i] != removeChar)
            {
                res[idx] = str[i];
                idx++;
            }
        }

        string newStr = "";
        for (int i = 0; i < idx; i++)
        {
            newStr += res[i];
        }

        return newStr;
    }

    public static void Main(string[] args)
    {
        Console.Write("Enter a string: ");
        string input = Console.ReadLine();

        Console.Write("Enter the character to remove: ");
        char removeChar= Console.ReadKey().KeyChar;
        Console.WriteLine();

        string newStr = Compute(input, removeChar);

        Console.WriteLine($"Modified String: \"{newStr}\"");
    }
}
