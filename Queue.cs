using System;
using System.Collections.Generic;

public class QueueUsingStacks
{
    private Stack<int> stack1 = new Stack<int>();
    private Stack<int> stack2 = new Stack<int>();

    public void Enqueue(int item)
    {
        stack1.Push(item);
    }

    public int Dequeue()
    {
        if (stack2.Count == 0)
        {
            while (stack1.Count > 0)
            {
                stack2.Push(stack1.Pop());
            }
        }
        return stack2.Pop();
    }

    public int Peek()
    {
        if (stack2.Count == 0)
        {
            while (stack1.Count > 0)
            {
                stack2.Push(stack1.Pop());
            }
        }
        return stack2.Peek();
    }

    public bool IsEmpty()
    {
        return stack1.Count == 0 && stack2.Count == 0;
    }
}

class Program
{
    static void Main()
    {
        QueueUsingStacks queue = new QueueUsingStacks();
        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Enqueue(3);
        Console.WriteLine(queue.Dequeue());
        Console.WriteLine(queue.Peek());
        queue.Enqueue(4);
        Console.WriteLine(queue.Dequeue());
    }
}