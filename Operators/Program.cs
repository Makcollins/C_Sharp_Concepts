using System;    

namespace Operators
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 5, b = 15;
            Console.WriteLine("Addition: {0}", a + b);
            Console.WriteLine("Subtraction: {0}", a - b);
            Console.WriteLine("Multiplication: {0}", a * b);
            Console.WriteLine("Division: {0}", b / a);
            Console.WriteLine("Modulus: {0}", b % a);
        }
    }
}