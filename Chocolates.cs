public class Chocolates {
	
	// The function computes how many chocolates will student get and how many is remaining
	private static void Compute(int children, int chocolates) {
		int res = chocolates > children ? chocolates / children : children / chocolates;
		int rem = chocolates > children ? chocolates % children : children % chocolates;
		
		Console.WriteLine($" The number of chocolates each child gets is {res} and the number of remaining chocolates is {rem}");
	}
	
	public static void Main(string[] args) {
		Console.Write("Enter total number of chidren: ");
		int children = Convert.ToInt32(Console.ReadLine());
		
		Console.Write("Enter total number of chocolates: ");
		int chocolates = Convert.ToInt32(Console.ReadLine());
		
		Compute(children, chocolates);
	}
}