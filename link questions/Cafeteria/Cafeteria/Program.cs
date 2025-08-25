using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

namespace Cafeteria
{
    class Program
    {
        // User registration
        static void Registration(List<UserDetails> users)
        {
            bool correct = true;
            Console.WriteLine("Enter user name: ");
            string userName = Console.ReadLine()!;
            Console.WriteLine("Enter Father name: ");
            string fatherName = Console.ReadLine()!;
            string mobile;
            string mail;
            Gender gender = Gender.Transgender;
            string WorkStationNumber;

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

            Regex mailFormat = new Regex("^[a-zA-Z0-9._%+-]+@[a\\a-zA-Z._]+\\.[a-z]{2,}\\.?[a-z]*$");
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

            do
            {
                correct = true;
                Console.WriteLine("Enter Balance: ");
                if (decimal.TryParse(Console.ReadLine(), out IBalance) == false)
                {
                    Console.WriteLine("Invalid Entry");
                    correct = false;
                }
            } while (!correct);

            users.Add(new UserDetails
            {
                Name = userName,
                FatherName = fatherName,
                Mobile = mobile,
                MailID = mail,
                Gender = gender,
                WorkStationNumber = WorkStationNumber,
                balance = IBalance
            });
            Console.WriteLine("User registered successfullly, UserID is {0}", users.Last().UserID);

        }

        static void UserLogin(List<UserDetails> users, List<FoodDetails> foods, List<CartItem> cart)
        {
            // bool correct = true;
            Console.WriteLine("Welcome to Login page!\n\nEnter user ID to proceed.");
            users.ForEach(x => Console.WriteLine(x.UserID));
            Console.Write("User ID: ");
            string userInput = Console.ReadLine()!.ToUpper();

            var loggedUser = users.Find(loggedIn => loggedIn.UserID == userInput);

            if (loggedUser == null)
            {
                Console.WriteLine("Invalid UserID");
                // correct = false;
            }
            else
            {
                Console.WriteLine($"Welcome {loggedUser.Name}! Please choose an option to continue.");
                LoginMenu(loggedUser,foods,cart);
            }
        }

        static void LoginMenu(UserDetails user, List<FoodDetails> foods,List<CartItem> cart)
        {

            Console.WriteLine("a. Show My Profile\nb. Food Order\nc. Modify Order\nd. Cancel Order\ne. Order History\nf. Wallet Balance\ng.Show WalletBalance\nh. Exit");
            switch (Console.ReadLine())
            {
                case "a":
                    ShowProfile(user);
                    break;
                case "b":
                    FoodOrder(user,foods,cart);
                    break;
                case "c":
                    Console.WriteLine("c");
                    break;
                case "d":
                    Console.WriteLine("d");
                    break;
                case "e":
                    Console.WriteLine("e");
                    break;
                case "f":
                    Console.WriteLine("f");
                    break;
                case "g":
                    Console.WriteLine("g");
                    break;
                case "h":
                    return;

                default:
                    Console.WriteLine("invalid option");
                    break;
            }
        }

