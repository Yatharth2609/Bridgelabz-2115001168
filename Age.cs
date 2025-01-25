using System;

public class Age{
	
	private static void Compute(int[] arr) {
		for(int i=0; i<arr.Length; i++) {
			if(arr[i] >= 18) {
				Console.WriteLine($"The student with the age {arr[i]} can vote");
			} else {
				Console.WriteLine($"The student with the age {arr[i]} cannot vote");
			}
		}
	}
	
	public static void Main(string[] args) {
		int[] arr = new int[10];
		
		Console.WriteLine($"Enter the age of all the students: ");
		for(int i=0; i<arr.Length; i++) {
			arr[i] = Convert.ToInt32(Console.ReadLine());
		}
		
		Compute(arr);

	} 
}