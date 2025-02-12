using System;

public class CircularTour
{
    public static int FindStartingPoint(int[] petrol, int[] distance)
    {
        int n = petrol.Length;
        int start = 0;
        int deficit = 0;
        int surplus = 0;

        for (int i = 0; i < n; i++)
        {
            surplus += petrol[i] - distance[i];
            if (surplus < 0)
            {
                deficit += surplus;
                surplus = 0;
                start = i + 1;
            }
        }

        return (surplus + deficit >= 0) ? start : -1;
    }
}

class Program
{
    static void Main()
    {
        int[] petrol = { 4, 6, 7, 4 };
        int[] distance = { 6, 5, 3, 5 };
        int start = CircularTour.FindStartingPoint(petrol, distance);
        Console.WriteLine(start);
    }
}