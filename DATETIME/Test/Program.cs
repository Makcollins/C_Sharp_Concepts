using System;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime d = DateTime.Now;

            Console.WriteLine($"year = {d.Year}");
            Console.WriteLine($"month = {d.Month}");
            Console.WriteLine($"day = {d.Day}");
            Console.WriteLine($"hour = {d.Hour}");
            Console.WriteLine($"minute = {d.Minute}");
            Console.WriteLine($"second = {d.Second}");
            Console.WriteLine($"millisecond = {d.Millisecond}");
        }
    }
}