// using System;

// class Sort
// {
//     static void Main()
//     {
//         double[] prices = { 99.99, 49.99, 129.99, 79.99, 59.99 };
//         QuickSort(prices, 0, prices.Length - 1);
//         foreach (double price in prices)
//         {
//             Console.Write(price + " ");
//         }
//     }

//     static void QuickSort(double[] arr, int low, int high)
//     {
//         if (low < high)
//         {
//             int pi = Partition(arr, low, high);
//             QuickSort(arr, low, pi - 1);
//             QuickSort(arr, pi + 1, high);
//         }
//     }

//     static int Partition(double[] arr, int low, int high)
//     {
//         double pivot = arr[high];
//         int i = low - 1;
//         for (int j = low; j < high; j++)
//         {
//             if (arr[j] < pivot)
//             {
//                 i++;
//                 double temp = arr[i];
//                 arr[i] = arr[j];
//                 arr[j] = temp;
//             }
//         }
//         double temp1 = arr[i + 1];
//         arr[i + 1] = arr[high];
//         arr[high] = temp1;
//         return i + 1;
//     }
// }