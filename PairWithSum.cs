using System;
using System.Collections.Generic;

public class PairWithSum
{
    public static bool HasPairWithSum(int[] nums, int target)
    {
        HashSet<int> set = new HashSet<int>();
        foreach (int num in nums)
        {
            if (set.Contains(target - num))
            {
                return true;
            }
            set.Add(num);
        }
        return false;
    }
}

class Program
{
    static void Main()
    {
        int[] nums = { 1, 4, 45, 6, 10, 8 };
        int target = 16;
        bool result = PairWithSum.HasPairWithSum(nums, target);
        Console.WriteLine(result);
    }
}