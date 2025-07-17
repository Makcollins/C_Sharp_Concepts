using System;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Input Array Length: ");
            int size = Convert.ToInt32(Console.ReadLine());
            Console.Write("Input K: ");
            int k = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"Input {size} number of elements in the array");

            int[] nums = new int[size];

            for (int i = 0; i < nums.Length; i++)
            {
                Console.Write($"Element - {i}: ");
                nums[i] = Convert.ToInt32(Console.ReadLine());
            }

            int index = Array.IndexOf(nums, k);
            Console.WriteLine(index);
           
        }
    }
}