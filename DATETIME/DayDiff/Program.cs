using System;
using System.Globalization;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Date 1: ");
            DateTime input1 = DateTime.ParseExact(Console.ReadLine(), "M/d/yyyy", CultureInfo.InvariantCulture);

            Console.Write("Date 2: ");
            DateTime input2 = DateTime.ParseExact(Console.ReadLine(), "M/d/yyyy", CultureInfo.InvariantCulture);

            TimeSpan interval = input2.Subtract(input1);

            System.Console.WriteLine($"The difference in the date is {interval.TotalDays} days");
        }
    }
}