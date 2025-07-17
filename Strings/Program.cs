using System;

namespace MyStrings;

class Program
{
    static void Main(string[] args)
    {
        string txt = "Syncfusion";

        Console.WriteLine("Odd number characters");
        for (int i = 0; i < txt.Length; i += 2)
        {
            Console.Write(txt[i]);
        }
        Console.WriteLine();

        Console.WriteLine("Replace the character n with capital N");
        for (int i = 0; i < txt.Length; i++)
        {
            string txtString = txt[i].ToString();
            if (txtString == "n")
            {
                Console.Write(txtString.ToUpper());
            }
            else
            {
                Console.Write(txtString);
            }
        }
        Console.WriteLine();

        Console.WriteLine("String in reverse");
        for (int i = txt.Length - 1; i >= 0; i--)
        {
            Console.Write(txt[i]);
        }
        Console.WriteLine();

        Console.WriteLine("Length of the string:");
        Console.WriteLine(txt.Length);
        Console.WriteLine();
        Console.WriteLine("Get the two string from user and concatenate the first 4 characters of first string and last 3 characters of second string");
        Console.WriteLine();
        Console.WriteLine("Enter string one:");
        string textOne = Console.ReadLine();
        Console.WriteLine("Enter string one:");
        string textTwo = Console.ReadLine();

        string firstFour = textOne.Substring(0, 4);
        int thirdLastDigit = textTwo.Length - 3;
        string lastThree = textTwo.Substring(thirdLastDigit, 3);

        string finalString = firstFour + lastThree;

        Console.WriteLine(finalString);

    }
}