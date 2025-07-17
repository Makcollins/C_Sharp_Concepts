using System;
using System.Globalization;

namespace PassingArray
{
    class Program
    {
        public int Sum(int[] arr, int size) {
            int sum = 0;

            for (int i = 0; i < size; i++)
            {
                sum += arr[i];
            }

            return sum;

        }

        static void PrintNums(params int[] nums)
        {
            foreach (int num in nums)
            {
                Console.Write(num + " ");
            }
        }
        static void Main(string[] args)
        {
            Program p = new Program();
            int[] nums = { 29, 24, 54, 65, 75 };
            int s = nums.Length;

            Console.WriteLine(p.Sum(nums, s));
        }
    }
}