using System;

public class NumberChecker4 {

    //Method to check if a number is a prime number
    private static bool IsPrime(int num) {
        if (num <= 1) return false;
        for (int i = 2; i <= Math.Sqrt(num); i++) {
            if (num % i == 0) return false;
        }
        return true;
    }

    //Method to check if a number is a neon number
    private static bool IsNeonNumber(int num) {
        int square = num * num;
        int sumOfDigits = 0;

        while (square > 0) {
            sumOfDigits += square % 10;
            square /= 10;
        }

        return sumOfDigits == num;
    }

    //Method to check if a number is a spy number
    private static bool IsSpyNumber(int num) {
        int sum = 0;
        int product = 1;

        while (num > 0) {
            int digit = num % 10;
            sum += digit;
            product *= digit;
            num /= 10;
        }

        return sum == product;
    }

    //Method to check if a number is an automorphic number
    private static bool IsAutomorphicNumber(int num) {
        int square = num * num;
        return square.ToString().EndsWith(num.ToString());
    }

    //Method to check if a number is a buzz number
    private static bool IsBuzzNumber(int num) {
        return num % 7 == 0 || num % 10 == 7;
    }

    public static void Main(string[] args) {
        Console.Write("Enter a number: ");
        int num = Convert.ToInt32(Console.ReadLine());

        bool isPrime = IsPrime(num);
        bool isNeon = IsNeonNumber(num);
        bool isSpy = IsSpyNumber(num);
        bool isAutomorphic = IsAutomorphicNumber(num);
        bool isBuzz = IsBuzzNumber(num);

        Console.WriteLine($"Is Prime: {isPrime}");
        Console.WriteLine($"Is Neon Number: {isNeon}");
        Console.WriteLine($"Is Spy Number: {isSpy}");
        Console.WriteLine($"Is Automorphic Number: {isAutomorphic}");
        Console.WriteLine($"Is Buzz Number: {isBuzz}");
    }
}
