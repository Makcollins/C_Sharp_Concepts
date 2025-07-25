using System;

public class HelloWorld
{
    public static void Main(string[] args)
    {
        int[,] arr = new int[2, 3];

        Console.WriteLine("------------------------------------");
        Console.WriteLine("INPUT");
        Console.WriteLine("------------------------------------");

        Console.WriteLine("Enter values:");
        for (int i = 0; i < arr.GetLength(0); i++)
        {
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                Console.Write("Element [{0}],[{1}] = ", i, j);
                arr[i, j] = int.Parse(Console.ReadLine()!);
            }
        }

        Console.WriteLine("\n------------------------------------");
        Console.WriteLine("OUTPUT");
        Console.WriteLine("------------------------------------");

        for (int i = 0; i < arr.GetLength(0); i++)
        {
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                Console.Write(arr[i, j] + " ");
            }
            Console.WriteLine();
        }

        //SORTING
        for (int i = 0; i < arr.GetLength(0); i++)
        {
            int[] row = new int[arr.GetLength(1)];

            for (int j = 0; j < arr.GetLength(1); j++)
            {
                row[j] = arr[i, j];
            }

            Console.WriteLine("\n------------------------------------");
            Console.WriteLine($"CREATED ROW:");
            Console.WriteLine("------------------------------------");
            foreach (int item in row)
            {
                Console.Write($"{item} ");
            }

            Array.Sort(row);

            Console.WriteLine("\n------------------------------------");
            Console.WriteLine($"MY SORTED ROW:");
            Console.WriteLine("------------------------------------");
            foreach (int item in row)
            {
                Console.Write($"{item} ");
            }

            for (int j = 0; j < arr.GetLength(1); j++)
            {
                arr[i, j] = row[j];
            }
        }

        Console.WriteLine("\n------------------------------------");
        Console.WriteLine("SORTED");
        Console.WriteLine("------------------------------------");
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