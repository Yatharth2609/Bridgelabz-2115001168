using System;

public class CheckAnagrams
{
    // Function to check if two strings are anagrams
    private static bool IsAnagram(string str1, string str2)
    {
        if (str1.Length != str2.Length)
        {
            return false;
        }
        int[] freq1 = new int[256]; 
        int[] freq2 = new int[256]; 

        for (int i = 0; i < str1.Length; i++)
        {
            freq1[(int)str1[i]]++;
            freq2[(int)str2[i]]++;
        }

        for (int i = 0; i < 256; i++)
        {
            if (freq1[i] != freq2[i])
            {
                return false;
            }
        }

        return true;
    }

    public static void Main(string[] args)
    {
        Console.Write("Enter the first string: ");
        string str1 = Console.ReadLine();

        Console.Write("Enter the second string: ");
        string str2 = Console.ReadLine();

        if (IsAnagram(str1, str2))
        {
            Console.WriteLine("The strings are anagrams of each other.");
        }
        else
        {
            Console.WriteLine("The strings are not anagrams of each other.");
        }
    }
}

