using System;
using System.Collections.Generic;

namespace SetOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<int> set1 = new HashSet<int> { 1, 2, 3 };
            HashSet<int> set2 = new HashSet<int> { 3, 4, 5 };
            
            HashSet<int> unionSet = UnionSets(set1, set2);
            HashSet<int> intersectionSet = IntersectSets(set1, set2);
            
            Console.WriteLine($"Set1: {{{string.Join(", ", set1)}}}");
            Console.WriteLine($"Set2: {{{string.Join(", ", set2)}}}");
            Console.WriteLine($"Union: {{{string.Join(", ", unionSet)}}}");
            Console.WriteLine($"Intersection: {{{string.Join(", ", intersectionSet)}}}");
        }
        
        static HashSet<T> UnionSets<T>(HashSet<T> set1, HashSet<T> set2)
        {
            HashSet<T> result = new HashSet<T>(set1);
            result.UnionWith(set2);
            return result;
        }
        
        static HashSet<T> IntersectSets<T>(HashSet<T> set1, HashSet<T> set2)
        {
            HashSet<T> result = new HashSet<T>(set1);
            result.IntersectWith(set2);
            return result;
        }
    }
}