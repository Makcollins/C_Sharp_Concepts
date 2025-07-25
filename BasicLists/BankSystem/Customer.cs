using System;

namespace BankSystem;

enum Gender
{
    Male,
    Female
}
public class Customer
{
    public string CustomerID
    {
        get; set;
    }

    public string CustomerName
    {
        get; set;
    }

    public double Balance
    {
        get; set;
    }

    public string CustomerGender
    {
        get; set;
    }

    public string Phone
    {
        get; set;
    }

    public string MailID
    {
        get; set;
    }

    public DateTime DOB
    {
        get; set;
    }
    //DEPOSIT
    public void Deposit()
    {
        System.Console.WriteLine("User Balance:", Balance);
        Console.Write("Enter Deposit Amount: ");
        double amount = double.Parse(Console.ReadLine());
        Balance += amount;
        Console.WriteLine($"Your balance is:{Balance}");

        // return amount;
    }
    //WITHDRAW
    public void Withdraw()
    {
        bool test = false;
        Console.Write("Enter Amount to Withdraw: ");
        double amount = double.Parse(Console.ReadLine());

        if (amount > Balance)
        {
            Console.WriteLine("----------------------------");
            Console.WriteLine("Sorry, you do not have enough balance to withdraw the amount. \nPlease try a different amount.");
            test = false;
        }
        else
        {
            Balance = Balance - amount;
            Console.WriteLine("----------------------------");
            Console.WriteLine($"Hi {CustomerName}, \nYou have sucessfully Withdrawn {amount}. Account balance = {Balance}");
            Console.WriteLine("----------------------------");
        }
    }

}