using System;

public class VoteChecker
{
    // This function checks if the student can vote based on age
    private static bool StudVote(int age)
    {
        if (age < 0)
        {
            return false; 
        }
        return age >= 18;
    }
	
    public static void Main(string[] args)
    {
        int[] studAges = new int[10];
        for (int i = 0; i < 10; i++)
        {
            Console.Write($"Enter age of student {i + 1}: ");
            studAges[i] = Convert.ToInt32(Console.ReadLine());
        }
        for (int i = 0; i < 10; i++)
        {
            bool Vote = StudVote(studAges[i]);
            if (Vote)
            {
                Console.WriteLine($"Student {i + 1} with age {studAges[i]} can vote.");
            }
            else
            {
                Console.WriteLine($"Student {i + 1} with age {studAges[i]} cannot vote.");
            }
        }
    }
}
