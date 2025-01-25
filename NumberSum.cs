using System;

public class NumberSum{
	
	//The function is used to print all the numbers entered by user and their sum
	private static void Compute(int[] arr) {
		int sum = 0;
		Console.WriteLine("Numbers Entered: ");
		for(int i=0; i<arr.Length; i++) {
			Console.WriteLine($"{arr[i]}");
			sum += arr[i];
			if(arr[i] == 0)
				break;
		}
		
		Console.Write($"Sum of all the numbers are: {sum}");
		
		
	}
	
	public static void Main(string[] args) {
		
		Console.WriteLine($"Enter all the 10 number (or enter 0/-ve to exit): ");
		int[] arr = new int[10];
		for(int i=0; i<arr.Length; i++) {
			int num = Convert.ToInt32(Console.ReadLine());
			arr[i] = num;
			if(num == 0 || num < 0)
				break;
		}
		
		Compute(arr);

	} 
}