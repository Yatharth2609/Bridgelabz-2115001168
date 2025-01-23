using System;

public class Counter {
	
	// Function is used to countdown from the a number till 1
	private static void Count(int num) {
		while(num >= 1) {
			Console.WriteLine($"{num}");
			num--;
		} 
	}
	
	public static void Main(string[] args) {
		Console.Write("Enter the number to start countdown from: ");
		int num = Convert.ToInt32(Console.ReadLine());
		
		Count(num);
	}
}