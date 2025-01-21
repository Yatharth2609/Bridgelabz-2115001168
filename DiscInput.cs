/* using System;

public class DiscInput {
	public static void Main(string[] args) {
		
		Console.Write("Enter the fee of the course: ");
		double fee = Convert.ToDouble(Console.ReadLine());
		
		Console.Write("Enter the discount percentage: ");
		double disc = Convert.ToDouble(Console.ReadLine());
		
		double discAmount = ( disc / 100 ) * fee; 
		double discFee = fee - discAmount;

		Console.WriteLine($"The discount amount is INR{discAmount} and final discounted fee is INR{discFee}");
	}
}  */