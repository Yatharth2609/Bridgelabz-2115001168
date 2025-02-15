using System;
using System.Text;

class Concatenate
{
    static void Main()
    {
        string[] strings = { "Hello", " ", "World", "!" };
        StringBuilder result = new StringBuilder();

        foreach (string str in strings)
        {
            result.Append(str);
        }

        Console.WriteLine(result.ToString());
    }
}