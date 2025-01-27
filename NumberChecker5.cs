using System;

public class NumberChecker5 {
    //Method to find factors of a number and return them as an array
    private static int[] GetFactors(int num) {
        int count = 0;

        for (int i = 1; i <= num; i++) {
            if (num % i == 0) count++;
        }
		
		int[] factors = new int[count];
        int index = 0;
        for (int i = 1; i <= num; i++) {
            if (num % i == 0) factors[index++] = i;
        }

        return factors;
    }

    //Method to find the greatest factor of a number using the factors array
    private static int GetGreatestFactor(int[] factors) {
        return factors[factors.Length - 2]; // Exclude the number itself
    }

    //Method to find the sum of factors using the factors array
    private static int SumOfFactors(int[] factors) {
        int sum = 0;
        foreach (int factor in factors) {
            sum += factor;
        }
        return sum;
    }

    //Method to find the product of factors using the factors array
    private static long ProductOfFactors(int[] factors) {
        long product = 1;
        foreach (int factor in factors) {
            product *= factor;
        }
        return product;
    }

    //Method to find the product of the cube of factors using factors array
    private static double ProductOfCubes(int[] factors) {
        double product = 1;
        foreach (int factor in factors) {
            product *= Math.Pow(factor, 3);
        }
        return product;
    }

    //Method to check if a number is a perfect number
    private static bool IsPerfectNumber(int num, int[] factors) {
        int sum = SumOfFactors(factors) - num; // Exclude the number itself
        return sum == num;
    }

    //Method to check if a number is an abundant number
    private static bool IsAbundantNumber(int num, int[] factors) {
        int sum = SumOfFactors(factors) - num; // Exclude the number itself
        return sum > num;
    }

    //Method to check if a number is a deficient number
    private static bool IsDeficientNumber(int num, int[] factors) {
        int sum = SumOfFactors(factors) - num; // Exclude the number itself
        return sum < num;
    }

    // Method to check if a number is a strong number
    private static bool IsStrongNumber(int num) {
        int sum = 0;
        int original = num;

        while (num > 0) {
            int digit = num % 10;
            sum += Factorial(digit);
            num /= 10;
        }

        return sum == original;
    }


    private static int Factorial(int n) {
        int fact = 1;
        for (int i = 2; i <= n; i++) {
            fact *= i;
        }
        return fact;
    }

    public static void Main(string[] args) {
        Console.Write("Enter a number: ");
        int num = Convert.ToInt32(Console.ReadLine());

        int[] factors = GetFactors(num);

        Console.WriteLine($"Factors: {string.Join(", ", factors)}");
        Console.WriteLine($"Greatest Factor (excluding itself): {GetGreatestFactor(factors)}");
        Console.WriteLine($"Sum of Factors: {SumOfFactors(factors)}");
        Console.WriteLine($"Product of Factors: {ProductOfFactors(factors)}");
        Console.WriteLine($"Product of Cubes of Factors: {ProductOfCubes(factors)}");
        Console.WriteLine($"Is Perfect Number: {IsPerfectNumber(num, factors)}");
        Console.WriteLine($"Is Abundant Number: {IsAbundantNumber(num, factors)}");
        Console.WriteLine($"Is Deficient Number: {IsDeficientNumber(num, factors)}");
        Console.WriteLine($"Is Strong Number: {IsStrongNumber(num)}");
    }
}
