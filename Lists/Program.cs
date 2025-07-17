using System;
using System.Collections.Generic;
using Internal;

namespace MyList;
class Program
{
    static void Main(string[] args)
    {
        List<string> food = new List<string>();
        food.Add("Mango");
        food.Add("Apple");
        food.Add("Milk");

        foreach (string item in food)
        {
            Console.WriteLine(item);
        }

    }
}