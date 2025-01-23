using System;

public class MultiplicationTable {
	
	// Function is used to compute multiplication table of a number n
	private static void ComputeTable(int n) {
		
		for(int i = 1; i <= 10; i++) {
			Console.WriteLine($"{n} x {i} = {n * i}");
		}
		
	}
	
	public static void Main(string[] args) {
		
		Console.Write("Enter a number (6 - 9): ");
		int num = Convert.ToInt32(Console.ReadLine());	
		
		if(num < 6 || num > 9) {
			Console.WriteLine("Invalid Input");
			return;
		}

		ComputeTable(num);
	}
}