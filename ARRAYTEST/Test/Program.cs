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

            Console.Write($"The values store into the array are: ");
            foreach (int num in nums)
            {
                Console.Write($"{num} ");
            }

            Console.WriteLine();

            Array.Sort(nums);
            Array.Reverse(nums);

            Console.Write($"The values store into the array in reverse are: ");
            foreach (int num in nums)
            {
                Console.Write($"{num} ");
            }
        }
    }
}