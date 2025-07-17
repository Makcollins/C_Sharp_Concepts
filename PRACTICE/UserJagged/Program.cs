using System;

namespace UserJagged
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input number of rows");
            int rows = Convert.ToInt32(Console.ReadLine());
            int[][] jaggedArr = new int[rows][];

            for (int i = 0; i < jaggedArr.Length; i++)
            {
                Console.WriteLine("Number of elements in row {0}: ", i);
                int limit = Convert.ToInt32(Console.ReadLine());
                //size for inner arrays
                jaggedArr[i] = new int[limit];
                
                for (int j = 0; j < jaggedArr[i].Length; j++)
                {
                    Console.WriteLine("Enter elements: ");
                    jaggedArr[i][j] = Convert.ToInt32(Console.ReadLine());
                }
            }

             foreach (int[] arr in jaggedArr)
            {
                foreach (int item in arr)
                {
                    Console.Write("{0} ", item);
                }
                Console.WriteLine();
            }
        }
    }
}