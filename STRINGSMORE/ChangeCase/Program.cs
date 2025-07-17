using System;

namespace ChangeCase
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "php";
            string lowerCaseLetters = "abcdefghijklmnopqrstuvwxyz";
            string upperCaseLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            string newS = "";

            for (int i = 0; i < s.Length; i++)
            {
                for (int j = 0; j < lowerCaseLetters.Length; j++)
                {
                    if (s[i] == lowerCaseLetters[j])
                    {
                        newS += upperCaseLetters[j];
                    }
                }
            }
            Console.WriteLine(newS);
        }
    }

}