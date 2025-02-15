using System;

class Program
{
    static void Main(string[] args)
    {
        int[] numbers = { 3, 4, -1, 1, 7, 2, 6, 8 };
        int target = 6;
        
        BnL solution = new BnL();
        
        int missingPositive = solution.FindFirstMissingPositive(numbers);
        Console.WriteLine($"First missing positive integer: {missingPositive}");
        
        Array.Sort(numbers);
        int targetIndex = solution.BinarySearch(numbers, target);
        Console.WriteLine($"Index of target {target}: {targetIndex}");
    }
}

public class BnL 
{
    public int FindFirstMissingPositive(int[] nums) 
    {
        int n = nums.Length;
        
        for (int i = 0; i < n; i++)
        {
            while (nums[i] > 0 && nums[i] <= n && nums[nums[i] - 1] != nums[i])
            {
                int temp = nums[nums[i] - 1];
                nums[nums[i] - 1] = nums[i];
                nums[i] = temp;
            }
        }
        
        for (int i = 0; i < n; i++)
        {
            if (nums[i] != i + 1)
            {
                return i + 1;
            }
        }
        
        return n + 1;
    }
    
    public int BinarySearch(int[] nums, int target)
    {
        int left = 0;
        int right = nums.Length - 1;
        
        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            
            if (nums[mid] == target)
            {
                return mid;
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
        
        return -1;
    }
}