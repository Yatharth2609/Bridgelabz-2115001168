using System;

public class NumberNature{
	
	//The function is used to find out whether a number is positive, negative or zero by iterating through an array
	private static void Compute(int[] arr) {
		for(int i=0; i<arr.Length; i++) {
			if(arr[i] > 0) {
				Console.WriteLine($"{arr[i]} -> Positive");
			} else if(arr[i] < 0) {
				Console.WriteLine($"{arr[i]} -> Negative");
			} else {
				Console.WriteLine($"{arr[i]} -> Zero");
			}
		}
	}
	
	public static void Main(string[] args) {
		int[] arr = new int[5];
		
		Console.WriteLine($"Enter the numbers: ");
		for(int i=0; i<arr.Length; i++) {
			arr[i] = Convert.ToInt32(Console.ReadLine());
		}
		
		Compute(arr);

	} 
}