using System;

public class DigitFrequencyCounter
{
    // Method to calculate digit frequencies
    private static int[] CalculateDigitFrequency(long number)
    {

        int[] frequencyArray = new int[10];

        string numberString = Math.Abs(number).ToString();

        foreach (char digitChar in numberString)
        {
            int digit = digitChar - '0';
            frequencyArray[digit]++;
        }

        return frequencyArray;
    }

    // Method to display digit frequencies
    private static void DisplayDigitFrequencies(int[] frequencyArray)
    {
        Console.WriteLine("\nDigit Frequencies:");
        for (int i = 0; i < frequencyArray.Length; i++)
        {
            if (frequencyArray[i] > 0)
            {
                Console.WriteLine($"Digit {i}: {frequencyArray[i]} time(s)");
            }
        }
    }

    public static void Main(string[] args)
    {

        Console.Write("Enter a number: ");
        if (!long.TryParse(Console.ReadLine(), out long number))
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
            return;
        }

        int[] frequencies = CalculateDigitFrequency(number);
        DisplayDigitFrequencies(frequencies);
    }
}