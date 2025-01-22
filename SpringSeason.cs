 using System;

public class SpringSeason {
	
	//Checks wheather the  month is in Spring Season or not
	private static void helper(int month, int day) {
		if(day >= 20 && day <= 31 && month >= 3 && month <= 6) {
			Console.Write($"The day {day} {month} comes under Spring Season");
		} else {
			Console.Write($"The day {day} {month} does not come under Spring Season");
		}
	}
	
	public static void Main(string[] args) {
		Console.Write($"Enter the number: ");
		int num = Convert.ToInt32(Console.ReadLine());
		
		Positivity(num);
		
	}
}