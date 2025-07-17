using System;

namespace WhileLoop;

class Program
{
    static void Main(string[] args)
    {
        string doAgain = "Y";

        do
        {
            Console.WriteLine("Which city is capital of India? ");
            Console.WriteLine("1.Chennai\n2.Delhi\n3.Mumbai\n4.Kolkata");

            Console.Write("Enter your choice:");
            int choice = Convert.ToInt32(Console.ReadLine());

            if (choice != 2)
            {
                Console.WriteLine("InCorrect !");
            }
            else
            {
                Console.WriteLine("Correct !");
            }
                Console.WriteLine("Press Y to continue, Press N to close");
                doAgain = Console.ReadLine();
        } while (doAgain.ToUpper() == "Y");
    }
}