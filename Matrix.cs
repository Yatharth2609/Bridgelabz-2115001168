using System;

class Program
{
    static void Main(string[] args)
    {
        int[][] matrix = new int[][]
        {
            new int[] {1, 4, 7, 11, 15},
            new int[] {2, 5, 8, 12, 19},
            new int[] {3, 6, 9, 16, 22},
            new int[] {10, 13, 14, 17, 24},
            new int[] {18, 21, 23, 26, 30}
        };

        int target = 5;
        Matrix solution = new Matrix();
        bool found = solution.SearchMatrix(matrix, target);
        Console.WriteLine($"Target {target} was {(found ? "found" : "not found")} in the matrix");
    }
}

public class Matrix 
{
    public bool SearchMatrix(int[][] matrix, int target) 
    {
        if (matrix == null || matrix.Length == 0 || matrix[0].Length == 0)
        {
            return false;
        }

        int rows = matrix.Length;
        int cols = matrix[0].Length;
        int left = 0;
        int right = rows * cols - 1;

        while (left <= right) 
        {
            int mid = left + (right - left) / 2;
            int row = mid / cols;
            int col = mid % cols;
            int value = matrix[row][col];

            if (value == target)
            {
                return true;
            }
            else if (value < target)
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }

        return false;
    }
}