using System;

public class WhileLoopSum {
	
	// Function is used to calculate the sum of numbers until user enter 0 or a negative number
	private static void Sum() {
		int num = -1;
		int sum = 0;
		while(true) {
			Console.Write("Enter a number to be added: ");
			num = Convert.ToInt32(Console.ReadLine());
			
			if(num == 0 || num < 0)
				break;
			
			sum += num;
		}
		
		Console.WriteLine($"Total sum is: {sum}");
	}
	
	public static void Main(string[] args) {

		Sum();
	}
}