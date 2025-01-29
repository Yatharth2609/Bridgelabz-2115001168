using System;

public class CompareString
{
    // Function to compare two strings lexicographically
    static int Compute(string str1, string str2)
    {
        int minLen = str1.Length < str2.Length ? str1.Length : str2.Length;

        for (int i = 0; i < minLen; i++)
        {
            if (str1[i] < str2[i])
            {
                return -1; 
            }
            else if (str1[i] > str2[i])
            {
                return 1; 
            }
        }

        if (str1.Length < str2.Length)
        {
            return -1; 
        }
        else if (str1.Length > str2.Length)
        {
            return 1; 
        }

        return 0; 
    }

    pubilc static void Main(string[] args)
    {
        Console.Write("Enter the first string: ");
        string str1 = Console.ReadLine();

        Console.Write("Enter the second string: ");
        string str2 = Console.ReadLine();

        int res = Compute(str1, str2);

        if (res == -1)
        {
            Console.WriteLine($"\"{str1}\" comes before \"{str2}\" in lexicographical order.");
        }
        else if (res == 1)
        {
            Console.WriteLine($"\"{str1}\" comes after \"{str2}\" in lexicographical order.");
        }
        else
        {
            Console.WriteLine($"\"{str1}\" is equal to \"{str2}\".");
        }
    }
}
