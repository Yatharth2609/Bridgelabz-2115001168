using System;

public class Palindrome2
{
    // Function to check if the string is a palindrome
    private static bool IsPalin(string str)
    {
        str = str.Replace(" ", "").ToLower();

        int s = 0;
        int e = str.Length - 1;
        while (s < e)
        {
            if (str[s] != str[e])
            {
                return false; 
            }
            s++;
            e--;
        }

        return true; 
    }

    public static void Main(string[] args)
    {
        Console.Write("Enter a string: ");
        string str = Console.ReadLine();

        bool isPalin = IsPalin(str);

        if (isPalin)
        {
            Console.WriteLine("The string is a palindrome.");
        }
        else
        {
            Console.WriteLine("The string is not a palindrome.");
        }
    }
}
