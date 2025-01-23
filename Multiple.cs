public class Multiple {
	
	//The function prints all the multiple of a number num
	private static void Compute(int num) {
		for(int i=1; i<= num; i++) {
			if(num % i == 0) {
				Console.WriteLine($"{i}");
			}
		}
	}
	
	public static void Main(string[] args) {
		Console.Write("Enter a number (1 - 100): ");
        int num = int.Parse(Console.ReadLine());
		
		if(num > 100) {
			Console.WriteLine("Invalid Input");
		}
		
		Compute(num);
	}
}