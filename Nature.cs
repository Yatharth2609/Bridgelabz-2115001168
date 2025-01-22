 using System;

public class Nature {
	
	//Checks nature of a number
	private static void Positivity(int num) {
		if(num > 0) {
			Console.Write($"Positive");
		} else if(num < 0) {
			Console.Write($"Negative");
		} else {
			Console.Write($"Zero");
		}
	}
	
	public static void Main(string[] args) {
		Console.Write($"Enter the number: ");
		int num = Convert.ToInt32(Console.ReadLine());
		
		Positivity(num);
		
	}
}