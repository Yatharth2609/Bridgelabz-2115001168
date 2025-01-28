using System;

public class CheckNumber
{
    // This function checks if the number is positive or negative
    private static string IsPtive_Ntive(int num)
    {
        return num >= 0 ? "Positive" : "Negative";
    }

    // This function checks if the number is even or odd
    private static string IsEven_Odd(int num)
    {
        return num % 2 == 0 ? "Even" : "Odd";
    }

    // This function compares two numbers and return 1 if number1 > number2,
    // 0 if both are equal, or -1 if number1 < number2
    private static int Compare(int num1, int num2)
    {
        if (num1 > num2)
            return 1;
        else if (num1 < num2)
            return -1;
        else
            return 0;
    }
	
	
    public static void Main(string[] args)
    {
        int[] nums = new int[5];
        for (int i = 0; i < nums.Length; i++)
        {
            Console.Write($"Enter number {i + 1}: ");
            nums[i] = Convert.ToInt32(Console.ReadLine());
        }
        for (int i = 0; i < nums.Length; i++)
        {
            string positive = IsPtive_Ntive(nums[i]);
            Console.WriteLine($"Number {nums[i]} is {positive}");

            if (positive == "Positive")
            {
                string even_Odd = IsEven_Odd(nums[i]);
                Console.WriteLine($"Number {nums[i]} is {even_Odd}.");
            }
        }
        int compare_Result = Compare(nums[0], nums[nums.Length - 1]);

        if (compare_Result == 1)
        {
            Console.WriteLine($"The first element ({nums[0]}) is greater than the last element ({nums[nums.Length - 1]}).");
        }
        else if (compare_Result == 0)
        {
            Console.WriteLine($"The first element ({nums[0]}) is equal to the last element ({nums[nums.Length - 1]}).");
        }
        else
        {
            Console.WriteLine($"The first element ({nums[0]}) is less than the last element ({nums[nums.Length - 1]}).");
        }
    }
}
