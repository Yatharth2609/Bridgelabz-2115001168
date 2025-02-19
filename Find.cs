using System;
using System.Collections.Generic;

namespace NthFromEnd
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<string> letters = new LinkedList<string>();
            letters.AddLast("A");
            letters.AddLast("B");
            letters.AddLast("C");
            letters.AddLast("D");
            letters.AddLast("E");
            
            int n = 2;
            
            Console.WriteLine("LinkedList:");
            PrintLinkedList(letters);
            
            string nthFromEnd = FindNthFromEnd(letters, n);
            
            if (nthFromEnd != null)
            {
                Console.WriteLine($"The {n}th element from the end is: {nthFromEnd}");
            }
            else
            {
                Console.WriteLine($"Could not find the {n}th element from the end - N is too large or the list is empty");
            }
        }
        
        static T FindNthFromEnd<T>(LinkedList<T> list, int n)
        {
            if (list.Count == 0 || n <= 0)
                return default;
                
            LinkedListNode<T> ahead = list.First;
            LinkedListNode<T> behind = list.First;
            
            int count = 0;
            
            while (count < n && ahead != null)
            {
                ahead = ahead.Next;
                count++;
            }
            
            if (count < n)
                return default;
                
            while (ahead != null)
            {
                ahead = ahead.Next;
                behind = behind.Next;
            }
            
            return behind.Value;
        }
        
        static void PrintLinkedList<T>(LinkedList<T> list)
        {
            Console.Write("[");
            LinkedListNode<T> current = list.First;
            while (current != null)
            {
                Console.Write(current.Value);
                current = current.Next;
                if (current != null)
                    Console.Write(", ");
            }
            Console.WriteLine("]");
        }
    }
}