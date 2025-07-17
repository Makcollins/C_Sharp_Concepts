using System;

namespace StringsLength
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "Syncfusion";

            int length = 0;

            foreach (char ch in s)
            {
                length++;
            }

            Console.WriteLine(length);
        }
    }

}