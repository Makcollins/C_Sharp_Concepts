using System;

namespace SeparateChar
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter First String:");
            string stringOne = Console.ReadLine();
            Console.WriteLine("Enter Second String:");
            string stringTwo = Console.ReadLine();

            bool status = (stringOne == stringTwo) ? true : false;     

            Console.WriteLine(status);
        }
    }

}