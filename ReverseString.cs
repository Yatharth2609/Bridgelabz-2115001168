using System;

public class ReverseString
{
    // Function to reverse the string
    private static string rev_string(string str)
    {
        char[] charArr = str.ToCharArray(); 
        int s = 0;
        int e = charArr.Length - 1;

        while (s < e)
        {
        
            char temp = charArr[s];
            charArr[s] = charArr[e];
            charArr[e] = temp;

            s++;
            e--;
        }
        return new string(charArr);
    }

    public static void Main(string[] args)
    {
        Console.Write("Enter a string: ");
        string input = Console.ReadLine();

        string revString = rev_string(input);

        Console.WriteLine($"Reversed string: {revString}");
    }
}

