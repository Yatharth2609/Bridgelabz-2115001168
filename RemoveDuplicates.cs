using System;

public class RemoveDuplicates
{
    // Function to remove duplicate characters from a string
    private static string Remove_Dupli(string str)
    {
        char[] res = new char[str.Length];
        int idx = 0;

        for (int i = 0; i < str.Length; i++)
        {
            bool isDupli = false;
            for (int j = 0; j < idx; j++)
            {
                if (str[i] == res[j])
                {
                    isDupli = true;
                    break;
                }
            }
            if (!isDupli)
            {
                res[idx] = str[i];
                idx++;
            }
        }
        return new string(res, 0, idx);
    }

    public static void Main(string[] args)
    {
        Console.Write("Enter a string: ");
        string str = Console.ReadLine();

        string newStr = Remove_Dupli(str);
        Console.WriteLine($"String after removing duplicates: {newStr}");
    }
}
