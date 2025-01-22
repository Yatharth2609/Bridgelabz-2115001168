using System;

public class TemperatureConversion2 {
	
	// The function is designed to convert Temprature from Fahrenheit to Celsius
	private static void Coversion(int temp) {
		double Celsius = (temp - 32) * 5 / 9;
		
		Console.WriteLine($"The {temp} Fahrenheit is {Celsius} Celsius");
	}
	public static void Main(string[] args) {
		Console.Write("Enter the temprature in Fahrenheit: ");
		int temp = Convert.ToInt32(Console.ReadLine());
		
		Coversion(temp);
	}
} 