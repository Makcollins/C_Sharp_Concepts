using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Cafeteria;

public class AuthenticationManager
{
    OrderManager orderManager = new();
    public static List<UserDetails> users = ListManager.ReadUsersFromCSV();
    
    public async Task Registration()
    {
        users.ForEach(x=>Console.WriteLine($"{x.UserID} {x.Name}"));
        bool correct = true;
        //input name
        Console.WriteLine("Enter user name: ");
        string userName = Console.ReadLine()!;

        //input father name
        Console.WriteLine("Enter Father name: ");
        string fatherName = Console.ReadLine()!;

        string mobile;
        string mail;
        Gender gender = Gender.Transgender;
        string WorkStationNumber;

        //vaalidate phone number
        Regex mobileFormat = new Regex("^\\+?\\d{1,4}?[-.\\s]?\\(?\\d{1,3}?\\)?[-.\\s]?\\d{1,4}[-.\\s]?\\d{1,4}$");
        do
        {
            correct = true;
            Console.WriteLine("Enter mobile number: ");
            mobile = Console.ReadLine()!;
            if (!mobileFormat.IsMatch(mobile))
            {
                Console.WriteLine("Invalid mobile number!");
                correct = false;
            }
        } while (!correct);

        //validate mail
        Regex mailFormat = new Regex("^[a-zA-Z0-9._%+-]+@[a\\a-zA-Z._]+\\.[a-z]{2,}(\\.?[a-z]*$)");
        // Regex mailFormat = new Regex(@"^[a-zA-Z]+[a-zA-Z0-9._-]@^[a-zA-Z{3,}]+\.[a-zA-Z]{2,}\.?[a-zA-Z]*$");
        do
        {
            correct = true;
            Console.WriteLine("Enter Mail ID: ");
            mail = Console.ReadLine()!;
            if (!mailFormat.IsMatch(mail))
            {
                Console.WriteLine("Invalid Mail ID!");
                correct = false;
            }
        } while (!correct);

        //input gmail
        do
        {
            correct = true;
            Console.WriteLine("Enter Gender: ");
            try
            {
                gender = Enum.Parse<Gender>(Console.ReadLine()!);
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid Syntax");
                correct = false;
            }
        } while (!correct);

        //workstation number
        Regex workStationNumberFormat = new Regex("^WS\\d{3}$");
        do
        {
            correct = true;
            Console.WriteLine("Enter WorkStationNumber. (Format: \"WS101\")");
            WorkStationNumber = Console.ReadLine()!.Trim().ToUpper();
            if (!workStationNumberFormat.IsMatch(WorkStationNumber))
            {
                Console.WriteLine("Invalid format!");
                correct = false;
            }
            ;
        } while (!correct);

        decimal IBalance;
        //input initial balance
        do
        {
            Console.WriteLine("Enter Balance: ");
            correct = decimal.TryParse(Console.ReadLine(), out IBalance);
            if (!correct || IBalance < 1)
            {
                Console.WriteLine("Invalid Entry");
            }
        } while (!correct || IBalance < 1);

        //add new user object to list
        var registeredUser = new UserDetails { Name = userName, FatherName = fatherName, Mobile = mobile, MailID = mail, Gender = gender, WorkStationNumber = WorkStationNumber, balance = IBalance };
        users.Add(registeredUser);
        await ListManager.AppendNewToCSV(registeredUser);
        Console.WriteLine("User registered successfullly, UserID is {0}", users.Last().UserID);

    }

    //Login Method
    public void UserLogin()
    {
        Console.WriteLine("Welcome to Login page!\n\nEnter user ID to proceed.");

        Console.Write("User ID: ");

        string userInput = Console.ReadLine()!.ToUpper();

        var loggedUser = users.Find(loggedIn => loggedIn.UserID == userInput);

        if (loggedUser == null)
        {
            Console.WriteLine("Invalid UserID");
        }
        else
        {
            Console.WriteLine($"Welcome {loggedUser.Name}! Please choose an option to continue.");
            LoginMenu(loggedUser);
        }
    }

    //Login Menu
    public void LoginMenu(UserDetails user)
    {

        do
        {
            Console.WriteLine("a. Show My Profile\nb. Food Order\nc. Modify Order\nd. Cancel Order\ne. Order History\nf. Wallet Recharge \ng.Show WalletBalance\nh. Exit\n");
            switch (Console.ReadLine())
            {
                case "a":
                    ShowProfile(user);
                    break;
                case "b":
                    orderManager.FoodOrder(user);
                    break;
                case "c":
                    orderManager.ModifyOrder(user);
                    break;
                case "d":
                    orderManager.CancelOrder(user);
                    break;
                case "e":
                    orderManager.OrderHistory(user);
                    break;
                case "f":
                    orderManager.RechargeWallet(user);
                    break;
                case "g":
                    Console.WriteLine($"Wallet Balance: {user.WalletBalance}");
                    break;
                case "h":
                    return;

                default:
                    Console.WriteLine("invalid option");
                    break;
            }
        } while (true);
    }

    //display user profile
    public void ShowProfile(UserDetails users)
    {
        Console.WriteLine($"Name: {users.Name} {users.FatherName}\nMobile number: {users.Mobile}\nMailID: {users.MailID}\nGender: {users.Gender}\nWorkStationNumber: {users.WorkStationNumber}\nBalance: {users.WalletBalance}");
    }
}
