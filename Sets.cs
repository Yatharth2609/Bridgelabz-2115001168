using System;
using System.Collections.Generic;
using System.Linq;

namespace EqualSets
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<int> set1 = new HashSet<int> { 1, 2, 3 };
            HashSet<int> set2 = new HashSet<int> { 3, 2, 1 };
            
            bool areEqual = AreSetsEqual(set1, set2);
            
            Console.WriteLine($"Set1: {{{string.Join(", ", set1)}}}");
            Console.WriteLine($"Set2: {{{string.Join(", ", set2)}}}");
            Console.WriteLine($"Sets are equal: {areEqual}");
            
            HashSet<int> set3 = new HashSet<int> { 1, 2, 3 };
            HashSet<int> set4 = new HashSet<int> { 1, 2, 4 };
            
            bool areEqual2 = AreSetsEqual(set3, set4);
            
            Console.WriteLine($"\nSet3: {{{string.Join(", ", set3)}}}");
            Console.WriteLine($"Set4: {{{string.Join(", ", set4)}}}");
            Console.WriteLine($"Sets are equal: {areEqual2}");
        }
        
        static bool AreSetsEqual<T>(HashSet<T> set1, HashSet<T> set2)
        {
            if (set1.Count != set2.Count)
                return false;
                
            return set1.SetEquals(set2);
        }
    }
}