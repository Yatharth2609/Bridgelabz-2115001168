public class GreatestFactor {
	
	//The function finds the greatest factor a number num
	private static void Compute(int num) {
		for(int i = num-1; i >= 1; i--) {
			if(num % i == 0) {
				Console.Write($"The greatest factor of {num} is: {i}");
				return;
			}
		}
	}
	
	public static void Main(string[] args) {
		Console.Write("Enter a number: ");
        int num = int.Parse(Console.ReadLine());
		
		Compute(num);
	}
}