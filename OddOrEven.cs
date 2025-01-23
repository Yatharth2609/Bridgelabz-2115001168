using System;

public class OddOrEven {
	
	// Function is used to print wheather a number is odd or even
	private static void Compute(int n) {
		
		for(int i = 1; i<= n; i++) {
			if(i % 2 == 0)
				Console.WriteLine($"{i} -> Even");
			else
				Console.WriteLine($"{i} -> Odd");
		}
				
		
	}
	
	public static void Main(string[] args) {
		
		Console.Write("Enter a number: ");
		int num = Convert.ToInt32(Console.ReadLine());		

		Compute(num);
	}
}