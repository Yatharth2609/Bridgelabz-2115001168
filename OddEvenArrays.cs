using System;

public class OddEvenArrays
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter a natural number:");
        if (!int.TryParse(Console.ReadLine(), out int number) || number < 1)
        {
            Console.WriteLine("Error: Please enter a valid natural number (greater than 0).");
            return;
        }


        int[] oddNumbers, evenNumbers;
        ProcessNumbers(number, out oddNumbers, out evenNumbers);

        PrintArray("Odd Numbers", oddNumbers);
        PrintArray("Even Numbers", evenNumbers);
    }

    // Method to process numbers and separate them into odd and even arrays
    private static void ProcessNumbers(int number, out int[] oddNumbers, out int[] evenNumbers)
    {

        oddNumbers = new int[number / 2 + 1];
        evenNumbers = new int[number / 2 + 1];

        int oddIndex = 0, evenIndex = 0;

        for (int i = 1; i <= number; i++)
        {
            if (i % 2 == 0)
            {
                evenNumbers[evenIndex++] = i; 
            }
            else
            {
                oddNumbers[oddIndex++] = i; 
            }
        }

        // Resize arrays to fit the actual number of elements
        Array.Resize(ref oddNumbers, oddIndex);
        Array.Resize(ref evenNumbers, evenIndex);
    }


    private static void PrintArray(string label, int[] array)
    {
        Console.WriteLine($"{label}:");
        foreach (int num in array)
        {
            Console.Write(num + " ");
        }
        Console.WriteLine();
    }
}
