using System;

namespace Arrays;

class Program
{
    static void Main(string[] args)
    {
        int[] nums = new int[10];
        Console.WriteLine("Enter 10 integers");
        for (int n = 0; n < nums.Length; n++)
        {
            nums[n] = Convert.ToInt32(Console.ReadLine());
        }

        int countEven = 0, countOdd = 0;

        Array.Sort(nums);
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] % 2 == 0)
            {
                countEven++;
            }
            else
            {
                countOdd++;
            }
        }

        int[] evenNums = new int[countEven];
        int[] oddNums = new int[countOdd];
        int k = 0;
        int kOdd = 0;

        for (int n = 0; n < nums.Length; n++)
        {
            if (nums[n] % 2 == 0)
            {
                evenNums[k] = nums[n];
                k++;
            }
            else
            {
                oddNums[kOdd] = nums[n];
                kOdd++;
            }
        }
        Console.WriteLine();
        Console.WriteLine("Even Numbers:");
        Console.WriteLine();

        foreach (int evens in evenNums)
        {
            Console.WriteLine(evens);
        }
        Console.WriteLine("Odd Numbers:");
        Console.WriteLine();
        for (int odd = oddNums.Length - 1; odd > 0; odd--)
        {
            Console.WriteLine(oddNums[odd]);
        }
        
    }  
}