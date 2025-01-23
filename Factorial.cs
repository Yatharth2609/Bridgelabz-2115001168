using System;

public class Factorial {
	
	// Function is used to calculate the factorial of a number n
	private static void Compute(int n) {
		
		int fact = 1;
		
		while(n > 0) {
			fact *= n;
			n--;
		}
		
		Console.WriteLine($"Factorial of {n} is: {fact}");			
		
	}
	
	public static void Main(string[] args) {
		
		Console.Write("Enter a number to find its factorial: ");
		int num = Convert.ToInt32(Console.ReadLine());		

		Compute(num);
	}
}