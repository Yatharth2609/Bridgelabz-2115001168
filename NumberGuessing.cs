using System;

public class NumberGuessing
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Think of a number between 1 and 100.");
        PlayGame();
    }

    private static void PlayGame()
    {
        int low = 1, high = 100;
        Random rand = new Random();
        
        while (low <= high)
        {
            int guess = GenerateGuess(low, high, rand);
            string userResponse = GetUserFeedback(guess);
            
            if (userResponse == "correct")
            {
                Console.WriteLine("Hooray! I guessed your number!");
                break;
            }
            else
            {
                UpdateRange(userResponse, ref low, ref high, guess);
            }
        }
    }

    private static int GenerateGuess(int low, int high, Random rand)
    {
        return rand.Next(low, high + 1);
    }

    private static string GetUserFeedback(int guess)
    {
        Console.WriteLine($"Is your number {guess}? (Enter 'high', 'low', or 'correct')");
        return Console.ReadLine().ToLower();
    }

    private static void UpdateRange(string userResponse, ref int low, ref int high, int guess)
    {
        if (userResponse == "high")
        {
            high = guess - 1;
        }
        else if (userResponse == "low")
        {
            low = guess + 1;
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter 'high', 'low', or 'correct'.");
        }
    }
}