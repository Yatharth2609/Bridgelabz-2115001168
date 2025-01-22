using System;

public class SimpleInterest {
	
	private static void ComputeSI(int p, int r, int t) {
		int si = (p * r * t) / 100;
		
		Console.Write($"The Simple Interest is {si} for Principal {p}, Rate of Interest {r} and Time {t}");
	}
	
	public static void Main(string[] args) {
		Console.Write("Enter the pricipal amount: ");
		int p = Convert.ToInt32(Console.ReadLine());
		
		Console.Write("Enter the rate: ");
		int r = Convert.ToInt32(Console.ReadLine());
		
		Console.Write("Enter the time duration: ");
		int t = Convert.ToInt32(Console.ReadLine());
		
		ComputeSI(p, r, t);
	}
}
}