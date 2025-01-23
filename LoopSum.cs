using System;

public class LoopSum {
	
	// Function is used to calculate the sum of numbers util user enter 0
	private static void Sum() {
		int num = -1;
		int sum = 0;
		while(num != 0) {
			Console.Write("Enter a number to be added: ");
			num = Convert.ToInt32(Console.ReadLine());
			
			sum += num;
		}
		
		Console.WriteLine($"Total sum is: {sum}");
	}
	
	public static void Main(string[] args) {

		Sum();
	}
}