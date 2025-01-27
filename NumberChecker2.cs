public class NumberChecker2 {
	
	//The function is used to count number of digits in a number
	private static int countDigit(int num) {
		int res = 0;
		while(num > 0) {
			res++;
			num /= 10;
		}
		
		return res;
	}
	
	//The function is used to store all the digits of a number in an array
	private static int[] Store(int num) {
		int cnt = countDigit(num);
		
		int[] arr = new int[cnt];
		int idx = 0;
		
		while(num > 0) {
			int rem = num % 10;
			arr[idx++] = rem;
			num /= 10;
		}
		
		return arr;
	}
	
	//The function is used to sum all the squares of the digits of a number
	private static double SqSum(int[] arr) {
		double sum = 0;
		
		foreach(int i in arr) {
			sum += Math.Pow(i, 2);
		}
		
		return sum;
	}
	
	//The function is used to check wether a number is a Harshad Number
	private static bool IsHarshadNumber(int num, int[] arr) {

        int sumOfDigits = 0;
        foreach (int i in arr) {
            sumOfDigits += i;
        }

        return num % sumOfDigits == 0;
    }
	
	//The function is used to find the frequency of each digit in the number.
	private static int[,] DigitFreq(int num) {
    
		int[,] freq = new int[10, 2];

    
		for (int i = 0; i < 10; i++) {
			freq[i, 0] = i;
		}

    
		while (num > 0) {
			int digit = num % 10; 
			freq[digit, 1]++; 
			num /= 10; 
		}

		return freq;
	}	

	  
	
	public static void Main(string[] args) {
		Console.Write("Enter a number: ");
		int num = Convert.ToInt32(Console.ReadLine());
		
		int cnt = countDigit(num);
		int[] arr = Store(num);
		double sum = SqSum(arr);
		bool harshad = IsHarshadNumber(num, arr);
		int[,] freq = DigitFreq(num);
		
		Console.WriteLine($"No of Digits: {cnt}");
		Console.WriteLine($"Is {num} a Harshad Number: {harshad}");
		Console.WriteLine($"The sum of Square of the digits is: {sum}");
		
		for(int i=0; i<10; i++) {
				Console.WriteLine($"{i} -> {freq[i, 1]}");
		}
	}
}