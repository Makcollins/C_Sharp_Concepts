using System;

namespace CompareLastName
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Full name of Person 1:");
            string nameOne = Console.ReadLine();
            Console.WriteLine("Full name of Person 2:");
            string nameTwo = Console.ReadLine();

            string[] nameOneArray = nameOne.Split(' ');
            string[] nameTwoArray = nameTwo.Split(' ');

            string[] combined = { nameOneArray[nameOneArray.Length-1], nameTwoArray[nameTwoArray.Length-1] };
            Array.Sort(combined);

            if (combined[0] == nameOneArray[nameOneArray.Length-1])
            {
                Console.WriteLine($"{nameOne}\n{nameTwo}");
            }
            else
            {
                Console.WriteLine($"{nameTwo}\n{nameOne}");
            }

        }
    }

}