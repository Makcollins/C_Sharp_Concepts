using System;

namespace BankSystem;

public partial class Program
{

        // LOGIN
        public void Login()
        {
            bool test = true;
            do
            {
                Console.WriteLine("Please Enter your ID: ");
                string inputID = Console.ReadLine();

                Customer result = customers.Find(userID => userID.CustomerID == inputID);

                if (result == null)
                {

                    Console.WriteLine("Invalid user ID");
                }
                else
                {
                    loggedIn = result;
                    Console.WriteLine("----------------------------------------");
                    Console.WriteLine("Welcome back "+result.CustomerName);
                    Console.WriteLine("----------------------------------------");
                    do
                    {
                        Console.WriteLine("Choose operation");
                        Console.WriteLine("1. Deposit, \n2. withdraw, \n3. balance check \n4. exit");
                        int submenu = int.Parse(Console.ReadLine());

                        switch (submenu)
                        {
                            case 1:
                                loggedIn.Deposit();
                                break;
                            case 2:
                                loggedIn.Withdraw();
                                break;
                            case 3:
                                CheckBalance();
                                break;
                            case 4:
                                test = false;
                                break;
                            default:
                                Console.WriteLine("Invalid choice");
                                break;
                        }
                    } while (test);

                }
            } while (true);

        }
}
