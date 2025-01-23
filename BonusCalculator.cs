using System;

public class BonusCalculator {
	
	// Function is used calculate bonus
	private static void Compute(int salary, int year) {
		
		if(year >= 5) {
			double bonus = (5.0 / 100) * salary;
			Console.Write($"Your bonus amount is: {bonus}");
		} else {
			Console.Write($"Your are not eligible for bonus");
		}
		
	}
	
	public static void Main(string[] args) {
		
		Console.Write("Enter a your salary: ");
		int salary = Convert.ToInt32(Console.ReadLine());	

		Console.Write("Enter a your total year of service: ");
		int year = Convert.ToInt32(Console.ReadLine());	

		Compute(salary, year);
	}
}