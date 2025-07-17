using System;

namespace OddEven
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

            int countEven = 0;
            int countOdd = 0;

            foreach (int num in nums)
            {
                if (num % 2 == 0)
                {
                    countEven++;
                }
                else
                {
                    countOdd++;
                }
            }

            int[] eveNumbers = new int[countEven];
            int[] oddNumbbers = new int[countOdd];

            int indexEven = 0;
            int indexOdd = 0;

            foreach (int num in nums)
            {
                if (num % 2 == 0)
                {
                    eveNumbers[indexEven] = num;
                    indexEven++;
                }
                else
                {
                    oddNumbbers[indexOdd] = num;
                    indexOdd++;
                }
            }

            Console.Write("The Even elements are ");
            foreach (int ev in eveNumbers)
            {
                Console.Write(ev + " ");
            }
            Console.Write("The Odd elements are ");
            foreach (int od in oddNumbbers) {
                Console.Write(od  + " ");
            }

        }
    }
}