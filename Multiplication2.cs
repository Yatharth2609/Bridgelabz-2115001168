using System;

public class Multiplication2{
	
	//The function is used to print the multiplication table of number by storing the multiples in an array
	private static void Compute(int num) {
		
		int[] arr = new int[10];
		
		for(int i=0; i<arr.Length; i++) {
			arr[i] = (i+1) * num;
		}
		
		for(int i=0; i<arr.Length; i++) {
			Console.WriteLine($"{num} x {i + 1} = {arr[i]}");
		}
	}
	
	public static void Main(string[] args) {
		
		Console.WriteLine($"Enter a number(6 - 9): ");
		int num = Convert.ToInt32(Console.ReadLine());
		
		Compute(num);

	} 
}