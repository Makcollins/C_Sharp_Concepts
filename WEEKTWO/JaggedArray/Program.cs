using System;
using Microsoft.VisualBasic;

namespace JaggedArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] scores = new int[][] {
                new int[] {32,12,32},
                new int[] {54,21,83},
                new int[] {11,55,33},
                new int[] {34,42,55}
            };
            // Using for Loop
            for (int i = 0; i < scores.Length; i++)
            {
                for (int j = 0; j < scores[i].Length; j++)
                {
                    Console.Write("{0} ", scores[i][j]);
                }
                Console.WriteLine();
            }

            Console.WriteLine("USING FOREACH LOOP");
            // using foreach loop

            foreach (int[] arr in scores)
            {
                foreach (int mark in arr)
                {
                    Console.Write("{0} ", mark);
                }
                Console.WriteLine();
            }
        }

    }
}