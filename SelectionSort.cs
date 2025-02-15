// using System;

// class Program
// {
//     static void Main()
//     {
//         int[] scores = { 88, 75, 92, 65, 80, 70 };
//         SelectionSort(scores);
//         foreach (int score in scores)
//         {
//             Console.Write(score + " ");
//         }
//     }

//     static void SelectionSort(int[] arr)
//     {
//         int n = arr.Length;
//         for (int i = 0; i < n - 1; i++)
//         {
//             int minIdx = i;
//             for (int j = i + 1; j < n; j++)
//             {
//                 if (arr[j] < arr[minIdx])
//                 {
//                     minIdx = j;
//                 }
//             }
//             int temp = arr[minIdx];
//             arr[minIdx] = arr[i];
//             arr[i] = temp;
//         }
//     }
// }