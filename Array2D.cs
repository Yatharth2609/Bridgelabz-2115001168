using System;

public class Array2D {
	
	//The method is used to convert a 2D Array into a 1D Array
	private static void Compute(int[,] arr) {
		int[] temp = new int[arr.GetLength(0) * arr.GetLength(1)];
		int idx = 0;
		
		
		for(int i=0; i<arr.GetLength(0); i++) {
			for(int j=0; j<arr.GetLength(1); j++) {
				temp[idx++] = arr[i, j];
			}
		}
		
		foreach(int i in temp) {
			Console.Write(i + "  ");
		}
	}
	
	public static void Main(string[] args) {
		Console.Write("Enter the size of row: ");
		int r = Convert.ToInt32(Console.ReadLine());
		
		Console.Write("Enter the size of column: ");
		int c = Convert.ToInt32(Console.ReadLine());
		
		int[,] arr = new int[r,c];
		for(int i=0; i<arr.GetLength(0); i++) {
			for(int j=0; j<arr.GetLength(1); j++) {
				arr[i, j] = Convert.ToInt32(Console.ReadLine());
			}
		}
		
		Compute(arr);
	}
}