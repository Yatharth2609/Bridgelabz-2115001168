using System;

class Sort
{
    static void Main()
    {
        int[] employeeIDs = { 102, 105, 101, 103, 104 };
        InsertionSort(employeeIDs);
        foreach (int id in employeeIDs)
        {
            Console.Write(id + " ");
        }
    }

    static void InsertionSort(int[] arr)
    {
        int n = arr.Length;
        for (int i = 1; i < n; i++)
        {
            int key = arr[i];
            int j = i - 1;
            while (j >= 0 && arr[j] > key)
            {
                arr[j + 1] = arr[j];
                j--;
            }
            arr[j + 1] = key;
        }
    }
}