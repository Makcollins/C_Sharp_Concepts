using System;

namespace StringsMore
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "abc";

            int sum = 0;

            foreach (char ch in s)
            {
                int ch_ascii = (int)ch;
                sum += ch_ascii;
            }

            Console.WriteLine(sum);
        }
    }

}