using System;
using System.Collections.Generic;

namespace RemoveDuplicates
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int> { 3, 1, 2, 2, 3, 4 };
            
            Console.WriteLine("Original list:");
            PrintList(numbers);
            
            List<int> uniqueList = RemoveDuplicatesPreservingOrder(numbers);
            
            Console.WriteLine("List with duplicates removed (order preserved):");
            PrintList(uniqueList);
        }
        
        static List<T> RemoveDuplicatesPreservingOrder<T>(List<T> list)
        {
            HashSet<T> seen = new HashSet<T>();
            List<T> result = new List<T>();
            
            foreach (T item in list)
            {
                if (!seen.Contains(item))
                {
                    seen.Add(item);
                    result.Add(item);
                }
            }
            
            return result;
        }
        
        static void PrintList<T>(List<T> list)
        {
            Console.Write("[");
            for (int i = 0; i < list.Count; i++)
            {
                Console.Write(list[i]);
                if (i < list.Count - 1)
                    Console.Write(", ");
            }
            Console.WriteLine("]");
        }
    }
}