using System;

public class TemperatureConverter
{

    // Method to convert Fahrenheit to Celsius
    public static double FahrenheitToCelsius(double fahrenheit)
    {
        return (fahrenheit - 32) * 5 / 9;
    }

    // Method to convert Celsius to Fahrenheit
    public static double CelsiusToFahrenheit(double celsius)
    {
        return (celsius * 9 / 5) + 32;
    }

    // Method to display the result
    public static void DisplayResult(double result, string unit)
    {
        if (unit == "C")
        {
            Console.WriteLine($"The temperature in Fahrenheit is: {result}°F");
        }
        else if (unit == "F")
        {
            Console.WriteLine($"The temperature in Celsius is: {result}°C");
        }
        else
        {
            Console.WriteLine("Invalid unit entered.");
        }
    }

    public static void Main(string[] args)
    {
		
        Console.Write("Enter the temperature: ");
        double temp = double.Parse(Console.ReadLine());
        Console.Write("Enter the unit (C for Celsius, F for Fahrenheit): ");
        string unit = Console.ReadLine().ToUpper();
        
        if (unit == "C")
        {
            double fahrenheit = CelsiusToFahrenheit(temp);
            DisplayResult(fahrenheit, unit);
        }
        else if (unit == "F")
        {
            double celsius = FahrenheitToCelsius(temp);
            DisplayResult(celsius, unit);
        }
        else
        {
            Console.WriteLine("Invalid unit entered.");
        }
    }
}
