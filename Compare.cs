 using System;
 
public class Compare
{
    // This function finds the youngest friend
    private static string Youngest(int[] ages, string[] names)
    {
        int min_Age = ages[0];
        string young_est = names[0];

        for (int i = 1; i < ages.Length; i++)
        {
            if (ages[i] < min_Age)
            {
                min_Age = ages[i];
                young_est = names[i];
            }
        }
        return young_est;
    }
	
    // This function finds the tallest friend
    private static string Tallest(int[] hgts, string[] names)
    {
        int max_Hgt = hgts[0];
        string tall_est = names[0];
        for (int i = 1; i < hgts.Length; i++)
        {
            if (hgts[i] > max_Hgt)
            {
                max_Hgt = hgts[i];
                tall_est = names[i];
            }
        }
        return tall_est;
    }

    public static void Main(string[] args)
    {
        string[] names = new string[] { "Amar", "Akbar", "Anthony" };
        int[] ages = new int[3];
        int[] hgts = new int[3];
        for (int i = 0; i < 3; i++)
        {
            Console.Write($"Enter age of {names[i]}: ");
            ages[i] = Convert.ToInt32(Console.ReadLine());

            Console.Write($"Enter height (in cm) of {names[i]}: ");
            hgts[i] = Convert.ToInt32(Console.ReadLine());
        }
        string young_est = Youngest(ages, names);
        Console.WriteLine($"\nThe youngest friend is: {young_est}");
		
        string tall_est = Tallest(hgts, names);
        Console.WriteLine($"The tallest friend is: {tall_est}");
    }
}
