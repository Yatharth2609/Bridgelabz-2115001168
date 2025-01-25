using System;

public class Factors
{
    public static void Main(string[] args)
    {
        Console.Write("Enter a number: ");
        int num = Convert.ToInt32(Console.ReadLine());
		
		Compute(num);
    }

    // Method to find all the factors of a number
    private static void Compute(int num)
    {

        int[] arr = new int[num];
		int idx=0;
		for(int i=1; i<= num; i++) {
			if(num % i == 0) {
				arr[idx++] = i;
			}
		}
        // Resize arrays to fit the actual number of elements
        Array.Resize(ref arr, idx);
		PrintArray(arr);
    }


    private static void PrintArray(int[] arr)
    {
        foreach (int num in arr)
        {
            Console.Write(num + " ");
        }
        Console.WriteLine();
    }
}
