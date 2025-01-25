using System;

public class DigitsArray
{
    // Method to extract digits of the number and store them in an array
    private static int[] ExtractDigits(int number, int maxDigits, out int count)
    {
        int[] digits = new int[maxDigits];
        count = 0;

        while (number != 0)
        {
            if (count == maxDigits) break;

            digits[count++] = number % 10;
            number /= 10;
        }

        return digits;
    }

    // Method to find the largest and second-largest digits
    private static void FindLargestAndSecondLargest(int[] digits, int count, out int largest, out int secondLargest)
    {
        largest = 0;
        secondLargest = 0;

        for (int i = 0; i < count; i++)
        {
            if (digits[i] > largest)
            {
                secondLargest = largest;
                largest = digits[i];
            }
            else if (digits[i] > secondLargest && digits[i] != largest)
            {
                secondLargest = digits[i];
            }
        }
    }

    public static void Main(string[] args)
    {
        Console.Write("Enter a number: ");
        int number;
        while (!int.TryParse(Console.ReadLine(), out number) || number <= 0)
        {
            Console.WriteLine("Invalid input! Please enter a positive integer.");
            Console.Write("Enter a number: ");
        }

        const int maxDigits = 10;
        int[] digits;
        int count;

        // Extract digits from the number
        digits = ExtractDigits(number, maxDigits, out count);

        // Find the largest and second-largest digits
        int largest, secondLargest;
        FindLargestAndSecondLargest(digits, count, out largest, out secondLargest);

        Console.WriteLine("\n--- Results ---");
        Console.WriteLine($"Largest digit: {largest}");
        Console.WriteLine($"Second largest digit: {secondLargest}");
    }
}
