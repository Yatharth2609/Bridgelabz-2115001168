using System;

class SearchAndSortComparison
{
    static void BubbleSort(int[] arr)
    {
        int n = arr.Length;
        for (int i = 0; i < n - 1; i++)
            for (int j = 0; j < n - i - 1; j++)
                if (arr[j] > arr[j + 1])
                    (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);
    }

    static void MergeSort(int[] arr, int left, int right)
    {
        if (left < right)
        {
            int mid = left + (right - left) / 2;
            MergeSort(arr, left, mid);
            MergeSort(arr, mid + 1, right);
            Merge(arr, left, mid, right);
        }
    }

    static void Merge(int[] arr, int left, int mid, int right)
    {
        int n1 = mid - left + 1, n2 = right - mid;
        int[] L = new int[n1], R = new int[n2];
        Array.Copy(arr, left, L, 0, n1);
        Array.Copy(arr, mid + 1, R, 0, n2);
        int i = 0, j = 0, k = left;
        while (i < n1 && j < n2)
            arr[k++] = L[i] <= R[j] ? L[i++] : R[j++];
        while (i < n1)
            arr[k++] = L[i++];
        while (j < n2)
            arr[k++] = R[j++];
    }

    static void QuickSort(int[] arr, int low, int high)
    {
        if (low < high)
        {
            int pi = Partition(arr, low, high);
            QuickSort(arr, low, pi - 1);
            QuickSort(arr, pi + 1, high);
        }
    }

    static int Partition(int[] arr, int low, int high)
    {
        int pivot = arr[high], i = low - 1;
        for (int j = low; j < high; j++)
            if (arr[j] < pivot)
                (arr[++i], arr[j]) = (arr[j], arr[i]);
        (arr[i + 1], arr[high]) = (arr[high], arr[i + 1]);
        return i + 1;
    }

    static void Main()
    {
        Random rand = new Random();
        int[] dataset = new int[1000000];
        for (int i = 0; i < dataset.Length; i++)
            dataset[i] = rand.Next(1, 10000000);

        int target = dataset[rand.Next(0, dataset.Length)];

        var watch = System.Diagnostics.Stopwatch.StartNew();

        int[] bubbleDataset = (int[])dataset.Clone();
        watch = System.Diagnostics.Stopwatch.StartNew();
        BubbleSort(bubbleDataset);
        watch.Stop();
        Console.WriteLine($"Bubble Sort Time: {watch.ElapsedMilliseconds} ms");

        int[] mergeDataset = (int[])dataset.Clone();
        watch = System.Diagnostics.Stopwatch.StartNew();
        MergeSort(mergeDataset, 0, mergeDataset.Length - 1);
        watch.Stop();
        Console.WriteLine($"Merge Sort Time: {watch.ElapsedMilliseconds} ms");

        int[] quickDataset = (int[])dataset.Clone();
        watch = System.Diagnostics.Stopwatch.StartNew();
        QuickSort(quickDataset, 0, quickDataset.Length - 1);
        watch.Stop();
        Console.WriteLine($"Quick Sort Time: {watch.ElapsedMilliseconds} ms");
    }
}
