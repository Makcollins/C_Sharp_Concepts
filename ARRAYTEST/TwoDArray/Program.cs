using System;

namespace TwoDArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] arr = new int[3, 3];

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write($"element - [{i}],[{j}]: ");
                    arr[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write(arr[i, j] + " ");
                }
                Console.WriteLine();
            }

        }
    }
}