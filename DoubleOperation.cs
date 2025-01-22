using System;

public class DoubleOperation {
	
	//The function is used to test Operations on Double
	private static void Operation(double a, double b, double c) {
		
	Console.WriteLine($"The results of Int Operations are {a + b * c}, {a * b + c}, {c + a / b} and {a % b + c}");
	}
	
	
	public static void Main(string[] args) {
		Console.Write("Enter the first number: ");
		double num1 = Convert.ToDouble(Console.ReadLine());
		
		Console.Write("Enter the second number: ");
		double num2 = Convert.ToDouble(Console.ReadLine());
		
		Console.Write("Enter the third number: ");
		double num3 = Convert.ToDouble(Console.ReadLine());
		
		Operation(num1, num2, num3);
		
	}
}