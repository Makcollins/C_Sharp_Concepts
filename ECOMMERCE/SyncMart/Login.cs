using System;

namespace SyncMart;

public partial class Operations
{
    OrderDetails currentOrder = null!;
    public void Login()
    {
        int idOrderCounter = 1003;
        correct = true;
        Console.WriteLine("ENTER USER ID:");
        string inputID = Console.ReadLine()!;
        Console.WriteLine("\n----------------------------------");

        CustomerDetails loggedCustomer = customers.Find(user => user.CustomerID == inputID)!;

        if (loggedCustomer == null)
        {
            Console.WriteLine("Invalid User ID. Please enter a valid one");
        }
        else
        {
            do
            {
                Console.WriteLine("----------------------------------\n");
                Console.WriteLine("Welcome {0}", loggedCustomer.CustomerName);
                Console.WriteLine("----------------------------------\n");
                Console.WriteLine("Please choose an operation below to continue\n");
                Console.WriteLine("a. Purchase\nb. OrderHistory\nc. CancelOrder\nd. WalletBalance\ne. WalletRecharge\nf. Exit");
                char choice = Convert.ToChar(Console.ReadLine()!);

                switch (choice)
                {
                    case 'a':
                        Purchase(loggedCustomer, idOrderCounter);
                        idOrderCounter++;
                        break;
                    case 'b':
                        OrderHistory(loggedCustomer);
                        break;
                    case 'c':
                        CancelOrder(loggedCustomer);
                        break;
                    case 'd':
                        Console.WriteLine("WalletBalance");
                        break;
                    case 'e':
                        Console.WriteLine("WalletRecharge");
                        break;
                    case 'f':
                        correct = false;
                        break;

                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }
            } while (correct);
        }

    }

    // Purchase
    public void Purchase(CustomerDetails loggedCustomer, int counter)
    {
        Console.WriteLine(new string('-', 71));
        Console.WriteLine($"{"PRODUCT ID",-10} {"PRODUCT NAME",-20} {"STOCK",-10} {"PRICE",-10} {"SHIPPING DURATION",-10}");
        Console.WriteLine(new string('-', 71));
        foreach (var item in products)
        {
            Console.WriteLine($"{item.ProductID,-10} {item.ProductName,-20} {item.Stock,-10} {item.Price,-10} {item.ShippingDuration,-10}");
        }
        Console.WriteLine(new string('-', 71));

        Console.Write("Select Product ID: ");
        string? userInput = Console.ReadLine();

        var productToPurchase = products.Find(prod => prod.ProductID == userInput);

        if (productToPurchase == null)
        {
            Console.WriteLine("Invalid ProductID");
        }
        else
        {
            Console.Write("\nPlease enter number of counts: ");
            int counts = int.Parse(Console.ReadLine()!);

            if (counts > productToPurchase.Stock)
            {
                Console.WriteLine("Required count not available. Current availability is {0}", productToPurchase.Stock);
            }
            else
            {
                int delivery_Charge = 50;
                int totalAmount = (counts * productToPurchase.Price) + delivery_Charge;
                Console.WriteLine("TotalAmount = Rs {0}", totalAmount);

                if (loggedCustomer.WalletBalance < totalAmount)
                {
                    Console.WriteLine("Insufficient Wallet Balance. Please recharge your wallet and do the purchase again");
                }
                else
                {
                    loggedCustomer.DeductBalance(totalAmount);
                    productToPurchase.Stock -= counts;


                    currentOrder = new OrderDetails()
                    {
                        OrderID = "OID" + counter,
                        CustomerID = loggedCustomer.CustomerID,
                        ProductID = productToPurchase.ProductID,
                        TotalPrice = totalAmount,
                        PurchaseDate = DateTime.Now,
                        Quantity = counts,
                        Status = OrderStatus.Ordered
                    };
                    Console.WriteLine($"Order Placed Successfully. Order ID: {currentOrder.OrderID}");

                    DateTime deliveryDate = DateTime.Now.AddDays(productToPurchase.ShippingDuration);
                    Console.WriteLine($"Order Placed Successfully.Your order will be delivered on {deliveryDate.ToString("dd MMMM yyyy")}");
                }
            }
        }

    }

    public List<OrderDetails> UserOrders(CustomerDetails loggedCustomer)
    {
        List<OrderDetails> userOrders = orders.FindAll(userId => userId.CustomerID == loggedCustomer.CustomerID);
        return userOrders;
    }

    public void OrderHistory(CustomerDetails loggedCustomer)
    {
        var userOrders = UserOrders(loggedCustomer);
        Console.WriteLine($"{"OrderID",-10} {"ProductID",-10} {"TotalPrice",-10} {"PurchaseDate",-15} {"Quantity",-10} {"Order Status",-10}");
        Console.WriteLine(new string('-', 75));

        foreach (var item in userOrders)
        {
            Console.WriteLine($"{item.OrderID,-10} {item.ProductID,-10} {item.TotalPrice,-10} {item.PurchaseDate.ToString("dd MMM yyyy"),-15} {item.Quantity,-10} {item.Status,-10}");
        }

    }

    public void CancelOrder(CustomerDetails loggedCustomer)
    {
        OrderHistory(loggedCustomer);
        var userOrders = UserOrders(loggedCustomer);

        Console.WriteLine("Select order to be cancelled by Order ID:");
        string? userInput = Console.ReadLine();

        var orderToCancel = userOrders.Find(order => order.OrderID == userInput);

        if (orderToCancel == null)
        {
            Console.WriteLine("Invalid OrderID");
        }
        else
        {

            var cancelledProduct = products.Find(product => product.ProductID == orderToCancel.ProductID)!;
            cancelledProduct.Stock += orderToCancel.Quantity;
            var customerAffected = customers.Find(customer => customer.CustomerID == orderToCancel.CustomerID)!;
            customerAffected.WalletRecharge(orderToCancel.TotalPrice);
            orderToCancel.Status = OrderStatus.Cancelled;
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("Order: {0} Cancelled successfully.");
            Console.WriteLine("------------------------------------------");
        }
    }
}
