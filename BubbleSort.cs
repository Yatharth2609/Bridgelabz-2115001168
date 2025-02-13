using System;

class Bubble
{
    static void Main()
    {
        int[] marks = { 78, 85, 92, 64, 88, 73 };
        BubbleSort(marks);
        foreach (int mark in marks)
        {
            Console.Write(mark + " ");
        }
    }

    static void BubbleSort(int[] arr)
    {
        int n = arr.Length;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (arr[j] > arr[j + 1])
                {
                    int temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                }
            }
        }
    }
}