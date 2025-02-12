using System;
using System.Collections.Generic;

public class SortStack
{
    public static void Sort(Stack<int> stack)
    {
        if (stack.Count > 0)
        {
            int temp = stack.Pop();
            Sort(stack);
            Insert(stack, temp);
        }
    }

    private static void Insert(Stack<int> stack, int item)
    {
        if (stack.Count == 0 || item > stack.Peek())
        {
            stack.Push(item);
        }
        else
        {
            int temp = stack.Pop();
            Insert(stack, item);
            stack.Push(temp);
        }
    }
}

class Program
{
    static void Main()
    {
        Stack<int> stack = new Stack<int>();
        stack.Push(34);
        stack.Push(3);
        stack.Push(31);
        stack.Push(98);
        stack.Push(92);
        stack.Push(23);
        SortStack.Sort(stack);
        while (stack.Count > 0)
        {
            Console.WriteLine(stack.Pop());
        }
    }
}