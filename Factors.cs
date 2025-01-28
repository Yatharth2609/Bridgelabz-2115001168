/* using System;

public class Factors
{
    public static void Main(string[] args)
    {
        Console.Write("Enter a number to find its factors: ");
        int num = Convert.ToInt32(Console.ReadLine());
		
       
        int[] ftors = findfactors(num);

        Console.WriteLine("Factors of the number are: " + string.Join(", ", ftors));

        int sum = SumFactors(ftors);
        Console.WriteLine($"Sum of factors: {sum}");
   
        long prod = prodfactors(ftors);
        Console.WriteLine($"Product of factors: {prod}");

        int sumSqrs = SumSqFactors(ftors);
        Console.WriteLine($"Sum of squares of factors: {sumSqrs}");
    }
	
    // This function finds the factors of a number and returns them as an array
    private static int[] findfactors(int num)
    {
        int cnt = 0;
        for (int i = 1; i <= num; i++)
        {
            if (num % i == 0)
                cnt++;
        }
        int[] ftors = new int[cnt];
        int idx = 0;
        for (int i = 1; i <= num; i++)
        {
            if (num % i == 0)
            {
                ftors[idx] = i;
                idx++;
            }
        }
        return ftors;
    }
	
    // This function calculates the sum of factors
    private static int SumFactors(int[] ftors)
    {
        int sum = 0;
        foreach (int ftor in ftors)
        {
            sum += ftor;
        }
        return sum;
    }
	
    // This function calculates the product of factors
    private static long prodfactors(int[] ftors)
    {
        long prod = 1;
        foreach (int ftor in ftors)
        {
            prod *= ftor;
        }
        return prod;
    }
	
    // This function calculates the sum of squares of factors
    private static int SumSqFactors(int[] ftors)
    {
        int sumOfSq = 0;
        foreach (int ftor in ftors)
        {
            sumOfSq += (int)Math.Pow(ftor, 2);
        }
        return sumOfSq;
    }
 */