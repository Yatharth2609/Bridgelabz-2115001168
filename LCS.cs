using System;
using System.Collections.Generic;

public class LCS
{
    public static int LongestConsecutive(int[] nums)
    {
        HashSet<int> set = new HashSet<int>(nums);
        int longestStreak = 0;

        foreach (int num in set)
        {
            if (!set.Contains(num - 1))
            {
                int currentNum = num;
                int currentStreak = 1;

                while (set.Contains(currentNum + 1))
                {
                    currentNum++;
                    currentStreak++;
                }

                longestStreak = Math.Max(longestStreak, currentStreak);
            }
        }

        return longestStreak;
    }
}

class Program
{
    static void Main()
    {
        int[] nums = { 100, 4, 200, 1, 3, 2 };
        int result = LCS.LongestConsecutive(nums);
        Console.WriteLine(result);
    }
}