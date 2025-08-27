using System;

namespace Cafeteria;

public class ListManager
{
    // UserDetails object1 = new UserDetails { UserID = "SF1001", Name = "Ravichandran", FatherName = "Ettapparajan", Mobile = "8857777575", MailID = "ravi@gmail.com", Gender = Gender.Male, WorkStationNumber = "WS101", balance = 400 };
    // UserDetails object2 = new UserDetails{UserID = "SF1002", Name = "Baskaran", FatherName="Sethurajan", Mobile ="9577747744", MailID = "baskaran@gmail.com",Gender =Gender.Male, WorkStationNumber ="WS105",balance =500};

    public List<UserDetails> InitialUsers()
    {
        List<UserDetails> users = new List<UserDetails>(){
        new UserDetails { UserID = "SF1001", Name = "Ravichandran", FatherName = "Ettapparajan", Mobile = "8857777575", MailID = "ravi@gmail.com", Gender = Gender.Male, WorkStationNumber = "WS101", balance = 400 },
        new UserDetails { UserID = "SF1002", Name = "Baskaran", FatherName = "Sethurajan", Mobile = "9577747744", MailID = "baskaran@gmail.com", Gender = Gender.Male, WorkStationNumber = "WS105", balance = 50},
        };

        return users;
    }


    public List<OrderDetails> orderDetails = new List<OrderDetails>()
    {
        new OrderDetails{UserID = "SF1001", OrderDate = Convert.ToDateTime("15/06/2022"), TotalPrice = 70, OrderStatus = OrderStatus.Ordered},
        new OrderDetails{UserID = "SF1002", OrderDate = Convert.ToDateTime("15/06/2022"), TotalPrice = 100, OrderStatus = OrderStatus.Ordered},
    };

    public List<CartItem> cartItemsList()
    {
        List<CartItem> cartItems = new List<CartItem>()
    {
        new CartItem{OrderID = "OID1001", FoodID = "FID101", OrderPrice = 20, OrderQuantity=1},
        new CartItem{OrderID = "OID1001", FoodID = "FID103", OrderPrice = 10, OrderQuantity=1},
        new CartItem{OrderID = "OID1001", FoodID = "FID105", OrderPrice = 40, OrderQuantity=1},
        new CartItem{OrderID = "OID1002", FoodID = "FID103", OrderPrice = 10, OrderQuantity=1},
        new CartItem{OrderID = "OID1002", FoodID = "FID104", OrderPrice = 50, OrderQuantity=1},
        new CartItem{OrderID = "OID1002", FoodID = "FID105", OrderPrice = 40, OrderQuantity=1}
    };
        return cartItems; 
    }
    

    public List<FoodDetails> foodsList()
    {
        List<FoodDetails> foodDetails = new List<FoodDetails>()
    {
        new FoodDetails(){FoodName = "Coffee", Price = 20, AvailableQuantity = 100},
        new FoodDetails(){FoodName = "Tea", Price = 15, AvailableQuantity = 100},
        new FoodDetails(){FoodName = "Biscuit", Price = 10, AvailableQuantity = 100},
        new FoodDetails(){FoodName = "Juice", Price = 50, AvailableQuantity = 100},
        new FoodDetails(){FoodName = "Puff", Price = 40, AvailableQuantity = 100},
        new FoodDetails(){FoodName = "Milk", Price = 10, AvailableQuantity = 100},
        new FoodDetails(){FoodName = "Popcorn", Price = 20, AvailableQuantity = 20},
    };
        return foodDetails;
}


}
