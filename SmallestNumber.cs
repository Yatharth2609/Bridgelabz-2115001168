using System;

public class Smallest {
	
	private static void SmallestNumber(int num1, int num2, int num3) {
		if(num1 > num2 && num1 > num3) {
			Console.WriteLine($"Is the first number the smallest? Yes");
		} else {
			Console.WriteLine($"Is the first number the smallest? No");
		}
	}
	
	public static void Main(string[] args) {
		Console.Write("Enter the first number: ");
		int num1 = Convert.ToInt32(Console.ReadLine());
		
		Console.Write("Enter the second number: ");
		int num2 = Convert.ToInt32(Console.ReadLine());
		
		Console.Write("Enter the third number: ");
		int num3 = Convert.ToInt32(Console.ReadLine());
		
		SmallestNumber(num1, num2, num3);
	}
}