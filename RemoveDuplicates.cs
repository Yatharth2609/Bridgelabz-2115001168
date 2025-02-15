using System;
using System.Text;

class RemoveDuplicates {
    static void Main()
    {
        string input = "hello world";
        StringBuilder result = new StringBuilder();
        bool[] seen = new bool[256];

        foreach (char c in input)
        {
            if (!seen[c])
            {
                result.Append(c);
                seen[c] = true;
            }
        }

        Console.WriteLine(result.ToString());
    }
}
