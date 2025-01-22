using System;

public class IntOperation {
	
	//The function is used to test Operations on Integer
	private static void Operation(int a, int b, int c) {
		
	Console.WriteLine($"The results of Int Operations are {a + b * c}, {a * b + c}, {c + a / b} and {a % b + c}");
	}
	
	
	public static void Main(string[] args) {
		Console.Write("Enter the first number: ");
		int num1 = Convert.ToInt32(Console.ReadLine());
		
		Console.Write("Enter the second number: ");
		int num2 = Convert.ToInt32(Console.ReadLine());
		
		Console.Write("Enter the third number: ");
		int num3 = Convert.ToInt32(Console.ReadLine());
		
		Operation(num1, num2, num3);
		
	}
}