using System;
using System.Security.Authentication;
using System.Text.RegularExpressions;

namespace MedicalStore;

public class RegistrationManager
{
    static ListManager listManager = new ListManager();
    PurchaseManager purchaseManager = new PurchaseManager();

    List<UserDetails> usersList = listManager.UsersList();
    List<MedicineDetails> medicinesList = listManager.MedicinesList();
    
    public void Registration()
    {
        //Input Username
        Console.Write("Enter UserName : ");
        string userName = Console.ReadLine()!;

        //Input Age
        int age;
        bool correct;
        do
        {
            Console.Write("Enter age : ");
            correct = int.TryParse(Console.ReadLine(), out age);
            if (!correct)
                Console.WriteLine("Invalid Entry!\n");
        } while (!correct);

        //Input City
        Console.Write("Enter City Name: ");
        string city = Console.ReadLine()!;

        //Input Phone Number
        string phoneNumber;
        Regex phoneNumberFormat = new Regex("^\\+?\\d{1,4}?[-.\\s]?\\(?\\d{1,3}?\\)?[-.\\s]?\\d{1,4}[-.\\s]?\\d{1,4}$");

        do
        {
            Console.Write("Enter mobile number : ");
            phoneNumber = Console.ReadLine()!;

            correct = phoneNumberFormat.IsMatch(phoneNumber);
            if (!correct)
            {
                Console.WriteLine("Invalid mobile number!\n");
            }
        } while (!correct);

        //Input initial Balance
        decimal balance;
        do
        {
            Console.Write("Enter Balance: ");
            correct = decimal.TryParse(Console.ReadLine(), out balance);
            if (!correct)
                Console.WriteLine("Invalid Entry!\n");
        } while (!correct);

        UserDetails newUser = new() { Name = userName, Age = age, City = city, PhoneNumber = phoneNumber};
        newUser.WalletRecharge(balance);
        usersList.Add(newUser);
        // new ListManager().DisplayList(usersList);
        Console.WriteLine("\nUser registered successfullly, UserID is {0}\n", usersList.Last().UserID);

        listManager.DisplayList(usersList);
    }

    public void Login()
    {
        Console.WriteLine("Welcome to Login page!\n\nEnter user ID to proceed.");

        Console.Write("User ID: ");

        string userInput = Console.ReadLine()!.ToUpper();

        var loggedUser = usersList.Find(loggedIn => loggedIn.UserID == userInput);

        if (loggedUser == null)
        {
            Console.WriteLine("Invalid UserID\n");
            // correct = false;
        }
        else
        {
            Console.WriteLine($"\nWelcome {loggedUser.Name}!");
            LoginMenu(loggedUser);
        }
    }

    public void LoginMenu(UserDetails user)
    {
        do
        {
            Console.WriteLine(
            @"Please choose an option to continue.
                a. Show medicine list.
                b. Purchase medicine.
                c. Modify purchase.
                d. Cancel purchase.
                e. Show purchase history.
                f. Recharge Wallet.
                g. Show Wallet Balance
                h. Exit");
                
            switch (Console.ReadLine())
            {
                case "a":
                    listManager.DisplayList(medicinesList);
                    break;
                case "b":
                    listManager.DisplayList(medicinesList);
                    purchaseManager.PurchaseMedicine(user, medicinesList);
                    break;
                case "c":
                    purchaseManager.ModifyPurchase(user, medicinesList);
                    break;
                case "d":
                    purchaseManager.CancelPurchase(user, medicinesList);
                    break;
                case "e":
                    purchaseManager.PurchaseHistory(user);
                    break;
                case "f":
                    purchaseManager.RechargeWallet(user);
                    break;
                case "g":
                    Console.WriteLine($"User Balance : {user.WalletBalance}");
                    break;
                case "h":
                    return;

                default:
                    Console.WriteLine("invalid option");
                    break;
            }
        } while (true);
    }
}
