using System;

public class MeanHeight{
	
	//The function is used to find the mean height of all the players of the team
	private static void Compute(double[] arr) {
		
		double mean;
		double sum = 0;
		for(int i=0; i<arr.Length; i++) {
			sum += arr[i];
		}
		
		mean = sum / (double)arr.Length;
		
		Console.WriteLine($"The Mean Height of all the players is: {Math.Round(mean, 2)}");
	}
	
	public static void Main(string[] args) {
		
		Console.WriteLine($"Enter the height of all the players: ");
		double[] arr = new double[11];

		for(int i=0; i<arr.Length; i++) {
			double num = Convert.ToDouble(Console.ReadLine());
			arr[i] = num;
		}
		
		Compute(arr);

	} 
}