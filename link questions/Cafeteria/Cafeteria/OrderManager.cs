using System;

namespace Cafeteria;

public class OrderManager
{
    static ListManager listManager = new ListManager();
    List<OrderDetails> orders = listManager.orderDetails;
    List<CartItem> cartItems = listManager.cartItemsList();
    List<FoodDetails> foods = listManager.foodsList();

    public void FoodOrder(UserDetails user)

    {
        string userChoice = "NO";

        OrderDetails order;
        List<CartItem> wishlist = new();

        bool correct = true;

        do
        {
            Console.WriteLine($"{"FoodID",-10}{"FoodName",-10}{"Price",-10}{"AvailabityQuantity",-10}");
            foods.ForEach(item => Console.WriteLine($"{item.FoodID,-10}{item.FoodName,-10}{item.Price,-10}{item.AvailableQuantity,-10}"));

            //Create an Order object with current UserID, Order date as current DateTime, total price as 0, Order status as “Initiated”.
            order = new() { UserID = user.UserID, OrderDate = DateTime.Now, TotalPrice = 0, OrderStatus = OrderStatus.Initiated };

            //Ask the user to pick a product using FoodID, quantity required and calculate price of food.
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

                    CartItem newItem = new CartItem { OrderID = order.OrderID, FoodID = productPicked.FoodID, OrderPrice = productPicked.Price, OrderQuantity = quantity };
                    wishlist.Add(newItem);

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
                ReturnItemsToFoodList(wishlist);

            }
            else if (userChoice == "YES")
            {
                //update the main Cart | update user balance 
                AddToCart(user, wishlist, order);

            }
        } while (userChoice != "YES" && userChoice != "NO");

    }

    public void ModifyOrder(UserDetails user)
    {
        //Order details of current logged in user to pick an Order detail by using OrderID and whose status is “Ordered”. 
        var activeOrders = orders.Where(x => x.UserID == user.UserID && x.OrderStatus == OrderStatus.Ordered).ToList();

        Console.WriteLine($"{"\nOrderID",-10}{"OrderDate",-10}{"TotalPrice",-10}\n{new String('-', 35)}");
        activeOrders.ForEach(item => Console.WriteLine($"{item.OrderID,-10}{item.OrderDate.ToShortDateString(),-15}{item.TotalPrice,-10}\n"));

        //2.	Show list of Cart Item details 
        Console.WriteLine($"{"ItemID",-10}{"OrderID",-10}{"FoodID",-10}{"OrderPrice",-12}{"OrderQuantity",-10}\n{new String('-', 60)}");
        cartItems.ForEach(x => Console.WriteLine($"{x.ItemID,-10}{x.OrderID,-10}{x.FoodID,-10}{x.OrderPrice,-12}{x.OrderQuantity,-10}\n"));

        //ask the user to pick an Item id
        Console.Write("Emter item ID:");
        string userInput = Console.ReadLine()!.ToUpper();

        var selectedItem = cartItems.Find(selected => selected.ItemID == userInput);

        if (selectedItem == null)
        {
            Console.WriteLine("Item does not exist");
        }
        else
        {
            bool correct;
            int quantity;
            do
            {
                correct = true;
                Console.Write("Quantity: ");
                correct = int.TryParse(Console.ReadLine(), out quantity);
                if (!correct) { Console.WriteLine("Invalid entry!\n"); }

            } while (!correct);

            var selectedFood = foods.Find(food => food.FoodID == selectedItem.FoodID);
            var selectedOrder = activeOrders.Find(order => order.OrderID == selectedItem.OrderID);

            selectedItem.OrderPrice = quantity * selectedFood!.Price;
            selectedItem.OrderQuantity = quantity;

            selectedOrder!.TotalPrice = cartItems.Where(x => x.OrderID == selectedOrder.OrderID).Sum(x => x.OrderPrice);

            Console.WriteLine("Order Modified successfully");

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

    public void CancelOrder(UserDetails user)
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
            var filteredCart = cartItems.Where(x => x.OrderID == selectedOrder.OrderID).ToList();

            ReturnItemsToFoodList(filteredCart);

            selectedOrder.OrderStatus = OrderStatus.Cancelled;

            Console.WriteLine("Order cancelled successfully");

        }
    }

    public void OrderHistory(UserDetails user)
    {
        Console.WriteLine($"{"\nOrderID",-10}{"OrderDate",-10}{"TotalPrice",-10}{"OrderStatus",-10}\n{new String('-', 60)}");
        orders.Where(order => order.UserID == user.UserID).ToList()
        .ForEach(item => Console.WriteLine($"{item.OrderID,-10}{item.OrderDate.ToShortDateString(),-15}{item.TotalPrice,-10}{item.OrderStatus,-10}\n"));
    }

    public void UpdateWallet(UserDetails user)
    {
        decimal amount;
        bool correct;
        do
        {
            Console.WriteLine("Enter amount: ");
            correct = decimal.TryParse(Console.ReadLine(), out amount);
        } while (!correct);

        user.WalletRecharge(amount);

    }
    public void AddToCart(UserDetails user, List<CartItem> wishlist, OrderDetails order)
    {
        decimal totalPrice = wishlist.Sum(x => x.OrderPrice * x.OrderQuantity);

        if (user.WalletBalance >= totalPrice)
        {
            user.DeductAmount(totalPrice);
            cartItems.AddRange(wishlist);
            order.OrderStatus = OrderStatus.Ordered;
            order.TotalPrice = totalPrice;
            orders.Add(order);
            Console.WriteLine($"Order placed successfully, and OrderID is {orders.Select(x => x.OrderID).Last()}");
        }
        else
        {
            RechargeWallet(user, wishlist, order);
        }

    }
    public void RechargeWallet(UserDetails user, List<CartItem> localCartItems, OrderDetails order)
    {
        string userInput;
        do
        {
            Console.WriteLine("Insufficient balance to purchase! Are you willing to recharge? 'Yes/No' : ");
            userInput = Console.ReadLine()!.ToUpper();
            if (userInput == "NO")
            {
                Console.WriteLine("exiting without order due to insufficient balance");
                ReturnItemsToFoodList(localCartItems);
            }
            else if (userInput == "YES")
            {
                Console.Write("Enter recharge amount:");
                int.TryParse(Console.ReadLine()!, out int rechargeAmount);
                user.WalletRecharge(rechargeAmount);
                AddToCart(user, localCartItems, order);
            }
        } while (userInput != "YES" && userInput != "NO");

    }


}
