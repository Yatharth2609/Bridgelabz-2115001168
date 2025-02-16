using System;

class SearchComparison
{
    static bool LinearSearch(int[] arr, int target)
    {
        foreach (int num in arr)
        {
            if (num == target)
                return true;
        }
        return false;
    }

    static bool BinarySearch(int[] arr, int target)
    {
        Array.Sort(arr);
        int left = 0, right = arr.Length - 1;
        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            if (arr[mid] == target)
                return true;
            if (arr[mid] < target)
                left = mid + 1;
            else
                right = mid - 1;
        }
        return false;
    }

    static void Main()
    {
        Random rand = new Random();
        int[] dataset = new int[1000000];
        for (int i = 0; i < dataset.Length; i++)
            dataset[i] = rand.Next(1, 10000000);

        int target = dataset[rand.Next(0, dataset.Length)];

        var watch = System.Diagnostics.Stopwatch.StartNew();
        LinearSearch(dataset, target);
        watch.Stop();
        Console.WriteLine($"Linear Search Time: {watch.ElapsedMilliseconds} ms");

        watch = System.Diagnostics.Stopwatch.StartNew();
        BinarySearch(dataset, target);
        watch.Stop();
        Console.WriteLine($"Binary Search Time: {watch.ElapsedMilliseconds} ms");
    }
}
