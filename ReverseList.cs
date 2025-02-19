using System;
using System.Collections;
using System.Collections.Generic;

namespace ReverseListProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            // ArrayList example
            ArrayList arrayList = new ArrayList { 1, 2, 3, 4, 5 };
            Console.WriteLine("Original ArrayList:");
            PrintArrayList(arrayList);
            
            ReverseArrayList(arrayList);
            Console.WriteLine("Reversed ArrayList:");
            PrintArrayList(arrayList);
            
            // LinkedList example
            LinkedList<int> linkedList = new LinkedList<int>(new[] { 1, 2, 3, 4, 5 });
            Console.WriteLine("\nOriginal LinkedList:");
            PrintLinkedList(linkedList);
            
            ReverseLinkedList(linkedList);
            Console.WriteLine("Reversed LinkedList:");
            PrintLinkedList(linkedList);
        }
        
        static void ReverseArrayList(ArrayList list)
        {
            int left = 0;
            int right = list.Count - 1;
            
            while (left < right)
            {
                object temp = list[left];
                list[left] = list[right];
                list[right] = temp;
                left++;
                right--;
            }
        }
        
        static void ReverseLinkedList<T>(LinkedList<T> list)
        {
            if (list.Count <= 1)
                return;

            LinkedList<T> reversed = new LinkedList<T>();

            LinkedListNode<T>? current = list.Last;

            while (current != null)
            {
                reversed.AddLast(current.Value);
                current = current.Previous;
            }
            
            list.Clear();

            foreach (T item in reversed)
            {
                list.AddLast(item);
            }
        }
        
        static void PrintArrayList(ArrayList list)
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
        
        static void PrintLinkedList<T>(LinkedList<T> list)
        {
            Console.Write("[");
            LinkedListNode<T>? current = list.First;
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