using System;
using System.Text;

namespace SwapIndex
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "codekata";
            string sNew = "";

            for (int i = 0; i < s.Length; i++)
            {

                if (i % 2 == 1 && i < s.Length - 1)
                {
                    sNew += s[i + 1];
                }
                else if (i % 2 == 0 && i != 0)
                {
                    sNew += s[i - 1];
                }
                else
                {
                    sNew += s[i];
                }
            }

            Console.WriteLine(sNew);
        }
    }

}