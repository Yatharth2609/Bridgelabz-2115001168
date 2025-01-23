public class LeapYear {
	
	private static void Compute(int year) {
		if ((year % 4 == 0 && year % 100 != 0) || year % 400 == 0)
        {
            Console.WriteLine($"{year} is a leap year.");
        }
        else
        {
            Console.WriteLine($"{year} is not a leap year.");
        }
	}
	
	public static void Main(string[] args) {
		Console.Write($"Enter a Year: ");
		int year = Convert.ToInt32(Console.ReadLine());
		
		Compute(year);
	}
}