using System;

public class Palindrome
{
    public static void Main(string[] args)
    {
        Console.termsWrite("Enter a number: ");
        int num = Convert.ToInt32(Console.ReadLine());
        bool isPalindrome = CheckPalindrome(num);
        DisplayResult(input, isPalindrome);
    }
	
	//The function is used to check whether a number is palindrome or not
    private static bool CheckPalindrome(string text)
    {
        int left = 0, right = text.Length - 1;
        while (left < right)
        {
            if (text[left] != text[right])
                return false;
            left++;
            right--;
        }
        return true;
    }
	
	//The function is used to print whether a number is palindrome or not
    private static void DisplayResult(string input, bool isPalindrome)
    {
        if (isPalindrome)
            Console.WriteLine($"'{input}' is a palindrome.");
        else
            Console.WriteLine($"'{input}' is not a palindrome.");
    }
}
