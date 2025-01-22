using System;

public class Largest {
	
	//The function checks which number is the largest amongst the three
	private static void LargestNumber(int num1, int num2, int num3) {
		if(num1 > num2 && num1 > num3) {
			Console.WriteLine($"Is the first number the largest? Yes");
			Console.WriteLine($"Is the second number the largest? No");
			Console.WriteLine($"Is the third number the largest? No");
		} else if(num2 > num1 && num2 > num3) {
			Console.WriteLine($"Is the first number the largest? No");
			Console.WriteLine($"Is the second number the largest? Yes");
			Console.WriteLine($"Is the third number the largest? No");
		} else {
			Console.WriteLine($"Is the first number the largest? No");
			Console.WriteLine($"Is the second number the largest? No");
			Console.WriteLine($"Is the third number the largest? Yes");
		}
	}
	
	public static void Main(string[] args) {
		Console.Write("Enter the first number: ");
		int num1 = Convert.ToInt32(Console.ReadLine());
		
		Console.Write("Enter the second number: ");
		int num2 = Convert.ToInt32(Console.ReadLine());
		
		Console.Write("Enter the third number: ");
		int num3 = Convert.ToInt32(Console.ReadLine());
		
		LargestNumber(num1, num2, num3);
	}
}