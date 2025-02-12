using System;
using System.Collections.Generic;

public class ZeroSumSubarrays
{
    public static List<List<int>> FindAllSubarrays(int[] nums)
    {
        List<List<int>> result = new List<List<int>>();
        Dictionary<int, List<int>> map = new Dictionary<int, List<int>>();
        int sum = 0;

        map[0] = new List<int> { -1 };

        for (int i = 0; i < nums.Length; i++)
        {
            sum += nums[i];
            if (map.ContainsKey(sum))
            {
                foreach (int start in map[sum])
                {
                    List<int> subarray = new List<int>();
                    for (int j = start + 1; j <= i; j++)
                    {
                        subarray.Add(nums[j]);
                    }
                    result.Add(subarray);
                }
                map[sum].Add(i);
            }
            else
            {
                map[sum] = new List<int> { i };
            }
        }

        return result;
    }
}

class Program
{
    static void Main()
    {
        int[] nums = { 6, 3, -1, -3, 4, -2, 2, 4, 6, -12, -7 };
        List<List<int>> subarrays = ZeroSumSubarrays.FindAllSubarrays(nums);
        foreach (var subarray in subarrays)
        {
            Console.WriteLine(string.Join(", ", subarray));
        }
    }
}