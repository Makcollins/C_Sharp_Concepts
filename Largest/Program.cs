using System;

namespace Largest
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = 10;
            int num2 = 20;
            int num3 = 30;
            int largest = num1;

            if (num2 > largest)
                largest = num2;
            if (num3 > largest)
                largest = num3;

            Console.WriteLine("The largest number is: " + largest);
        }
    }
}