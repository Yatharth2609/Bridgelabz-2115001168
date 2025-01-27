using System;

public class MatrixOperations
{
    // Create a random matrix
    public static double[,] CreateRandomMatrix(int rows, int cols)
    {
        Random rand = new Random();
        double[,] matrix = new double[rows, cols];
        
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                matrix[i, j] = rand.Next(-10, 11);  // Random integers between -10 and 10
            }
        }
        
        return matrix;
    }

    // Add two matrices
    public static double[,] AddMatrices(double[,] matrix1, double[,] matrix2)
    {
        int rows = matrix1.GetLength(0);
        int cols = matrix1.GetLength(1);
        double[,] result = new double[rows, cols];
        
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                result[i, j] = matrix1[i, j] + matrix2[i, j];
            }
        }
        
        return result;
    }

    // Subtract two matrices
    public static double[,] SubtractMatrices(double[,] matrix1, double[,] matrix2)
    {
        int rows = matrix1.GetLength(0);
        int cols = matrix1.GetLength(1);
        double[,] result = new double[rows, cols];
        
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                result[i, j] = matrix1[i, j] - matrix2[i, j];
            }
        }
        
        return result;
    }

    // Multiply two matrices
    public static double[,] MultiplyMatrices(double[,] matrix1, double[,] matrix2)
    {
        int rows1 = matrix1.GetLength(0);
        int cols1 = matrix1.GetLength(1);
        int cols2 = matrix2.GetLength(1);
        double[,] result = new double[rows1, cols2];
        
        for (int i = 0; i < rows1; i++)
        {
            for (int j = 0; j < cols2; j++)
            {
                double sum = 0;
                for (int k = 0; k < cols1; k++)
                {
                    sum += matrix1[i, k] * matrix2[k, j];
                }
                result[i, j] = sum;
            }
        }
        
        return result;
    }

    // Find transpose of a matrix
    public static double[,] TransposeMatrix(double[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);
        double[,] result = new double[cols, rows];
        
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                result[j, i] = matrix[i, j];
            }
        }
        
        return result;
    }

    // Find determinant of 2x2 matrix
    public static double Determinant2x2(double[,] matrix)
    {
        return matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
    }

    // Find determinant of 3x3 matrix
    public static double Determinant3x3(double[,] matrix)
    {
        double a = matrix[0, 0] * (matrix[1, 1] * matrix[2, 2] - matrix[1, 2] * matrix[2, 1]);
        double b = matrix[0, 1] * (matrix[1, 0] * matrix[2, 2] - matrix[1, 2] * matrix[2, 0]);
        double c = matrix[0, 2] * (matrix[1, 0] * matrix[2, 1] - matrix[1, 1] * matrix[2, 0]);
        
        return a - b + c;
    }

    // Find inverse of 2x2 matrix
    public static double[,] Inverse2x2(double[,] matrix)
    {
        double det = Determinant2x2(matrix);
        if (Math.Abs(det) < 1e-10)
            throw new ArgumentException("Matrix is not invertible");

        double[,] result = new double[2, 2];
        result[0, 0] = matrix[1, 1] / det;
        result[0, 1] = -matrix[0, 1] / det;
        result[1, 0] = -matrix[1, 0] / det;
        result[1, 1] = matrix[0, 0] / det;
        
        return result;
    }

    // Find inverse of 3x3 matrix
    public static double[,] Inverse3x3(double[,] matrix)
    {
        double det = Determinant3x3(matrix);
        if (Math.Abs(det) < 1e-10)
            throw new ArgumentException("Matrix is not invertible");

        double[,] cofactors = new double[3, 3];
        
        cofactors[0, 0] = matrix[1, 1] * matrix[2, 2] - matrix[1, 2] * matrix[2, 1];
        cofactors[0, 1] = -(matrix[1, 0] * matrix[2, 2] - matrix[1, 2] * matrix[2, 0]);
        cofactors[0, 2] = matrix[1, 0] * matrix[2, 1] - matrix[1, 1] * matrix[2, 0];
        cofactors[1, 0] = -(matrix[0, 1] * matrix[2, 2] - matrix[0, 2] * matrix[2, 1]);
        cofactors[1, 1] = matrix[0, 0] * matrix[2, 2] - matrix[0, 2] * matrix[2, 0];
        cofactors[1, 2] = -(matrix[0, 0] * matrix[2, 1] - matrix[0, 1] * matrix[2, 0]);
        cofactors[2, 0] = matrix[0, 1] * matrix[1, 2] - matrix[0, 2] * matrix[1, 1];
        cofactors[2, 1] = -(matrix[0, 0] * matrix[1, 2] - matrix[0, 2] * matrix[1, 0]);
        cofactors[2, 2] = matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];


        double[,] adjugate = TransposeMatrix(cofactors);


        double[,] inverse = new double[3, 3];
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                inverse[i, j] = adjugate[i, j] / det;
            }
        }
        
        return inverse;
    }

    // Display a matrix
    public static void DisplayMatrix(double[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);
        
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write($"{matrix[i, j],8:F2} ");
            }
            Console.WriteLine();
        }
    }

    static void Main(string[] args)
    {

            Console.WriteLine("2x2 Matrix Operations:");
            double[,] matrix1 = CreateRandomMatrix(2, 2);
            double[,] matrix2 = CreateRandomMatrix(2, 2);

            Console.WriteLine("\nMatrix 1:");
            DisplayMatrix(matrix1);
            Console.WriteLine("\nMatrix 2:");
            DisplayMatrix(matrix2);

            Console.WriteLine("\nAddition:");
            DisplayMatrix(AddMatrices(matrix1, matrix2));

            Console.WriteLine("\nSubtraction:");
            DisplayMatrix(SubtractMatrices(matrix1, matrix2));

            Console.WriteLine("\nMultiplication:");
            DisplayMatrix(MultiplyMatrices(matrix1, matrix2));

            Console.WriteLine("\nTranspose of Matrix 1:");
            DisplayMatrix(TransposeMatrix(matrix1));

            Console.WriteLine($"\nDeterminant of Matrix 1: {Determinant2x2(matrix1):F2}");

            Console.WriteLine("\nInverse of Matrix 1:");
            DisplayMatrix(Inverse2x2(matrix1));

            // Test with 3x3 matrices
            Console.WriteLine("\n3x3 Matrix Operations:");
            double[,] matrix3 = CreateRandomMatrix(3, 3);
            double[,] matrix4 = CreateRandomMatrix(3, 3);

            Console.WriteLine("\nMatrix 3:");
            DisplayMatrix(matrix3);
            Console.WriteLine("\nMatrix 4:");
            DisplayMatrix(matrix4);

            Console.WriteLine($"\nDeterminant of Matrix 3: {Determinant3x3(matrix3):F2}");

            Console.WriteLine("\nInverse of Matrix 3:");
            DisplayMatrix(Inverse3x3(matrix3));
        
    }
}