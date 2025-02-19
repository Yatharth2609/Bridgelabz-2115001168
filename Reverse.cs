using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Queue<int> queue = new Queue<int>();
        queue.Enqueue(10);
        queue.Enqueue(20);
        queue.Enqueue(30);

        Stack<int> stack = new Stack<int>();
        while (queue.Count > 0)
        {
            stack.Push(queue.Dequeue());
        }

        while (stack.Count > 0)
        {
            queue.Enqueue(stack.Pop());
        }

        Console.Write("[");
        while (queue.Count > 0)
        {
            Console.Write(queue.Dequeue());
            if (queue.Count > 0) Console.Write(", ");
        }
        Console.WriteLine("]");
    }
}