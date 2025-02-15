using System;

class Rotation
{
    static void Main()
    {
        int[] arr = { 5, 6, 7, 1, 2, 3, 4 };
        int left = 0;
        int right = arr.Length - 1;

        while (left < right)
        {
            int mid = left + (right - left) / 2;
            if (arr[mid] > arr[right])
            {
                left = mid + 1;
            }
            else
            {
                right = mid;
            }
        }

        Console.WriteLine("Rotation point index: " + left);
    }
}