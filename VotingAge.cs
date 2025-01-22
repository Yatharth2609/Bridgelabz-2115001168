using System;

public class VotingAge {
	
	//Checks the voting right of a person
	private static void Compute(int age) {
		if(age >= 18) {
			Console.Write($"The person's age is {age} and can vote.");
		} else {
			Console.Write($"The person's age is {age} and cannot vote.");
		}
	}
	
	public static void Main(string[] args) {
		Console.Write($"Enter your age: ");
		int age = Convert.ToInt32(Console.ReadLine());
		
		Compute(age);
		
	}
}