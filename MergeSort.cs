// using System;

// class Sort
// {
//     static void Main()
//     {
//         double[] prices = { 45.99, 12.50, 67.80, 23.45, 34.99 };
//         MergeSort(prices, 0, prices.Length - 1);
//         foreach (double price in prices)
//         {
//             Console.Write(price + " ");
//         }
//     }

//     static void MergeSort(double[] arr, int left, int right)
//     {
//         if (left < right)
//         {
//             int mid = left + (right - left) / 2;
//             MergeSort(arr, left, mid);
//             MergeSort(arr, mid + 1, right);
//             Merge(arr, left, mid, right);
//         }
//     }

//     static void Merge(double[] arr, int left, int mid, int right)
//     {
//         int n1 = mid - left + 1;
//         int n2 = right - mid;
//         double[] L = new double[n1];
//         double[] R = new double[n2];
//         for (int i = 0; i < n1; i++)
//             L[i] = arr[left + i];
//         for (int j = 0; j < n2; j++)
//             R[j] = arr[mid + 1 + j];
//         int k = left;
//         int x = 0, y = 0;
//         while (x < n1 && y < n2)
//         {
//             if (L[x] <= R[y])
//             {
//                 arr[k] = L[x];
//                 x++;
//             }
//             else
//             {
//                 arr[k] = R[y];
//                 y++;
//             }
//             k++;
//         }
//         while (x < n1)
//         {
//             arr[k] = L[x];
//             x++;
//             k++;
//         }
//         while (y < n2)
//         {
//             arr[k] = R[y];
//             y++;
//             k++;
//         }
//     }
// }