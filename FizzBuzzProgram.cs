using System;

public class FizzBuzzProgram
{
    public static void Main(string[] args)
    {
        Console.Write("Enter a positive integer: ");
        int num = Convert.ToInt32(Console.ReadLine());
		
		if(num < 0) {
			Console.Write("Invalid Input");
			return;
		}

        string[] results = GenerateFizzBuzz(num);

      
        PrintResults(results);
    }

    // Method to generate FizzBuzz results
    private static string[] GenerateFizzBuzz(int number)
    {
        string[] results = new string[number + 1];

        for (int i = 0; i <= number; i++)
        {
            if (i % 3 == 0 && i % 5 == 0)
            {
                results[i] = "FizzBuzz";
            }
            else if (i % 3 == 0)
            {
                results[i] = "Fizz";
            }
            else if (i % 5 == 0)
            {
                results[i] = "Buzz";
            }
            else
            {
                results[i] = i.ToString();
            }
        }

        return results;
    }

    // Method to print the results with position
    private static void PrintResults(string[] results)
    {
        Console.WriteLine("FizzBuzz Results:");
        for (int i = 0; i < results.Length; i++)
        {
            Console.WriteLine($"Position {i} = {results[i]}");
        }
    }
}
