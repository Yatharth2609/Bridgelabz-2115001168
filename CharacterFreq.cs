using System;

public class CharacterFreq
{
    // Function to find the most frequent character in a string
    private static char Compute(string str)
    {
        int[] freq = new int[256]; 

        for (int i = 0; i < str.Length; i++)
        {
            freq[(int)str[i]]++;
        }

        int maxFreq = 0;
        char mostFreqChar = '\0';
        for (int i = 0; i < freq.Length; i++)
        {
            if (freq[i] > maxFreq)
            {
                maxFreq = freq[i];
                mostFreqChar = (char)i;
            }
        }

        return mostFreqChar;
    }

    public static void Main(string[] args)
    {
        Console.Write("Enter a string: ");
        string str = Console.ReadLine();

        char mostFreqChar = Compute(str);

        Console.WriteLine($"Most Frequent Character: '{mostFreqChar}'");
    }
}
