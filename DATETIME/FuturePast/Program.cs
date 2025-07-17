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

            if (input1 < input2)
            {
                Console.WriteLine($"{input1.ToString("MM/dd/yyyy")} is in the Past");
            }
            else if (input1 > input2)
            {
                Console.WriteLine($"{input1.ToString("MM/dd/yyyy")} is in the Future");
            }
            else
            {
                Console.WriteLine($"{input1.ToString("MM/dd/yyyy")} is Today");
            }
        }
    }
}