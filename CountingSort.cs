using System;

class Sort
{
    static void Main()
    {
        int[] ages = { 12, 15, 14, 12, 16, 18, 15, 10 };
        int[] sortedAges = CountingSort(ages);
        foreach (int age in sortedAges)
        {
            Console.Write(age + " ");
        }
    }

    static int[] CountingSort(int[] arr)
    {
        int n = arr.Length;
        int max = 18;
        int min = 10;
        int range = max - min + 1;
        int[] count = new int[range];
        int[] output = new int[n];
        for (int i = 0; i < n; i++)
        {
            count[arr[i] - min]++;
        }
        for (int i = 1; i < range; i++)
        {
            count[i] += count[i - 1];
        }
        for (int i = n - 1; i >= 0; i--)
        {
            output[count[arr[i] - min] - 1] = arr[i];
            count[arr[i] - min]--;
        }
        return output;
    }
}