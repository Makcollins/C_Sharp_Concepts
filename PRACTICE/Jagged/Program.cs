using System;

namespace Jagged
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] jaggedArr = new int[][] {
                new int[] {1,2,3},
                new int[] {4,5},
                new int[] {6,7,8,9}
            };

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