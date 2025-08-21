//a program in C# to display the list of items in the array according to the length of the string then by name in ascending order.

using System;

namespace City
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] cities = new string[] { "ABU DHABI", "AMSTERDAM", "ROME", "PARIS","CALIFORNIA","LONDON", "NEW DELHI", "ZURICH", "NAIROBI" };

            var sortedCities = cities.OrderBy(obj => obj.Length).ThenBy(obj => obj).ToList();

            foreach (var item in sortedCities)
            {
                Console.WriteLine(item);
            }

        }
    }
}