        static void ShowProfile(UserDetails users)
        {
            Console.WriteLine($"Name: {users.Name} {users.FatherName}\nMobile number: {users.Mobile}\nMailID: {users.MailID}\nGender: {users.Gender}\nWorkStationNumber: {users.WorkStationNumber}\nBalance: {users.WalletBalance}");
        }
        static void FoodOrder(UserDetails user, List<FoodDetails> foods, List<CartItem> cart)
        {
            string userChoice = "NO";
            //  List<FoodDetails> foods = new ListManager();
            bool correct = true;

            List<CartItem> cartItems = new List<CartItem>();
            do
            {

                Console.WriteLine($"{"FoodID",-10}{"FoodName",-10}{"Price",-10}{"AvailabityQuantity",-10}");
                foods.ForEach(item => Console.WriteLine($"{item.FoodID,-10}{item.FoodName,-10}{item.Price,-10}{item.AvailableQuantity,-10}"));
                OrderDetails order = new OrderDetails() { UserID = user.UserID, OrderDate = DateTime.Now, TotalPrice = 0, OrderStatus = OrderStatus.Initiated };



                Console.WriteLine("Please pick a product by entering FoddID and Quantity: ");
                Console.Write("FoodID: ");
                string foodID = Console.ReadLine()!.ToUpper();
                int quantity;
                do
                {
                    correct = true;
                    Console.Write("Quantity: ");
                    if (!int.TryParse(Console.ReadLine(), out quantity)) { correct = false; }

                } while (!correct);

                var productPicked = foods.Find(picked => picked.FoodID == foodID);
                if (productPicked != null)
                {
                    if (quantity > productPicked.AvailableQuantity)
                    {
                        Console.WriteLine($"Sorry, only {productPicked.AvailableQuantity} available");
                        correct = false;
                    }
                    else
                    {
                        productPicked.AvailableQuantity -= quantity;
                        order.TotalPrice = quantity * productPicked.Price;
                        CartItem wishlist = new CartItem { OrderID = order.OrderID, FoodID = productPicked.FoodID, OrderPrice = productPicked.Price, OrderQuantity = quantity };
                        cartItems.Add(wishlist);

                        do
                        {
                            Console.Write("Do you want to pick another product? \"Yes/No\"");
                            userChoice = Console.ReadLine()!.ToUpper();
                        } while (userChoice != "YES" && userChoice != "NO");
                    }
                }
            } while (userChoice == "YES");

            //confirm purchase of wish list
            do
            {
                correct = true;
                Console.Write("Proceed with purchase of the wish list? 'Yes/No'");
                userChoice = Console.ReadLine()!.ToUpper();
                if (userChoice == "NO")
                {
                    foreach (var item in foods)
                    {
                        foreach (var x in cartItems)
                        {
                            if (x.FoodID == item.FoodID)
                            {
                                item.AvailableQuantity += x.OrderQuantity;
                            }
                        }
                    }

                }
                else if (userChoice == "YES")
                {
                    AddToCart(user, cartItems, cart);
                }
                else
                {
                    Console.WriteLine("Invalid choice");
                    correct = false;
                }
            } while (!correct);

        }
//update cart items.
        static void AddToCart(UserDetails user, List<CartItem> localcart, List<CartItem> mainCart)
        {
            decimal totalPrice = localcart.Sum(x => x.OrderPrice * x.OrderQuantity);
                Console.WriteLine(totalPrice);
                Console.WriteLine(user.WalletBalance);
                if (user.WalletBalance >= totalPrice)
                {
                    user.balance -= totalPrice;
                }
                mainCart.AddRange(localcart);
                mainCart.ForEach(x=> Console.WriteLine($"{x.ItemID,-10}\t{x.FoodID,-10}\t{x.OrderID,-10}\t{x.OrderPrice,-10}\t{x.OrderQuantity,-10}"));
        }
        static void Main(string[] args)
        {
            ListManager listManager = new ListManager();
            List<UserDetails> users = listManager.InitialUsers();
            List<OrderDetails> orders = listManager.orderDetails;
            List<CartItem> cartItems = listManager.cartItemsList();
            List<FoodDetails> foods = listManager.foodsList();

            Console.WriteLine("{0}\nCAFETERIA CARD MANAGEMENT\n{0}\n", new String('-', 60));
            do
            {
                Console.WriteLine("{0}\nMAIN MENU\n{0}", new String('-', 60));
                Console.WriteLine("\n1. User Registration\n2. User Login\n3. Exit");

                int.TryParse(Console.ReadLine()!, out int choice);

                switch (choice)
                {
                    case 1:
                        Registration(users);
                        break;
                    case 2:
                        UserLogin(users, foods, cartItems);
                        break;
                    case 3:
                        return;

                    default:
                        Console.WriteLine("invalid choice");
                        break;
                }
            } while (true);

        }
    }
}