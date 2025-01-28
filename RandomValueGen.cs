using System;
class RandomValueGen
{
    // This function generates an array of 4-digit random numbers
    private static int[] Generate4DigitRandomArray(int size)
    {
        Random rand = new Random();
        int[] randomNum = new int[size];
        for (int i = 0; i < size; i++)
        {
            randomNum[i] = rand.Next(1000, 10000);
        }

        return randomNum;
    }

    // This function finds average, min, and max value of an array
    private static double[] FindAverageMinMax(int[] num)
    {
        double sum = 0;
        int min = num[0];
        int max = num[0];
        foreach (var digit in num)
        {
            sum += digit;  
            min = Math.Min(min, digit);
            max = Math.Max(max, digit);
        }

        double avg = sum / num.Length;
        return new double[] { avg, min, max };
    }

    public static void Main(string[] args)
    {
        int[] randomNum = Generate4DigitRandomArray(5);
        Console.WriteLine("Generated 4-digit random numbers:");
        foreach (var num in randomNum)
        {
            Console.WriteLine(num);
        }
        double[] res = FindAverageMinMax(randomNum);
        Console.WriteLine($"\nAverage: {res[0]:F2}");
        Console.WriteLine($"Minimum Value: {res[1]}");
        Console.WriteLine($"Maximum Value: {res[2]}");
    }
}
