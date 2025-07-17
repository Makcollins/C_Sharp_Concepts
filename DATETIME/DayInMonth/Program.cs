using System;
using System.Globalization;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Month: ");
            int myMonth = Convert.ToInt32(Console.ReadLine());

            Console.Write("Year: ");
            int myYear = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine(DateTime.DaysInMonth(myYear, myMonth));

            // DateTime d = new DateTime(myYear, myMonth, 1);

            // DateTime d2 = new DateTime();
            // if (myMonth < 12)
            // {
            //     d2 = new DateTime(myYear, myMonth + 1, 1);
            // }
            // else
            // {
            //     d2 = new DateTime(myYear + 1, 1, 1);
            // }

            // TimeSpan interval = d2 - d;

            // Console.WriteLine(interval.Days);


        }
    }
}