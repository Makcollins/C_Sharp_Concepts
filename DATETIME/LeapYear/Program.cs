using System;
using System.Globalization;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Year 1: ");
            int year1 = Convert.ToInt32(Console.ReadLine());

            Console.Write("Year 2: ");
            int year2= Convert.ToInt32(Console.ReadLine());

            for (int i = year1; i <= year2; i++)
            {
                if (DateTime.IsLeapYear(i))
                {
                    Console.WriteLine(i);
                }
            }


        }
    }
}