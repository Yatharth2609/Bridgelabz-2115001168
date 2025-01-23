using System;

public class FormulaSum {
	
	// Function is used to calculate the sum of n natural numbers and compares it with standard formula
	private static void Sum(int num) {
		
		int sum = 0;
		int formulaSum = (num * (num + 1)) / 2;
		
		while(num > 0) {
			sum += num;
			num--;
		}
		
		
		
		if(sum == formulaSum)
			Console.WriteLine($"Both the sum are equal: {sum}");			
		else
			Console.WriteLine($"Both the sum are not equal {sum} and {formulaSum}");
	}
	
	public static void Main(string[] args) {
		
		Console.Write("Enter a number: ");
		int num = Convert.ToInt32(Console.ReadLine());		

		Sum(num);
	}
}