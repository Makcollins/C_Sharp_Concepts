using System;

namespace Cafeteria;

public class DataManager
{
    static string usersCSV = "CSVfiles/users.csv";
    static string ordersCSV = "CSVfiles/orders.csv";
    static string cartCSV = "CSVfiles/cart_items.csv";
    static string foodsCSV = "CSVfiles/foods.csv";

    public static void CreateDirectory()
    {
        string folderPath = "CSVfiles";
        if (!Directory.Exists(folderPath))
            Directory.CreateDirectory(folderPath);
    }
    
    public static void CreateCsvFiles()
    {
        if (!File.Exists(usersCSV))
            File.Create(usersCSV);
        if (!File.Exists(ordersCSV))
            File.Create(ordersCSV);
        if (!File.Exists(cartCSV))
            File.Create(cartCSV);
        if (!File.Exists(foodsCSV))
            File.Create(foodsCSV);
    }


    //USERS MODEL OPERATIONS
    public static async Task AppendNewToCSV(UserDetails user)
    {
        await File.AppendAllTextAsync(usersCSV, $"\n{user.UserID},{user.Name},{user.FatherName},{user.Mobile},{user.MailID},{user.Gender},{user.WorkStationNumber},{user.WalletBalance}");
    }
    public static async Task WriteToCSV(List<UserDetails> users)
    {
        File.Delete(usersCSV);
        foreach (var item in users)
        {
            await File.AppendAllTextAsync(usersCSV, $"{item.UserID},{item.Name},{item.FatherName},{item.Mobile},{item.MailID},{item.Gender},{item.WorkStationNumber},{item.balance}\n");
        }
    }

    public static List<UserDetails> ReadUsersFromCSV()
    {
        List<UserDetails> users = new();
        var lines = File.ReadAllLines(usersCSV);

        foreach (var line in lines)
        {
            var values = line.Split(',');
            var user = new UserDetails { UserID = values[0], Name = values[1], FatherName = values[2], Mobile = values[3], MailID = values[4], Gender = Enum.Parse<Gender>(values[5]), WorkStationNumber = values[6], balance = Convert.ToDecimal(values[7]) };
            users.Add(user);
        }
        return users;
    }

    /// ORDER OPERATIONS
    public static async Task AppendNewToCSV(OrderDetails order)
    {
        await File.AppendAllTextAsync(ordersCSV, $"\n{order.OrderID},{order.UserID},{order.OrderDate},{order.TotalPrice},{order.OrderStatus}");
    }

    public static List<OrderDetails> ReadOrdersFromCSV()
    {
        List<OrderDetails> orders = new();
        var lines = File.ReadAllLines(ordersCSV);

        foreach (var line in lines)
        {
            var values = line.Split(',');
            var order = new OrderDetails { OrderID = values[0], UserID = values[1], OrderDate = Convert.ToDateTime(values[2]), TotalPrice = decimal.Parse(values[3]), OrderStatus = Enum.Parse<OrderStatus>(values[4]) };
            orders.Add(order);
        }
        return orders;
    }

    public static async Task WriteToCSV(List<OrderDetails> orders)
    {
        File.Delete(ordersCSV);
        foreach (var item in orders)
        {
            await File.AppendAllTextAsync(ordersCSV, $"{item.OrderID},{item.UserID},{item.OrderDate},{item.TotalPrice},{item.OrderStatus}\n");
        }
    }

