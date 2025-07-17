using System;

namespace SeparateChar
{
    class Program
    {
        static void Main(string[] args)
        {
            string originalString = "Welcome to Syncfusion        Software   ";
            string s = originalString.Trim();

            

            int count = 1;

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == ' ' && s[i + 1] != ' ')
                {
                    count++;
                }
            }
            
            Console.WriteLine(count);

        }
    }

}