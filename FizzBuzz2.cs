using System;

public class FizzBuzz2
{
    public static void Main(string[] args)
    {

            Console.Write("Enter a positive integer: ");
            int num = Convert.ToInt32(Console.ReadLine());

            if (num <= 0)
            {
                Console.WriteLine("Please enter a positive integer!");
                return;
            }

            // Loop from 1 to the input number
            while(num != 0)
            {
                if (i % 3 == 0 && i % 5 == 0)
                {
                    Console.WriteLine("FizzBuzz");
                }
                else if (i % 3 == 0)
                {
                    Console.WriteLine("Fizz");
                }
                else if (i % 5 == 0)
                {
                    Console.WriteLine("Buzz");
                }
                else
                {
                    Console.WriteLine(i);
                }
				
				num--;
            }
     
    }
}
