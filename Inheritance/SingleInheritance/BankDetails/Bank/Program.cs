using System;

namespace Bank
{
    class Program
    {
        static void Main(string[] args)
        {
            //initializing class PersonalInfo objects
            PersonalInfo person1 = new PersonalInfo()
            {
                Name = "Emmanuel Juma",
                FatherName = "Owoko",
                Phone = "0723456189",
                Mail = "emmanuel@gmail.com",
                DOB = Convert.ToDateTime("15/6/1998"),
                Gender = Gender.Male
            };

            PersonalInfo person2 = new PersonalInfo()
            {
                Name = "Millicent Akoth",
                FatherName = "Otieno",
                Phone = "0112675478",
                Mail = "akothml@gmail.com",
                DOB = Convert.ToDateTime("15/6/1998"),
                Gender = Gender.Female
            };

            // Initializing class PersonalInfo objects
            AccountInfo account1 = new AccountInfo()
            {
                Name = "Emmanuel Juma",
                FatherName = "Owoko",
                Phone = "0723456189",
                Mail = "emmanuel@gmail.com",
                DOB = Convert.ToDateTime("15/6/1998"),
                Gender = Gender.Male,
                BranchName = "Kisumu west",
                IFSCCode = "252",
                Balance = 20000,
            };
            account1.Deposit(5000);
            AccountInfo account2 = new AccountInfo()
            {
                Name = "Millicent Akoth",
                FatherName = "Otieno",
                Phone = "0112675478",
                Mail = "akothml@gmail.com",
                DOB = Convert.ToDateTime("15/6/1998"),
                Gender = Gender.Female,
                BranchName = "Kisumu west",
                IFSCCode = "252",
                Balance = 20000,
            };
            account2.Withdraw(4000);

            List<PersonalInfo> persons = new List<PersonalInfo>();
            persons.Add(person1);
            persons.Add(person2);

            List<AccountInfo> accounts = new List<AccountInfo>();
            accounts.Add(account1);
            accounts.Add(account2);

            foreach (var item in persons)
            {
                Console.WriteLine($"Name: {item.Name} {item.FatherName}\nUserID: {item.UserID}\nPhone: {item.Phone}\nMailID: {item.Mail}\nDOB: {item.DOB.ToShortDateString()}\n Gender: {item.Gender}\n");
            }
            System.Console.WriteLine(new String('.', 60));

            foreach (var item in accounts)
            {
                Console.WriteLine($"Name: {item.Name} {item.FatherName}\nUserid: {item.UserID}\nPhone: {item.Phone}\nMailID: {item.Mail}\nDOB: {item.DOB.ToShortDateString()}\nGender: {item.Gender}");
                Console.WriteLine($"Account ID: {item.AccountID}\nBranch name: {item.BranchName}\nIFSC Code: {item.IFSCCode}\nBalance: {item.Balance}\n");
            }
        }
    }
}