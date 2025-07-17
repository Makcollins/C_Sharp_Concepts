using System;

namespace VowelConsonants
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "Welcome to Syncfusion Software";
            string strLower = str.ToLower();

            string vowels = "aeiou";
            string consonants = "bcdfghjklmnpqrstvwxyz";

            string onlyVowels = "";
            string onlyConsonants = "";

            for (int i = 0; i < strLower.Length; i++)
            {
                for (int j = 0; j < vowels.Length; j++)
                {
                    if (strLower[i] == vowels[j])
                    {
                        onlyVowels += str[i];
                    }
                }
                for (int j = 0; j < consonants.Length; j++)
                {
                    if (strLower[i] == consonants[j])
                    {
                        onlyConsonants += str[i];
                    }
                }
            }
            Console.WriteLine($"Total number of vowels: {onlyVowels.Length}");
            Console.WriteLine($"Total number of consonants: {onlyConsonants.Length}");

        }
    }

}