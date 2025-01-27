public class FootballTeam {
	public static void Main(string[] args) {
		int[] arr = new int[11];
		Console.Write("Enter the heights of the football players: ");
		for(int i=0; i<arr.Length; i++) {
			arr[i] = Convert.ToInt32(Console.ReadLine());
		}
		
		int sum = Sum(arr);
		double mean = MeanHeight(arr);
		int shortest = ShortesHeigth(arr);
		int longest = LongestHeight(arr);
		
		Console.WriteLine($"The Mean Height is: {Math.Round(mean, 2)}");
		Console.WriteLine($"The Shortest Height is: {shortest}");
		Console.WriteLine($"The Longest Height is: {longest}");
	}
	
	//The method is used to find sum of all the elements in an array
	private static int Sum(int[] arr) {
		int sum = 0;
		foreach(int i in arr) {
			sum += i;
		}
		
		return sum;
	}
	
	//The method is used to find the mean height of the football team
	private static double MeanHeight(int[] arr) {
		int sum = Sum(arr);
		
		return (double)(sum / arr.Length);
	}
	
	
	//The method is used to find the shortest height of the player in the team
	private static int ShortesHeigth(int[] arr) {
		int res = int.MaxValue;
		
		foreach(int i in arr) {
			if(i <= res) {
				res = i;
			}
		} 
		
		return res;
	}
	
	//The method is used to find the longest height of the player in the team
	private static int LongestHeight(int[] arr) {
		int res = int.MinValue;
		
		foreach(int i in arr) {
			if(i >= res) {
				res = i;
			}
		} 
		
		return res;
	}
	
}