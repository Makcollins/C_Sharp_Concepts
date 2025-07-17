using System;

namespace Iteration;

class Program
{
    static void Main(string[] args)
    {
        int[] nums = new int[10];
        Console.WriteLine("Enter 10 numbers");
        for (int n = 0; n <nums.Length; n++)
        {
            nums[n] = Convert.ToInt32(Console.ReadLine());
        }

        int sum = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            sum += i;
        }

        Console.WriteLine("The sum of 10 numbers is: {0}", sum);
        Console.WriteLine("The average is: {0}", sum/nums.Length);
   }
}