public class Running {
	
	// The function calculates the number of rounds needed to cover the target distance
	private static void Rounds(int s1, int s2, int s3, int dist) {
		int peri = s1 + s2 + s3;
		
		int rounds = dist / peri;
		
		Console.WriteLine($"The total number of rounds the athlete will run is {rounds} to complete {dist} km");
	}
	
	public static void Main(string[] args) {
		Console.Write("Enter the length of side 1: ");
		int s1 = Convert.ToInt32(Console.ReadLine());
		
		Console.Write("Enter the length of side 2: ");
		int s2 = Convert.ToInt32(Console.ReadLine());
		
		Console.Write("Enter the length of side 3: ");
		int s3 = Convert.ToInt32(Console.ReadLine());
		
		Console.Write("Enter the distance to be covered: ");
		int dist = Convert.ToInt32(Console.ReadLine());
		
		Rounds(s1, s2, s3, dist);
	}
}