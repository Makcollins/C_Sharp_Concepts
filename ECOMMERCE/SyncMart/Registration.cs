using System;

namespace SyncMart;

public partial class Operations
{
    CustomerDetails currentCust = null!;
    static string custName = string.Empty;
    static string? city;
    static string? mobileNumber;
    static int walletBalance;
    static string? email;
    static string? customerID;

    bool correct = true;
    //REGISTER METHOD
    public void Register(int counter)
    {
        correct = true;
        Console.Write("User Name: ");
        custName = Console.ReadLine()!;

        Console.Write("City: ");
        city = Console.ReadLine()!;

         do
        {
            Console.Write("Mobile Number: ");
            mobileNumber = Console.ReadLine()!;

            if (mobileNumber.Length == 10)
            {
                correct = true;
                foreach (char ch in mobileNumber)
                {
                    if (!Char.IsDigit(ch))
                    {
                        Console.WriteLine("Incorrect format!");
                        correct = false;
                    }
                }
            }
            else
            {
                Console.WriteLine("Incorrect format!");
                correct = false;
            }
        } while (!correct);

        do
        {
            try
            {
                Console.Write("Wallet Balance: ");
                walletBalance = int.Parse(Console.ReadLine()!);
                correct = true;
            }
            catch (Exception)
            {
                Console.WriteLine("Incorrect Format!.");
                correct = false;
            }
        } while (!correct);

        Console.Write("Email ID: ");
        email = Console.ReadLine()!;

        customerID = "CID" + counter;

        currentCust = new CustomerDetails()
        {
            CustomerID = customerID,
            CustomerName = custName,
            City = city,
            MobileNumber = mobileNumber,
            WalletBalance = walletBalance,
            EmailID = email
        };
        customers.Add(currentCust);

        Console.WriteLine("----------------------------------------------");
        Console.WriteLine("NEW USER ID: {0}",currentCust.CustomerID);
        Console.WriteLine("----------------------------------------------");
    }

}
