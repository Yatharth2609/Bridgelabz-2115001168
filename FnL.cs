using System;

class Program
{
    static void Main(string[] args)
    {
        int[] nums = { 1, 2, 2, 2, 2, 3, 4, 7, 8, 8 };
        int target = 2;
        
        FnL solution = new FnL();
        int[] result = solution.SearchRange(nums, target);
        
        Console.WriteLine($"First and last occurrence of {target}: [{result[0]}, {result[1]}]");
    }
}

public class FnL 
{
    public int[] SearchRange(int[] nums, int target) 
    {
        int[] result = new int[] { -1, -1 };
        
        result[0] = FindFirstOccurrence(nums, target);
        result[1] = FindLastOccurrence(nums, target);
        
        return result;
    }
    
    private int FindFirstOccurrence(int[] nums, int target)
    {
        int left = 0;
        int right = nums.Length - 1;
        int firstOccurrence = -1;
        
        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            
            if (nums[mid] == target)
            {
                firstOccurrence = mid;
                right = mid - 1;
            }
            else if (nums[mid] < target)
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }
        
        return firstOccurrence;
    }
    
    private int FindLastOccurrence(int[] nums, int target)
    {
        int left = 0;
        int right = nums.Length - 1;
        int lastOccurrence = -1;
        
        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            
            if (nums[mid] == target)
            {
                lastOccurrence = mid;
                left = mid + 1;
            }
            else if (nums[mid] < target)
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }
        
        return lastOccurrence;
    }
}