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
                int[,] matrixSum = new int[size, size];

                // Matrix input
                System.Console.WriteLine("Input elements in the first matrix:");

                for (int i = 0; i < matrix1.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix1.GetLength(1); j++)
                    {
                        Console.Write($"element - [{i}],[{j}]: ");
                        matrix1[i, j] = Convert.ToInt32(Console.ReadLine());
                    }
                }
              
                //original Matrix

                Console.WriteLine("The First Matrix is:");

                for (int i = 0; i < matrix1.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix1.GetLength(1); j++)
                    {
                        Console.Write(matrix1[i, j] + " ");
                    }
                    Console.WriteLine();
                }

                //Transposed Matrix

                Console.WriteLine("The Second Matrix is:");

                for (int i = 0; i < matrix1.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix1.GetLength(1); j++)
                    {
                        Console.Write(matrix1[j, i] + " ");
                    }
                    Console.WriteLine();
                }
        }
    }
}