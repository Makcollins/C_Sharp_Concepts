using System;
using System.Globalization;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime d = DateTime.Now;
            // DateTime d = new DateTime.no;

            Console.WriteLine($"Today = {d.ToString("M/d/yyyy hh:mm:ss tt")}");
            Console.WriteLine($"Today = {d.DayOfWeek}");
            Console.Write("Enter Date: ");
            string newDate = Console.ReadLine(); 

            CultureInfo culture = new CultureInfo("en-US");

            DateTime givenDate = DateTime.ParseExact(newDate,"M/d/yyyy", CultureInfo.InvariantCulture);
            DateTime dateAfterForte = givenDate.AddDays(40);
            
            Console.WriteLine(dateAfterForte.DayOfWeek);
        }
    }
}