    //CART OPERATIONS
    public static async Task AppendNewToCSV(List<CartItem> cart)
    {
        foreach (var item in cart)
        {
            await File.AppendAllTextAsync(cartCSV, $"\n{item.ItemID},{item.OrderID},{item.FoodID},{item.OrderPrice},{item.OrderQuantity}");
        }
    }
    public static List<CartItem> ReadCartFromCSV()
    {
        List<CartItem> cart = new();
        var lines = File.ReadAllLines(cartCSV);

        foreach (var line in lines)
        {
            var values = line.Split(',');
            var cartItem = new CartItem { ItemID = values[0], OrderID = values[1], FoodID = values[2], OrderPrice = decimal.Parse(values[3]), OrderQuantity = int.Parse(values[4]) };
            cart.Add(cartItem);
        }
        return cart;
    }
    public static async Task WriteToCSV(List<CartItem> cart)
    {
        File.Delete(cartCSV);
        foreach (var item in cart)
        {
            await File.AppendAllTextAsync(cartCSV, $"{item.ItemID},{item.OrderID},{item.FoodID},{item.OrderPrice},{item.OrderQuantity}\n");
        }
    }

    public static List<FoodDetails> ReadFoodFromCSV()
    {
        List<FoodDetails> foods = new();
        var lines = File.ReadAllLines(foodsCSV);

        foreach (var line in lines)
        {
            var values = line.Split(',');
            var food = new FoodDetails { FoodID = values[0], FoodName = values[1], Price = decimal.Parse(values[2]), AvailableQuantity = int.Parse(values[2]) };
            foods.Add(food);
        }
        return foods;
    }
    public static async Task WriteToCSV(List<FoodDetails> foods)
    {
        File.Delete(foodsCSV);
        if (!File.Exists(foodsCSV))
        {
            foreach (var item in foods)
            {
                await File.AppendAllTextAsync(foodsCSV, $"{item.FoodID},{item.FoodName},{item.Price},{item.AvailableQuantity}\n");
            }
        }
    }

    public void DisplayList(List<OrderDetails> orders)
    {
        Console.WriteLine($"\n{new String('-', 60)}\n{"OrderID",-10}{"OrderDate",-10}{"TotalPrice",-10}{"OrderStatus",-10}\n{new String('-', 60)}");
        orders.ForEach(item => Console.WriteLine($"{item.OrderID,-10}{item.OrderDate.ToShortDateString(),-15}{item.TotalPrice,-10}{item.OrderStatus,-10}"));
        Console.WriteLine(new String('-', 60) + "\n");
    }

    public void DisplayList(List<CartItem> cartItems)
    {
        Console.WriteLine($"\n{new String('-', 60)}\n{"ItemID",-10}{"OrderID",-10}{"FoodID",-10}{"OrderPrice",-12}{"OrderQuantity",-10}\n{new String('-', 60)}");
        cartItems.ForEach(x => Console.WriteLine($"{x.ItemID,-10}{x.OrderID,-10}{x.FoodID,-10}{x.OrderPrice,-12}{x.OrderQuantity,-10}\n"));
        Console.WriteLine(new String('-', 60) + "\n");
    }

    public void DisplayList(List<FoodDetails> foods)
    {
        Console.WriteLine($"\n{new String('-', 60)}\n{"FoodID",-10}{"FoodName",-10}{"Price",-10}{"AvailabityQuantity",-10}\n{new String('-', 60)}");
        foods.ForEach(item => Console.WriteLine($"{item.FoodID,-10}{item.FoodName,-10}{item.Price,-10}{item.AvailableQuantity,-10}"));
        Console.WriteLine(new String('-', 60) + "\n");
    }

    ///INITIAL OPERATIONS. TO ADD LISTS TO CSV FILES

    // public static List<UserDetails> InitialUsers()
    // {
    //     return new List<UserDetails>()
    //     {
    //         new UserDetails {Name = "Ravichandran", FatherName = "Ettapparajan", Mobile = "8857777575", MailID = "ravi@gmail.com", Gender = Gender.Male, WorkStationNumber = "WS101", balance = 400 },
    //         new UserDetails {Name = "Baskaran", FatherName = "Sethurajan", Mobile = "9577747744", MailID = "baskaran@gmail.com", Gender = Gender.Male, WorkStationNumber = "WS105", balance = 50},
    //     };
    // }

