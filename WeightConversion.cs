using System;

public class WeightConversion {
	
	// This function converts the weight from Pounds to Kilograms
	private static void ConvertWeight(int weight) {
		double kg = weight * 0.453592; // Corrected conversion factor
		
		Console.WriteLine($"The weight of the person in pounds is {weight} and in kilograms is {Math.Round(kg, 2)}");
	}
	
	public static void Main(string[] args) {
		Console.Write("Enter the weight in pounds: ");
		
		int weight = System.Convert.ToInt32(Console.ReadLine());
		
		ConvertWeight(weight);
	}
}
