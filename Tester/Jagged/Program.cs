using System;
using System.Runtime.CompilerServices;

namespace Jagged
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] jagged = new int[3][];

            Console.WriteLine("---------------------------------");
            Console.WriteLine("INPUT");
            Console.WriteLine("---------------------------------");

            for (int i = 0; i < jagged.Length; i++)
            {
                Console.Write($"Enter Row {i} size: ");
                int rowSize = int.Parse(Console.ReadLine()!);

                jagged[i] = new int[rowSize];

                for (int j = 0; j < jagged[i].Length; j++)
                {
                    Console.Write($"Row {i} Element {j}: ");
                    jagged[i][j] = int.Parse(Console.ReadLine()!);
                }
                Console.WriteLine();
            }

            Console.WriteLine("---------------------------------");
            Console.WriteLine("OUTPUT");
            Console.WriteLine("---------------------------------");
            foreach (int[] myArray in jagged)
            {
                foreach (int item in myArray)
                {
                    Console.Write($"{item} ");
                }
                Console.WriteLine();
            }

            //SORTING
            for (int i = 0; i < jagged.Length; i++)
            {
                Array.Sort(jagged[i]);
            }

            Console.WriteLine("---------------------------------");
            Console.WriteLine("SORTED");
            Console.WriteLine("---------------------------------");
            foreach (int[] myArray in jagged)
            {
                foreach (int item in myArray)
                {
                    Console.Write($"{item} ");
                }
                Console.WriteLine();
            }
        }


    }
}