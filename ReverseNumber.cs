using System;

class ReverseNumber
{
    // Method to find the count of digits in a number
    static int GetDigitCount(int number)
    {
        int count = 0;
        while (number != 0)
        {
            count++;
            number /= 10;
        }
        return count;
    }

    // Method to extract digits from the number and store them in an array
    static int[] ExtractDigits(int number, int digitCount)
    {
        int[] digits = new int[digitCount];
        for (int i = digitCount - 1; i >= 0; i--)
        {
            digits[i] = number % 10;
            number /= 10;
        }
        return digits;
    }

    // Method to reverse the digits array
    static int[] ReverseArray(int[] digits)
    {
        int length = digits.Length;
        int[] reversed = new int[length];

        for (int i = 0; i < length; i++)
        {
            reversed[i] = digits[length - 1 - i];
        }

        return reversed;
    }

    static void Main(string[] args)
    {
        Console.Write("Enter a number: ");
        int number;
        number = Convert.ToInt32(Console.ReadLine());

        int digitCount = GetDigitCount(number);


        int[] digits = ExtractDigits(number, digitCount);

        int[] reversedDigits = ReverseArray(digits);

        Console.WriteLine("\n--- Reversed Number ---");
        foreach (int digit in reversedDigits)
        {
            Console.Write(digit);
        }
    }
}
