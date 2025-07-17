using System;

namespace TwoDArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] arr = new int[3, 4] {
                { 10,55,30,40},
                { 50,60,70,30},
                { 80,90,45,76}
            };

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                int[] row = new int[arr.GetLength(1)];

                // Copy row to 1D array.
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    row[j] = arr[i, j];
                }

                Array.Sort(row);

                // copy back items to 1D array
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    arr[i, j] = row[j];
                }


                
            }
            
            // display the sorted 2D array

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