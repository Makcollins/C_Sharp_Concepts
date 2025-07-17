using System;

namespace Arrays;

class Program
{
    static void Main(string[] args)
    {
        int[] nums = new int[5];
        Console.WriteLine("Enter 5 integers");
        for (int n = 0; n < nums.Length; n++)
        {
            nums[n] = Convert.ToInt32(Console.ReadLine());
        }

        Console.WriteLine("Your numbers in ascending order: ");
        Array.Sort(nums);
        for (int i = 0; i < nums.Length; i++)
        {
            Console.WriteLine(nums[i]);
        }
    }  
}