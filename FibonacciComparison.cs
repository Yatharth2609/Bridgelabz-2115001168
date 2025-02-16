using System;
using System.Diagnostics;

class FibonacciComparison
{
    static void Main()
    {
        int n = 30;
        Stopwatch sw = new Stopwatch();

        sw.Start();
        int recursiveResult = FibonacciRecursive(n);
        sw.Stop();
        Console.WriteLine($"Recursive Fibonacci time: {sw.ElapsedMilliseconds} ms");

        sw.Restart();
        int iterativeResult = FibonacciIterative(n);
        sw.Stop();
        Console.WriteLine($"Iterative Fibonacci time: {sw.ElapsedMilliseconds} ms");
    }

    static int FibonacciRecursive(int n)
    {
        if (n <= 1) return n;
        return FibonacciRecursive(n - 1) + FibonacciRecursive(n - 2);
    }

    static int FibonacciIterative(int n)
    {
        int a = 0, b = 1, sum;
        for (int i = 2; i <= n; i++)
        {
            sum = a + b;
            a = b;
            b = sum;
        }
        return b;
    }
}