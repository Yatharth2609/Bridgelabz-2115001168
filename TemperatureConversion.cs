using System;

public class TemperatureConversion {
	
	// The function is designed to convert Temprature from Celsius to Fahrenheit
	private static void Coversion(int temp) {
		double fahrenhiet = (temp * 9 / 5) +32;
		
		Console.WriteLine($"The {temp} Celsius is {fahrenhiet} Fahrenheit");
	}
	public static void Main(string[] args) {
		Console.Write("Enter the temprature in Celsius: ");
		int temp = Convert.ToInt32(Console.ReadLine());
		
		Coversion(temp);
	}
}