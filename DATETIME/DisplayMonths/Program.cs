using System;
using System.Globalization;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Input Date(MM/dd/yyyy): ");
            DateTime date1 = DateTime.ParseExact(Console.ReadLine(), "M/d/yyyy", CultureInfo.InvariantCulture);

            DateTime date2 = date1.AddMonths(0);

            for (int m = 0; m < 12; m++)
            {
                date2 = date1.AddMonths(m);
                Console.WriteLine(date2.ToString("MMMM"));
            }

        }
    }
}