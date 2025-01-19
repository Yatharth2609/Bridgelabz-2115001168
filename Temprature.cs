using System;

public class Temperature {
    public static void Main(string[] args) {
	Console.Write("Enter the temperature in Celsius: ");
	int temp = int.Parse(Console.ReadLine());
	
	double far = (temp * 9/5) + 32;
	
	Console.WriteLine("Temperature in Fahrenheit is: " + far);
    }
}