    // public static async Task AppendUsersToCSV()
    // {
    //     var newList = InitialUsers();
    //     if (!File.Exists(usersCSV))
    //     {
    //         foreach (var item in newList)
    //         {
    //             await File.AppendAllTextAsync(usersCSV, $"{item.UserID},{item.Name},{item.FatherName},{item.Mobile},{item.MailID},{item.Gender},{item.WorkStationNumber},{item.balance}\n");
    //         }
    //     }
    // }

    // public static List<OrderDetails> OrdersList()
    // {
    //     return new List<OrderDetails>()
    //     {
    //         new OrderDetails{UserID = "SF1001", OrderDate = Convert.ToDateTime("15/06/2022"), TotalPrice = 70, OrderStatus = OrderStatus.Ordered},
    //         new OrderDetails{UserID = "SF1002", OrderDate = Convert.ToDateTime("15/06/2022"), TotalPrice = 100, OrderStatus = OrderStatus.Ordered}
    //     };
    // }

    // public static async Task AppendOrdersToCSV()
    // {
    //     var newList = OrdersList();
    //     if (!File.Exists(ordersCSV))
    //     {
    //         foreach (var item in newList)
    //         {
    //             await File.AppendAllTextAsync(ordersCSV, $"{item.OrderID},{item.UserID},{item.OrderDate},{item.TotalPrice},{item.OrderStatus}\n");
    //         }
    //     }
    // }

    //CART OPERATIONS
    // public static List<CartItem> CartItemsList()
    // {
    //     return new List<CartItem>()
    //     {
    //         new CartItem{OrderID = "OID1001", FoodID = "FID101", OrderPrice = 20, OrderQuantity=1},
    //         new CartItem{OrderID = "OID1001", FoodID = "FID103", OrderPrice = 10, OrderQuantity=1},
    //         new CartItem{OrderID = "OID1001", FoodID = "FID105", OrderPrice = 40, OrderQuantity=1},
    //         new CartItem{OrderID = "OID1002", FoodID = "FID103", OrderPrice = 10, OrderQuantity=1},
    //         new CartItem{OrderID = "OID1002", FoodID = "FID104", OrderPrice = 50, OrderQuantity=1},
    //         new CartItem{OrderID = "OID1002", FoodID = "FID105", OrderPrice = 40, OrderQuantity=1}
    //     };
    // }

    // public static async Task AppendCartToCSV()
    // {
    //     var newList = CartItemsList();
    //     if (!File.Exists(cartCSV))
    //     {
    //         foreach (var item in newList)
    //         {
    //             await File.AppendAllTextAsync(cartCSV, $"{item.ItemID},{item.OrderID},{item.FoodID},{item.OrderPrice},{item.OrderQuantity}\n");
    //         }
    //     }
    // }

    /// FOOD OPERATIONS
    // public static List<FoodDetails> FoodsList()
    // {
    //     return new List<FoodDetails>()
    //     {
    //         new FoodDetails(){FoodName = "Coffee", Price = 20, AvailableQuantity = 100},
    //         new FoodDetails(){FoodName = "Tea", Price = 15, AvailableQuantity = 100},
    //         new FoodDetails(){FoodName = "Biscuit", Price = 10, AvailableQuantity = 100},
    //         new FoodDetails(){FoodName = "Juice", Price = 50, AvailableQuantity = 100},
    //         new FoodDetails(){FoodName = "Puff", Price = 40, AvailableQuantity = 100},
    //         new FoodDetails(){FoodName = "Milk", Price = 10, AvailableQuantity = 100},
    //         new FoodDetails(){FoodName = "Popcorn", Price = 20, AvailableQuantity = 20},
    //     };
    // }

    // public static async Task AppendFoodToCSV()
    // {
    //     var newList = FoodsList();
    //     if (!File.Exists(foodsCSV))
    //     {
    //         foreach (var item in newList)
    //         {
    //             await File.AppendAllTextAsync(foodsCSV, $"{item.FoodID},{item.FoodName},{item.Price},{item.AvailableQuantity}\n");
    //         }
    //     }
    // }
}
