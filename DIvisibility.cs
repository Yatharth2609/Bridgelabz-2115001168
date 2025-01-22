using System;

public class Divisibility {
	
	private static void Divide(int num) {
		if(num % 5 == 0) {
			Console.WriteLine($"Is the number {num} divisible by 5? Yes");
		} else {
			Console.WriteLine($"Is the number {num} divisible by 5? Yes");
		}
	}
	
	public static void Main(string[] args) {
		Console.Write("Enter the number to check the divisibility: ");
		int num = Convert.ToInt32(Console.ReadLine());
		
		Divide(num);
	}
}