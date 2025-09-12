using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Transactions;

namespace Cafeteria;

public class OrderManager
{
    static DataManager dataManager = new DataManager();
    static List<UserDetails> users = AuthenticationManager.users;
    static List<OrderDetails> orders = DataManager.ReadOrdersFromCSV();
    static List<CartItem> cartItems = DataManager.ReadCartFromCSV();
    static List<FoodDetails> foods = DataManager.ReadFoodFromCSV();

    // public static int orderIdCounter = OrderIdCounter();

    public async Task FoodOrder(UserDetails user)
    {
        //create a temporary local carItemtList.
        List<CartItem> wishlist = new();

        //Create an Order object with current UserID, Order date as current DateTime, total price as 0, Order status as “Initiated”.
        OrderDetails foodOrder = new() { UserID = user.UserID, OrderDate = DateTime.Now, TotalPrice = 0, OrderStatus = OrderStatus.Initiated };

        string userChoice = "NO";

        bool correct = true;

        do
        {
            //show food items when user wants to order
            dataManager.DisplayList(foods);

            //Ask the user to pick a product using FoodID, quantity required and calculate price of food.
            Console.WriteLine("Please pick a product by entering FoddID and Quantity: ");
            Console.Write("FoodID: ");
            string foodID = Console.ReadLine()!.Trim().ToUpper();

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
                //check food quantity available
                if (quantity > productPicked.AvailableQuantity)
                {
                    Console.WriteLine($"\nSorry, only {productPicked.AvailableQuantity} available");
                }
                else if (quantity < 1)
                {
                    Console.WriteLine($"\nYou can buy at least 1 product\n");
                    correct = false;
                }
                else
                {
                    productPicked.AvailableQuantity -= quantity;

                    //create CartItems object using the available data
                    CartItem newItem = new CartItem { OrderID = foodOrder.OrderID, FoodID = productPicked.FoodID, OrderPrice = productPicked.Price * quantity, OrderQuantity = quantity };

                    //add the object to local cart items list
                    wishlist.Add(newItem);

                    //ask user whether he want to pick another product
                    Console.Write("\nDo you want to pick another product? \"Yes/No\" : ");
                    do
                    {
                        userChoice = Console.ReadLine()!.Trim().ToUpper();
                        if (userChoice != "YES" && userChoice != "NO")
                            Console.Write("\nInvalid choice! Type 'Yes' or 'No': ");

                    } while (userChoice != "YES" && userChoice != "NO");
                }
            }
            else
            {
                Console.WriteLine("\nInvalid FoodID!");
            }

        } while (userChoice == "YES");

        //proceed with purchase if food ID is valid and other conditions are met.
        if (wishlist.Any(list => list.FoodID != null)) await ProceedWithPurchase(user, wishlist, foodOrder);

