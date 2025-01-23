public class Power {
	
	private static Compute(int power, int bs) {
		int expo = 1;
		
		for(int i=1; i<=power; i++ ) {
			expo *= bs;
		}
		
		Console.WriteLine($"The Exponent of {bs} power {power} is: {expo}");
	}
	
	public static void Main(string[] args) {
		Console.Write("Enter the base: ");
        int bs = int.Parse(Console.ReadLine());
		
		Console.Write("Enter the power: ");
        int power = int.Parse(Console.ReadLine());
		
		Compute(bs, power);

	}
}