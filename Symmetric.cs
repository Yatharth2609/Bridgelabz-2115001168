using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        HashSet<int> set1 = new HashSet<int> { 1, 2, 3 };
        HashSet<int> set2 = new HashSet<int> { 3, 4, 5 };
        HashSet<int> symmetricDifference = new HashSet<int>(set1);
        symmetricDifference.SymmetricExceptWith(set2);
        Console.WriteLine(string.Join(", ", symmetricDifference));
    }
}