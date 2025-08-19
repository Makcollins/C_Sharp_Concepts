using System;

namespace Banking
{
    class Program
    {
        static void Main(string[] args)
        {
            SavingAccount account1 = new SavingAccount()
            {
                Name = "Mark Oloo",
                Gen = Gender.Male,
                DOB = Convert.ToDateTime("10/5/1998"),
                Phone = "0712345678",
                Balance = 120000,
                VoterID = "ABC1002456",
                AadharID = "1100 1122 3324",
                PANNumber = "AAAPB2411C",
                BankName = "The Delhi State Cooperative Bank",
                IFSC = "DLSC0000082",
                Branch = "Alipur",
                AccountNumber = "12334556789",
                AccType = AccountType.Savings
            };

            SavingAccount account2 = new SavingAccount()
            {
                Name = "Faith Chelangat",
                Gen = Gender.Female,
                DOB = Convert.ToDateTime("18/3/1996"),
                Phone = "0754325678",
                Balance = 120000,
                VoterID = "ABC23102457",
                AadharID = "2076 1122 2231",
                PANNumber = "AAAPB2411C",
                BankName = "The Delhi State Cooperative Bank",
                IFSC = "DLSC0000024",
                Branch = "Bawana",
                AccountNumber = "12334556789",
                AccType = AccountType.Savings
            };

            List<SavingAccount> users = new List<SavingAccount>();
            users.Add(account1);
            users.Add(account2);

            Console.WriteLine("ACOUNTS:");
            Console.WriteLine(new string('.', 100));
            foreach (var item in users)
            {
                Console.WriteLine($"Name: {item.Name}\tGender: {item.Gen}\tDOB: {item.DOB.ToShortDateString}\tPhone: {item.Phone}");
                Console.WriteLine("\nID INFO");
                Console.WriteLine($"Voter ID: {item.VoterID}\tAadhar ID: {item.AadharID}\tPAN Number: {item.PANNumber}");
                Console.WriteLine("\nBANK INFO");
                Console.WriteLine($"BankName: {item.BankName}\tIFSC: {item.IFSC}\tBranch: {item.Branch}");
                Console.WriteLine($"Account Number: {item.AccountNumber}\nAccount Type: {item.AccType}");
                Console.WriteLine($"Balance: {item.Balance}");
                Console.WriteLine(new string('`', 100), "{0}\n");
            }
            bool correct = true;
            string userChoice = "";

            do
            {
                correct = true;
                Console.WriteLine("Access Account? ");
                Console.WriteLine($"1.{account1.Name}\t 2.{account2.Name}");
                string mchoice = Console.ReadLine()!;

                switch (mchoice)
                {
                    case "1":
                        userChoice = account1.Name;
                        break;
                    case "2":
                        userChoice = account2.Name;
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        correct = false;
                        break;
                }
            } while (!correct);

            Console.WriteLine($"Welcome to {userChoice}'s Account\n");
            SavingAccount currentUser = users.Find(uname => uname.Name == userChoice)!;
            Console.WriteLine("Choose an operation below");
            Console.WriteLine("1. deposit 2.Withdraw 3.Check Balance");
            string choice = Console.ReadLine()!;

            switch (choice)
            {
                case "1":
                    Console.Write("Enter Amount: ");
                    decimal amount = decimal.Parse(Console.ReadLine()!);
                    currentUser.Deposit(amount);
                    Console.WriteLine($"Successfully Deposited {amount}. Balance is {currentUser.BalanceCheck()}");
                    break;
                case "2":
                    Console.Write("Enter Amount: ");
                    amount = decimal.Parse(Console.ReadLine()!);
                    currentUser.Withdraw(amount);
                    Console.WriteLine($"Successfully Withdrawn {amount}. Balance is {currentUser.BalanceCheck()}");
                    break;
                case "3":
                    Console.WriteLine($"Balance = {currentUser.BalanceCheck()}");
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    correct = false;
                    break;
            }

        }

    }
}