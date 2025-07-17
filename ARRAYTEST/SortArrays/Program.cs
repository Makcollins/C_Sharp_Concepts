using System;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Input the number of elements to store in the array: ");
            int size = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"Input {size} number of elements in the array");

            int[] nums = new int[size];

            for (int i = 0; i < nums.Length; i++)
            {
                Console.Write($"Element - {i}: ");
                nums[i] = Convert.ToInt32(Console.ReadLine());
            }

            Array.Sort(nums);

            Console.Write("Elements of array in sorted ascending order: ");
            foreach (int num in nums)
            {
                Console.Write(num + " ");
            }

        }
    }
}