//a program in C# to find the string which starts and ends with a specific character.

using System;

namespace City
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> cities = new List<string>() { "ABU DHABI", "AMSTERDAM", "ROME", "MADURAI", "LONDON", "NEW DELHI", "MUMBAI", "NAIROBI" };

            Console.Write("Input starting character for the string:");
            char startingChar = char.Parse(Console.ReadLine()!.ToUpper());

            Console.Write("Input ending character for the string:");
            char endingChar = char.Parse(Console.ReadLine()!.ToUpper());

            var selectedCities = cities.Where(city => city.StartsWith(startingChar) && city.EndsWith(endingChar));

            Console.Write($"The city starting with {startingChar} and ending with {endingChar} is: ");

            foreach (var item in selectedCities)
            {
                Console.Write(item + ", ");
            }
        }
    }
}