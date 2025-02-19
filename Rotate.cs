using System;
using System.Collections.Generic;

namespace RotateList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int> { 10, 20, 30, 40, 50 };
            int rotateBy = 2;
            
            List<int> rotatedList = RotateList(numbers, rotateBy);
            
            Console.WriteLine("Original list:");
            PrintList(numbers);
            
            Console.WriteLine($"List rotated by {rotateBy} positions:");
            PrintList(rotatedList);
        }
        
        static List<T> RotateList<T>(List<T> list, int rotateBy)
        {
            int n = list.Count;
            
            if (n == 0 || rotateBy % n == 0)
                return new List<T>(list);
                
            rotateBy = rotateBy % n;
            
            List<T> rotatedList = new List<T>(n);
            
            for (int i = rotateBy; i < n + rotateBy; i++)
            {
                rotatedList.Add(list[i % n]);
            }
            
            return rotatedList;
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