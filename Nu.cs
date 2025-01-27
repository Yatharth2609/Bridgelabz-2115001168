using System;

public class NumberChecker2 {

    // Method to count the number of digits in a number
    private static int CountDigit(int num) {
        int res = 0;
        while (num > 0) {
            res++;
            num /= 10;
        }
        return res;
    }

    // Method to store digits of the number in an array
    private static int[] Store(int num) {
        int cnt = CountDigit(num);
        int[] arr = new int[cnt];
        int idx = 0;
        while (num > 0) {
            int rem = num % 10;
            arr[idx++] = rem;
            num /= 10;
        }
        return arr;
    }

    // Method to reverse the digits array
    private static int[] ReverseArray(int[] arr) {
        int[] reversed = new int[arr.Length];
        for (int i = 0; i < arr.Length; i++) {
            reversed[i] = arr[arr.Length - 1 - i];
        }
        return reversed;
    }

    // Method to compare two arrays and check if they are equal
    private static bool CompareArrays(int[] arr1, int[] arr2) {
        if (arr1.Length != arr2.Length) return false;
        for (int i = 0; i < arr1.Length; i++) {
            if (arr1[i] != arr2[i]) return false;
        }
        return true;
    }

    // Method to check if a number is a palindrome
    private static bool IsPalindrome(int num) {
        int[] digits = Store(num);
        int[] reversedDigits = ReverseArray(digits);
        return CompareArrays(digits, reversedDigits);
    }

    // Method to check if a number is a duck number
    private static bool IsDuckNumber(int num) {
        int[] digits = Store(num);

 
        if (digits[digits.Length - 1] == 0) return false;

  
        foreach (int digit in digits) {
            if (digit == 0) return true;
        }
        return false;
    }

   
    public static void Main(string[] args) {
        Console.Write("Enter a number: ");
        int num = Convert.ToInt32(Console.ReadLine());

        int digitCount = CountDigit(num);
        int[] digits = Store(num);
        int[] reversed = ReverseArray(digits);
        bool isPalindrome = IsPalindrome(num);
        bool isDuck = IsDuckNumber(num);

 
        Console.WriteLine($"Number of Digits: {digitCount}");
        Console.WriteLine($"Digits Array: {string.Join(", ", digits)}");
        Console.WriteLine($"Reversed Digits Array: {string.Join(", ", reversed)}");
        Console.WriteLine($"Is Palindrome: {isPalindrome}");
        Console.WriteLine($"Is Duck Number: {isDuck}");
    }
}
