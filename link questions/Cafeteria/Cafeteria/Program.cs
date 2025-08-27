using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

namespace Cafeteria
{
    class Program
    {
        static int symbolLength = 60;
        static bool correct = true;
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

        static void UserLogin(List<UserDetails> users, List<FoodDetails> foods, List<CartItem> cart, List<OrderDetails> orders)
        {
            // bool correct = true;
            Console.WriteLine("Welcome to Login page!\n\nEnter user ID to proceed.");

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
                LoginMenu(loggedUser, foods, cart, orders);
            }
        }

        static void LoginMenu(UserDetails user, List<FoodDetails> foods, List<CartItem> cart, List<OrderDetails> orders)
        {

            Console.WriteLine("a. Show My Profile\nb. Food Order\nc. Modify Order\nd. Cancel Order\ne. Order History\nf. Wallet Balance\ng.Show WalletBalance\nh. Exit");
            switch (Console.ReadLine())
            {
                case "a":
                    ShowProfile(user);
                    break;
                case "b":
                    FoodOrder(user, foods, cart, orders);
                    break;
                case "c":
                    ModifyOrder(user, orders,cart,foods);
                    break;
                case "d":
                    CancelOrder(user,orders,foods,cart);
                    break;
                case "e":
                    OrderHistory(user,orders);
                    break;
                case "f":
                    UpdateWallet(user);
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
        }

        static void ShowProfile(UserDetails users)
        {
            Console.WriteLine($"Name: {users.Name} {users.FatherName}\nMobile number: {users.Mobile}\nMailID: {users.MailID}\nGender: {users.Gender}\nWorkStationNumber: {users.WorkStationNumber}\nBalance: {users.WalletBalance}");
        }
        static void FoodOrder(UserDetails user, List<FoodDetails> foods, List<CartItem> cart, List<OrderDetails> orders)

        {
            string userChoice = "NO";
          
            bool correct = true;
            OrderDetails order;

            List<CartItem> cartItems = new List<CartItem>();
            do
            {

                Console.WriteLine($"{"FoodID",-10}{"FoodName",-10}{"Price",-10}{"AvailabityQuantity",-10}");
                foods.ForEach(item => Console.WriteLine($"{item.FoodID,-10}{item.FoodName,-10}{item.Price,-10}{item.AvailableQuantity,-10}"));
                order = new OrderDetails() { UserID = user.UserID, OrderDate = DateTime.Now, TotalPrice = 0, OrderStatus = OrderStatus.Initiated };

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
                        CartItem wishlist = new CartItem { OrderID = order.OrderID, FoodID = productPicked.FoodID, OrderPrice = productPicked.Price, OrderQuantity = quantity };
                        cartItems.Add(wishlist);

                        do
                        {
                            Console.Write("Do you want to pick another product? \"Yes/No\" : ");
                            userChoice = Console.ReadLine()!.ToUpper();
                        } while (userChoice != "YES" && userChoice != "NO");
                    }
                }
            } while (userChoice == "YES");

