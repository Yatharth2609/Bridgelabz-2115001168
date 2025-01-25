using System;

class FriendsComparison
{
    // Method to find the youngest friend
    private static string FindYoungest(string[] names, int[] ages)
    {
        int minAgeIndex = 0;
        for (int i = 1; i < ages.Length; i++)
        {
            if (ages[i] < ages[minAgeIndex])
            {
                minAgeIndex = i;
            }
        }
        return names[minAgeIndex];
    }

    // Method to find the tallest friend
    private static string FindTallest(string[] names, double[] heights)
    {
        int maxHeightIndex = 0;
        for (int i = 1; i < heights.Length; i++)
        {
            if (heights[i] > heights[maxHeightIndex])
            {
                maxHeightIndex = i;
            }
        }
        return names[maxHeightIndex];
    }

    public static void Main(string[] args)
    {
        string[] names = { "Amar", "Akbar", "Anthony" };
        int[] ages = new int[names.Length];
        double[] heights = new double[names.Length];

 
        for (int i = 0; i < names.Length; i++)
        {
            Console.WriteLine($"Enter details for {names[i]}:");

            // Input age
            Console.Write("Age: ");
            while (!int.TryParse(Console.ReadLine(), out ages[i]) || ages[i] <= 0)
            {
                Console.WriteLine("Invalid input! Age must be a positive number. Please try again.");
                Console.Write("Age: ");
            }

            // Input height
            Console.Write("Height (in cm): ");
            while (!double.TryParse(Console.ReadLine(), out heights[i]) || heights[i] <= 0)
            {
                Console.WriteLine("Invalid input! Height must be a positive number. Please try again.");
                Console.Write("Height (in cm): ");
            }
        }

  
        string youngest = FindYoungest(names, ages);
        string tallest = FindTallest(names, heights);

        Console.WriteLine("\n--- Results ---");
        Console.WriteLine($"The youngest friend is: {youngest}");
        Console.WriteLine($"The tallest friend is: {tallest}");
    }
}
