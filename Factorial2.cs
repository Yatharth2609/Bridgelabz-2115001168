using System;

public class Factorial2 {
	
	// Function is used to calculate the factorial of a number n using for-loop
	private static void Compute(int n) {
		
		int fact = 1;
		
		for(int i = 1; i<= n; i++) {
			fact *= i;
		}
		
		Console.WriteLine($"Factorial of {n} is: {fact}");			
		
	}
	
	public static void Main(string[] args) {
		
		Console.Write("Enter a number to find its factorial: ");
		int num = Convert.ToInt32(Console.ReadLine());		

		Compute(num);
	}
}