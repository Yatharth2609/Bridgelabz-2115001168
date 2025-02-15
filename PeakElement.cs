public class PeakElement
{
    public int FindPeakElement(int[] nums)
    {
        int left = 0;
        int right = nums.Length - 1;

        while (left < right)
        {
            int mid = left + (right - left) / 2;

            if (mid > 0 && mid < nums.Length - 1)
            {
                if (nums[mid] > nums[mid - 1] && nums[mid] > nums[mid + 1])
                {
                    return mid;
                }
                else if (nums[mid - 1] > nums[mid])
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }
            else if (mid == 0)
            {
                if (nums[0] > nums[1])
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            else if (mid == nums.Length - 1)
            {
                if (nums[nums.Length - 1] > nums[nums.Length - 2])
                {
                    return nums.Length - 1;
                }
                else
                {
                    return nums.Length - 2;
                }
            }
        }

        return left;
    }

    public static void Main()
    {
        int[] arr = { 1, 2, 3, 1 };
        PeakElement solution = new PeakElement();
        int peakIndex = solution.FindPeakElement(arr);
        Console.WriteLine($"Peak element found at index: {peakIndex}");
    }
}