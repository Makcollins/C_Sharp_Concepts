using System;

namespace Cafeteria;

public class ListManager
{
    static string usersCSV = "CSVfiles/users.csv";
    static string ordersCSV = "CSVfiles/orders.csv";
    static string cartCSV = "CSVfiles/cart_items.csv";
    static string foodsCSV = "CSVfiles/foods.csv";
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
    public static async Task AppendNewToCSV(UserDetails user)
    {
        await File.AppendAllTextAsync(usersCSV, $"{user.UserID},{user.Name},{user.FatherName},{user.Mobile},{user.MailID},{user.Gender},{user.WorkStationNumber},{user.balance}");
    }

    public static List<UserDetails> ReadUsersFromCSV()
    {
        List<UserDetails> users = new();
        var lines = File.ReadAllLines("CSVfiles/users.csv");

        foreach (var line in lines)
        {
            var values = line.Split(',');
            var user = new UserDetails { UserID = values[0], Name = values[1], FatherName = values[2], Mobile = values[3], MailID = values[4], Gender = Enum.Parse<Gender>(values[5]), WorkStationNumber = values[6], balance = Convert.ToDecimal(values[7]) };
            users.Add(user);
        }
        return users;
    }

    public static List<OrderDetails> OrdersList()
    {
        return new List<OrderDetails>()
        {
            new OrderDetails{UserID = "SF1001", OrderDate = Convert.ToDateTime("15/06/2022"), TotalPrice = 70, OrderStatus = OrderStatus.Ordered},
            new OrderDetails{UserID = "SF1002", OrderDate = Convert.ToDateTime("15/06/2022"), TotalPrice = 100, OrderStatus = OrderStatus.Ordered}
        };

    }
    public static async Task AppendOrdersToCSV()
    {
        var newList = OrdersList();
        if (!File.Exists(ordersCSV))
        {
            foreach (var item in newList)
            {
                await File.AppendAllTextAsync(ordersCSV, $"{item.OrderID},{item.UserID},{item.OrderDate},{item.TotalPrice},{item.OrderStatus}\n");
            }
        }
    }

    public static List<CartItem> CartItemsList()
    {
        return new List<CartItem>()
        {
            new CartItem{OrderID = "OID1001", FoodID = "FID101", OrderPrice = 20, OrderQuantity=1},
            new CartItem{OrderID = "OID1001", FoodID = "FID103", OrderPrice = 10, OrderQuantity=1},
            new CartItem{OrderID = "OID1001", FoodID = "FID105", OrderPrice = 40, OrderQuantity=1},
            new CartItem{OrderID = "OID1002", FoodID = "FID103", OrderPrice = 10, OrderQuantity=1},
            new CartItem{OrderID = "OID1002", FoodID = "FID104", OrderPrice = 50, OrderQuantity=1},
            new CartItem{OrderID = "OID1002", FoodID = "FID105", OrderPrice = 40, OrderQuantity=1}
        };
    }
    public static async Task AppendCartToCSV()
    {
        var newList = CartItemsList();
        if (!File.Exists(cartCSV))
        {
            foreach (var item in newList)
            {
                await File.AppendAllTextAsync(cartCSV, $"{item.ItemID},{item.OrderID},{item.FoodID},{item.OrderPrice},{item.OrderQuantity}\n");
            }
        }
    }


    public static List<FoodDetails> FoodsList()
    {
        return new List<FoodDetails>()
        {
            new FoodDetails(){FoodName = "Coffee", Price = 20, AvailableQuantity = 100},
            new FoodDetails(){FoodName = "Tea", Price = 15, AvailableQuantity = 100},
            new FoodDetails(){FoodName = "Biscuit", Price = 10, AvailableQuantity = 100},
            new FoodDetails(){FoodName = "Juice", Price = 50, AvailableQuantity = 100},
            new FoodDetails(){FoodName = "Puff", Price = 40, AvailableQuantity = 100},
            new FoodDetails(){FoodName = "Milk", Price = 10, AvailableQuantity = 100},
            new FoodDetails(){FoodName = "Popcorn", Price = 20, AvailableQuantity = 20},
        };
    }
    public static async Task AppendFoodToCSV()
    {
        var newList = FoodsList();
        if (!File.Exists(foodsCSV))
        {
            foreach (var item in newList)
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


}
