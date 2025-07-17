using System;

namespace SumMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = 0;
            do
            {
                Console.Write("Input the size of the square matrix (less than 5):");
                size = Convert.ToInt32(Console.ReadLine());
            } while (size > 5);

                int[,] matrix1 = new int[size, size];
                int[,] matrix2 = new int[size, size];
                int[,] matrixSum = new int[size, size];

                // First Matrix input
                System.Console.WriteLine("Input elements in the first matrix:");

                for (int i = 0; i < matrix1.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix1.GetLength(1); j++)
                    {
                        Console.Write($"element - [{i}],[{j}]: ");
                        matrix1[i, j] = Convert.ToInt32(Console.ReadLine());
                    }
                }

                // Second Matrix input

                Console.WriteLine("Input elements in the second matrix:");

                for (int i = 0; i < matrix2.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix2.GetLength(1); j++)
                    {
                        Console.Write($"element - [{i}],[{j}]: ");
                        matrix2[i, j] = Convert.ToInt32(Console.ReadLine());
                    }
                }

                // Sum matrix

                for (int i = 0; i < matrixSum.GetLength(0); i++)
                {
                    for (int j = 0; j < matrixSum.GetLength(1); j++)
                    {
                        matrixSum[i, j] = matrix1[i, j] + matrix2[i, j];
                    }
                }

                //Display Matrix 1

                Console.WriteLine("The First Matrix is:");

                for (int i = 0; i < matrix1.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix1.GetLength(1); j++)
                    {
                        Console.Write(matrix1[i, j] + " ");
                    }
                    Console.WriteLine();
                }

                //Display Matrix 2

                Console.WriteLine("The Second Matrix is:");

                for (int i = 0; i < matrix2.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix2.GetLength(1); j++)
                    {
                        Console.Write(matrix2[i, j] + " ");
                    }
                    Console.WriteLine();
                }

                //Display Sum Matrix

                Console.WriteLine("The Addition of two matrix is:");

                for (int i = 0; i < matrixSum.GetLength(0); i++)
                {
                    for (int j = 0; j < matrixSum.GetLength(1); j++)
                    {
                        Console.Write(matrixSum[i, j] + " ");
                    }
                    Console.WriteLine();
                }
        }
    }
}