using System;

public class NaturalNumberSum {
	
	//The function calculates the sum of first natural n numbers
	private static void Sum(int n) {
		if(n == 0) {
			Console.Write($"{n} is not a natural number");
			return;
		}
		
		int sum = (n * (n + 1)) / 2;
		
		Console.Write($"The sum of {n} natural numbers is {sum}");
	}
	
	public static void Main(string[] args) {
		
		Console.Write("Enter the number: ");
		int n = Convert.ToInt32(Console.ReadLine());
		
		Sum(n);
	}
} 