        // DataManager.DisplayList(cartItems);
    }

    public async Task ModifyOrder(UserDetails user)
    {
        //get and show rder details of current logged in user to pick an Order detail by using OrderID and whose status is “Ordered”. 
        var userOrders = orders.Where(x => x.UserID == user.UserID && x.OrderStatus == OrderStatus.Ordered).ToList();
        dataManager.DisplayList(userOrders);

        Console.Write("\nPick an order by ID:");
        string orderInput = Console.ReadLine()!.Trim().ToUpper();

        var pickedOrder = userOrders.Find(picked => picked.OrderID == orderInput);
        if (pickedOrder != null)
        {
            //Show list of Cart Item details 
            var userCartItems = cartItems.FindAll(x => x.OrderID == pickedOrder.OrderID).ToList();
            dataManager.DisplayList(userCartItems);

            //ask user to pick an Item id
            Console.Write("Enter item ID:");
            string userInput = Console.ReadLine()!.Trim().ToUpper();

            var selectedItem = userCartItems.Find(selected => selected.ItemID == userInput);

            if (selectedItem == null)
            {
                Console.WriteLine("\nItem does not exist\n");
            }
            else
            {
                var selectedFood = foods.Find(food => food.FoodID == selectedItem.FoodID)!;
                bool correct;
                int quantity;

                do
                {
                    correct = true;
                    Console.Write("Quantity: ");
                    correct = int.TryParse(Console.ReadLine(), out quantity);
                    if (!correct) { Console.WriteLine("Invalid entry!\n"); }

                } while (!correct);

                int totalQuantity = selectedFood.AvailableQuantity + selectedItem.OrderQuantity;
                if (quantity > totalQuantity)
                {
                    Console.WriteLine($"Sorry, you can only get quantity of upto {selectedFood.AvailableQuantity + selectedItem.OrderQuantity} for now.\n");
                }
                else if (quantity < 1)
                {
                    Console.WriteLine("\nPlease make it one or more to modify, or proceed to 'Cancel Order' to cancel the order.\n");
                }
                else
                {
                    decimal oldPrice = pickedOrder.TotalPrice;
                    selectedFood.AvailableQuantity = totalQuantity - quantity;
                    selectedItem.OrderPrice = quantity * selectedFood.Price;
                    selectedItem.OrderQuantity = quantity;
                    pickedOrder!.TotalPrice = userCartItems.Sum(x => x.OrderPrice);

                    if (pickedOrder.TotalPrice > oldPrice) user.DeductAmount(pickedOrder.TotalPrice - oldPrice);
                    else user.WalletRecharge(oldPrice - pickedOrder.TotalPrice);

                    await UpdateCSVs();
                }

                Console.WriteLine("\nOrder Modified successfully\n");

            }
        }
    }

    public void ReturnItemsToFoodList(List<CartItem> wishlist)
    {
        foreach (var item in foods)
        {
            foreach (var x in wishlist)
            {
                if (x.FoodID == item.FoodID)
                {
                    item.AvailableQuantity += x.OrderQuantity;
                }
            }
        }
    }

    public async Task CancelOrder(UserDetails user)
    {
        var userOrders = orders.Where(x => x.UserID == user.UserID && x.OrderStatus == OrderStatus.Ordered).ToList();
        if (!userOrders.Any())
            Console.WriteLine("\nNo order found!\n");
        else
        {
            dataManager.DisplayList(userOrders);

            Console.Write("\nEnter Order ID:");
            string userInput = Console.ReadLine()!.Trim().ToUpper();

            var selectedOrder = userOrders.Find(selected => selected.OrderID == userInput);

            if (selectedOrder == null)
            {
                Console.WriteLine("\nInvalid OrderID\n");
            }
            else
            {
                user.WalletRecharge(selectedOrder.TotalPrice);
                var filteredCart = cartItems.Where(x => x.OrderID == selectedOrder.OrderID).ToList();

                ReturnItemsToFoodList(filteredCart);

                selectedOrder.OrderStatus = OrderStatus.Cancelled;

                await UpdateCSVs();

                Console.WriteLine("\nOrder cancelled successfully\n");
            }
        }
    }

    public void OrderHistory(UserDetails user)
    {
        if (orders.Any(order => order.UserID == user.UserID))
            dataManager.DisplayList(orders.Where(order => order.UserID == user.UserID).ToList());
        else
            Console.WriteLine("\nNo order history found!\n");
    }

    public async Task RechargeWallet(UserDetails user)
    {
        decimal amount;
        bool correct;
        do
        {
            Console.WriteLine("\nEnter Recharge Amount: ");
            correct = decimal.TryParse(Console.ReadLine(), out amount);
            if (!correct || amount < 1)
            {
                Console.WriteLine("\nEnter a valid amount to recharge wallet (amount should be more than 0)!");
            }
        } while (!correct || amount < 1);

        user.WalletRecharge(amount);
        await DataManager.WriteToCSV(users);
        Console.WriteLine($"\nSuccessfully recharged {amount}/= New balance is {user.WalletBalance}/= \n");

    }

    public async Task ProceedWithPurchase(UserDetails user, List<CartItem> wishlist, OrderDetails order)
    {
        string userChoice;
        do
        {
            dataManager.DisplayList(wishlist);
            Console.Write("\nProceed with purchase of the wish list? 'Yes/No' : ");
            userChoice = Console.ReadLine()!.Trim().ToUpper();
            if (userChoice == "NO")
            {
                ReturnItemsToFoodList(wishlist);
            }
            else if (userChoice == "YES")
            {
                //update the main Cart | update user balance 
                await AddToCart(user, wishlist, order);
            }
            else
            {
                Console.Write("\nInvalid choice! Type 'Yes' or 'No' : ");
            }
        } while (userChoice != "YES" && userChoice != "NO");
    }

    public async Task AddToCart(UserDetails user, List<CartItem> wishlist, OrderDetails order)
    {
        decimal totalPrice = wishlist.Sum(x => x.OrderPrice);

        if (user.WalletBalance >= totalPrice)
        {
            user.DeductAmount(totalPrice);
            await DataManager.AppendNewToCSV(wishlist);
            order.OrderStatus = OrderStatus.Ordered;
            order.TotalPrice = totalPrice;
            await DataManager.AppendNewToCSV(order);
            await DataManager.WriteToCSV(users);
            Console.WriteLine($"\nOrder placed successfully, and OrderID is {order.OrderID}\n");

            orders.Clear();
            cartItems.Clear();
            orders = DataManager.ReadOrdersFromCSV();
            cartItems = DataManager.ReadCartFromCSV();  
        }
        else
        {
            await RechargeWalletToPurchase(user, wishlist, order);
        }
    }

    public async Task RechargeWalletToPurchase(UserDetails user, List<CartItem> localCartItems, OrderDetails order)
    {
        string userInput;
        Console.WriteLine("\nInsufficient balance to purchase! Are you willing to recharge? 'Yes/No' : ");

        do
        {
            userInput = Console.ReadLine()!.Trim().ToUpper();
            if (userInput == "NO")
            {
                Console.WriteLine("\nexiting without order due to insufficient balance!");
                ReturnItemsToFoodList(localCartItems);
            }
            else if (userInput == "YES")
            {
                Console.WriteLine($"Deficit : {order.TotalPrice - user.WalletBalance}");
                await RechargeWallet(user);
                await AddToCart(user, localCartItems, order);
            }
            else
                Console.WriteLine("Invalid choice, Please Input 'Yes/No' : ");
        } while (userInput != "YES" && userInput != "NO");
    }

    public static async Task UpdateCSVs()
    {
        await DataManager.WriteToCSV(users);
        await DataManager.WriteToCSV(cartItems);
        await DataManager.WriteToCSV(orders);
        await DataManager.WriteToCSV(foods);
    }

}
