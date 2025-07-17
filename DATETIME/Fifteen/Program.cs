using System;
using System.Globalization;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Enter Date: ");
            string newDate = Console.ReadLine(); 

            DateTime givenDate = DateTime.ParseExact(newDate,"M/d/yyyy", CultureInfo.InvariantCulture);
            DateTime beforeBy15 = givenDate.AddYears(-15);
            DateTime afterBy15 = givenDate.AddYears(15);
            
            Console.WriteLine($"15 years before date is: {beforeBy15.ToString("MM/dd/yyyy")} \n 15 years after date is: {afterBy15.ToString("MM/dd/yyyy")}");
        }
    }
}