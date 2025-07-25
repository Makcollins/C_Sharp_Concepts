using System;
using System.Reflection.Metadata;

namespace BankSystem
{
    public partial class Program
    {
        // fields
        // register
        //login
        
        public void CheckBalance()
        {
            Console.WriteLine($"Current Balance: {loggedIn.Balance}");
        }

        //Main method
        static void Main(string[] args)
        {
            Program pg = new Program();

            bool test = true;

            do
            {
                Console.WriteLine("Choose operation");
                Console.WriteLine("1.Registration \n2.Login \n3.Exit");
                int menu = int.Parse(Console.ReadLine());

                switch (menu)
                {
                    case 1:
                        pg.Register();
                        break;
                    case 2:
                        pg.Login();
                        break;
                    case 3:
                        test = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            } while (test);

        }
    }
}