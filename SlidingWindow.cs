using System;
using System.Collections.Generic;

public class SlidingWindow
{
    public static int[] MaxSlidingWindow(int[] nums, int k)
    {
        if (nums == null || nums.Length == 0 || k <= 0) return new int[0];

        int n = nums.Length;
        int[] result = new int[n - k + 1];
        int ri = 0;
        LinkedList<int> deque = new LinkedList<int>();

        for (int i = 0; i < nums.Length; i++)
        {
            while (deque.Count > 0 && deque.First.Value < i - k + 1)
            {
                deque.RemoveFirst();
            }

            while (deque.Count > 0 && nums[deque.Last.Value] < nums[i])
            {
                deque.RemoveLast();
            }

            deque.AddLast(i);

            if (i >= k - 1)
            {
                result[ri++] = nums[deque.First.Value];
            }
        }

        return result;
    }
}

class Program
{
    static void Main()
    {
        int[] nums = { 1, 3, -1, -3, 5, 3, 6, 7 };
        int k = 3;
        int[] result = SlidingWindow.MaxSlidingWindow(nums, k);
        Console.WriteLine(string.Join(", ", result));
    }
}