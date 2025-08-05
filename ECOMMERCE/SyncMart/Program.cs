using System;

namespace SyncMart
{
    class SyncMain
    {
        static void Main(string[] args)
        {
            Operations ops = new Operations();

            ops.AddInitialCustomers();
            ops.AddInitialProducts();
            ops.AddInitialOrders();

            bool test = true;

            int idCounter = 3003;


            do
            {
                Console.WriteLine("\n-----------------------------");
                Console.WriteLine("ONLINE COURSE ENROLLMENT");
                Console.WriteLine("-----------------------------\n");
                Console.WriteLine("Please choose an operation below.");
                int choice;
                Console.WriteLine("1. Customer Registration \n2. Login \n3. Exit");
                bool userInput = int.TryParse(Console.ReadLine(), out choice);
                Console.WriteLine("-----------------------------");

                if (userInput)
                {
                    switch (choice)
                    {
                        case 1:
                            ops.Register(idCounter);
                            idCounter++;
                            break;
                        case 2:
                            ops.Login();
                            break;
                        case 3:
                            test = false;
                            break;

                        default:
                            Console.WriteLine("Invalid Choice!");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid choice!");
                }
            } while (test);
        }
    }
}