            //confirm purchase of wish list
            do
            {
                Console.Write("Proceed with purchase of the wish list? 'Yes/No' : ");
                userChoice = Console.ReadLine()!.ToUpper();
                if (userChoice == "NO")
                {
                    ReturnItemsToFoodList(foods, cartItems);

                }
                else if (userChoice == "YES")
                {
                    //update the main Cart | update user balance 
                    AddToCart(user, cartItems,foods, cart, order, orders);

                }
            } while (userChoice != "YES" && userChoice != "NO");

        }

        static void ModifyOrder(UserDetails user, List<OrderDetails> orders, List<CartItem> cartItems, List<FoodDetails> foods)
        {
            var activeOrders = orders.Where(x => x.UserID == user.UserID && x.OrderStatus == OrderStatus.Ordered).ToList();

            Console.WriteLine($"{"\nOrderID",-10}{"OrderDate",-10}{"TotalPrice",-10}\n{new String('-', 35)}");
            activeOrders.ForEach(item => Console.WriteLine($"{item.OrderID,-10}{item.OrderDate.ToShortDateString(),-15}{item.TotalPrice,-10}\n"));

            Console.WriteLine($"{"ItemID",-10}{"OrderID",-10}{"FoodID",-10}{"OrderPrice",-12}{"OrderQuantity",-10}\n{new String('-', symbolLength)}");
            cartItems.ForEach(x => Console.WriteLine($"{x.ItemID,-10}{x.OrderID,-10}{x.FoodID,-10}{x.OrderPrice,-12}{x.OrderQuantity,-10}\n"));

            Console.Write("Emter item ID:");
            string userInput = Console.ReadLine()!.ToUpper();

            var selectedItem = cartItems.Find(selected => selected.ItemID == userInput);

            if (selectedItem == null)
            {
                Console.WriteLine("Item does not exist");
            }
            else
            {
                int quantity;
                do
                {
                    correct = true;
                    Console.Write("Quantity: ");
                    if (!int.TryParse(Console.ReadLine(), out quantity)) { Console.WriteLine("Invalid entry!"); correct = false; }

                } while (!correct);

                var selectedFood = foods.Find(food => food.FoodID == selectedItem.FoodID);
                var selectedOrder = activeOrders.Find(order => order.OrderID == selectedItem.OrderID);

                selectedItem.OrderPrice = quantity * selectedFood!.Price;
                selectedItem.OrderQuantity = quantity;

                selectedOrder!.TotalPrice = cartItems.Where(x => x.OrderID == selectedOrder.OrderID).Sum(x => x.OrderPrice);

                Console.WriteLine("Order Modified successfully");

            }
        }
        
        static void ReturnItemsToFoodList(List<FoodDetails> foods, List<CartItem> localCartItems)
        {
            foreach (var item in foods)
            {
                foreach (var x in localCartItems)
                {
                    if (x.FoodID == item.FoodID)
                    {
                        item.AvailableQuantity += x.OrderQuantity;
                    }
                }
            }
        }

        static void CancelOrder(UserDetails user, List<OrderDetails> orders, List<FoodDetails> foods, List<CartItem> cart)
        {
            var activeOrders = orders.Where(x => x.UserID == user.UserID && x.OrderStatus == OrderStatus.Ordered).ToList();

            Console.WriteLine($"{"\nOrderID",-10}{"OrderDate",-10}{"TotalPrice",-10}\n{new String('-', 35)}");
            activeOrders.ForEach(item => Console.WriteLine($"{item.OrderID,-10}{item.OrderDate.ToShortDateString(),-15}{item.TotalPrice,-10}\n"));
            
            Console.Write("Emter Order ID:");
            string userInput = Console.ReadLine()!.ToUpper();

            var selectedOrder = orders.Find(selected => selected.OrderID == userInput);

            if (selectedOrder == null)
            {
                Console.WriteLine("Invalid OrderID");
            }
            else
            {
                user.WalletRecharge(selectedOrder.TotalPrice);
                var filteredCart = cart.Where(x => x.OrderID == selectedOrder.OrderID).ToList();

                ReturnItemsToFoodList(foods, filteredCart);

                selectedOrder.OrderStatus = OrderStatus.Cancelled;

                Console.WriteLine("Order cancelled successfully");     

            }
        }

        static void OrderHistory(UserDetails user, List<OrderDetails> orders)
        {
            Console.WriteLine($"{"\nOrderID",-10}{"OrderDate",-10}{"TotalPrice",-10}{"OrderStatus",-10}\n{new String('-', symbolLength)}");
            orders.Where(order => order.UserID == user.UserID).ToList()
            .ForEach(item => Console.WriteLine($"{item.OrderID,-10}{item.OrderDate.ToShortDateString(),-15}{item.TotalPrice,-10}{item.OrderStatus,-10}\n"));
        }

        //update cart items.
        static void UpdateWallet(UserDetails user)
        {
            int amount;
            do
            {
                Console.WriteLine("Enter amount: ");
            } while (!int.TryParse(Console.ReadLine(), out amount));
            user.WalletRecharge(amount);
            
        }
        static void AddToCart(UserDetails user, List<CartItem> localCart, List<FoodDetails> foods, List<CartItem> mainCart, OrderDetails order, List<OrderDetails> orders)
        {
            decimal totalPrice = localCart.Sum(x => x.OrderPrice * x.OrderQuantity);

            if (user.WalletBalance >= totalPrice)
            {
                user.DeductAmount(totalPrice);
                mainCart.AddRange(localCart);
                order.OrderStatus = OrderStatus.Ordered;
                order.TotalPrice = totalPrice;
                orders.Add(order);
                Console.WriteLine($"Order placed successfully, and OrderID is {orders.Select(x => x.OrderID).Last()}");
            }
            else
            {
                RechargeWallet(user, foods, localCart, mainCart, order, orders);
            }

        }
        static void RechargeWallet(UserDetails user,List<FoodDetails> foods, List<CartItem> localCartItems, List<CartItem> cart, OrderDetails order, List<OrderDetails> orders)
        {
            string userInput;
            do
            {
                Console.WriteLine("Insufficient balance to purchase! Are you willing to recharge? 'Yes/No' : ");
                userInput = Console.ReadLine()!.ToUpper();
                if (userInput == "NO")
                {
                    Console.WriteLine("exiting without order due to insufficient balance");
                    ReturnItemsToFoodList(foods, localCartItems);
                }
                else if (userInput == "YES")
                {
                    Console.Write("Enter recharge amount:");
                    int.TryParse(Console.ReadLine()!, out int rechargeAmount);
                    user.WalletRecharge(rechargeAmount);
                    AddToCart(user, localCartItems, foods, cart, order, orders);
                }
            } while (userInput != "YES" && userInput != "NO");
            
        }

        static void Main(string[] args)
        {
            ListManager listManager = new ListManager();

            List<UserDetails> users = listManager.InitialUsers();

            List<OrderDetails> orders = listManager.orderDetails;

            List<CartItem> cartItems = listManager.cartItemsList();

            List<FoodDetails> foods = listManager.foodsList();

            Console.WriteLine("\n{0}\nCAFETERIA CARD MANAGEMENT\n{0}\n", new String('*', 60));
            do
            {
                Console.WriteLine("\n{0}\nMAIN MENU\n{0}", new String('.', 60));
                Console.WriteLine("\n1. User Registration\n2. User Login\n3. Exit");

                int.TryParse(Console.ReadLine()!, out int choice);

                switch (choice)
                {
                    case 1:
                        Registration(users);
                        break;
                    case 2:
                        UserLogin(users, foods, cartItems, orders);
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