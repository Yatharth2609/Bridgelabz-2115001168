using System;

public class VowelConsonant
{
    // Function to count vowels
    private static int VowelCount(string str)
    {
        int vowel_cnt = 0;
        foreach (char c in str.ToLower())
        {
            if (c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u')
            {
                vowel_cnt++;
            }
        }
        return vowel_cnt;
    }

    // Function to count consonants
    private static int ConsonantCount(string str)
    {
        int conso_cnt = 0;
        foreach (char c in str.ToLower())
        {
            if (char.IsLetter(c) && (c != 'a' && c != 'e' && c != 'i' && c != 'o' && c != 'u'))
            {
                conso_cnt++;
            }
        }
        return conso_cnt;
    }

    private static void Main(string[] args)
    {
        Console.Write("Enter a string: ");
        string str = Console.ReadLine();

        int vowel_cnt = VowelCount(str);
        int conso_cnt = ConsonantCount(str);

        Console.WriteLine($"Number of vowels: {vowel_cnt}");
        Console.WriteLine($"Number of consonants: {conso_cnt}");
    }
}
