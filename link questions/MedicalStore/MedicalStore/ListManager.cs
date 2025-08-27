using System;

namespace MedicalStore;

public class ListManager
{

    public List<UserDetails> UsersList()
    {
        List<UserDetails> users = new()
    {
        new UserDetails { Name = "Ravi", Age = 33, City = "Theni", PhoneNumber = "9877774440", WalletBalance = 400 },
        new UserDetails { Name = "Ravi", Age = 33, City = "Theni", PhoneNumber = "9877774440", WalletBalance = 400 }
    };
        return users;
    }

    public List<MedicineDetails> MedicinesList()
    {
        List<MedicineDetails> medicineDetails = new()
    {
        new MedicineDetails() { MedicineName = "Paracitamol", AvailableCount = 40, Price = 5, DateOfExpiry = Convert.ToDateTime("30/06/2024") },
        new MedicineDetails() { MedicineName = "Calpol", AvailableCount = 10, Price = 5, DateOfExpiry = Convert.ToDateTime("30/05/2024") },
        new MedicineDetails() { MedicineName = "Gelucil", AvailableCount = 3, Price = 5, DateOfExpiry = Convert.ToDateTime("30/06/2024") },
        new MedicineDetails() { MedicineName = "Metrogel", AvailableCount = 5, Price = 5, DateOfExpiry = Convert.ToDateTime("30/06/2024") },
        new MedicineDetails() { MedicineName = "Povidin lodin", AvailableCount = 10, Price = 5, DateOfExpiry = Convert.ToDateTime("30/06/2024") }
    };
        return medicineDetails;
    }

    public List<OrderDetails> OrdersList()
    {
        List<OrderDetails> orders = new()
    {
        new OrderDetails() { UserID = "UID1001", MedicineID = "MD101", MedicineCount = 3, TotalPrice = 15, OrderDate = Convert.ToDateTime("13/11/2022"), OrderStatus = OrderStatus.Purchased },
        new OrderDetails() { UserID = "UID1001", MedicineID = "MD102", MedicineCount = 3, TotalPrice = 10, OrderDate = Convert.ToDateTime("13/11/2022"), OrderStatus = OrderStatus.Cancelled },
        new OrderDetails() { UserID = "UID1001", MedicineID = "MD104", MedicineCount = 3, TotalPrice = 100, OrderDate = Convert.ToDateTime("13/11/2022"), OrderStatus = OrderStatus.Purchased },
        new OrderDetails() { UserID = "UID1002", MedicineID = "MD103", MedicineCount = 3, TotalPrice = 120, OrderDate = Convert.ToDateTime("15/11/2022"), OrderStatus = OrderStatus.Cancelled },
        new OrderDetails() { UserID = "UID1003", MedicineID = "MD105", MedicineCount = 3, TotalPrice = 150, OrderDate = Convert.ToDateTime("15/11/2022"), OrderStatus = OrderStatus.Purchased },
        new OrderDetails() { UserID = "UID1004", MedicineID = "MD102", MedicineCount = 3, TotalPrice = 15, OrderDate = Convert.ToDateTime("15/11/2022"), OrderStatus = OrderStatus.Purchased }
    };
        return orders;
    }

    public void DisplayList(List<UserDetails> users)
    {

        Console.WriteLine($"{new String('-', 60)}\n{"UserID",-10}{"Name",-10}{"City",-10}{"PhoneNumber",-12}{"Balance"}\n{new String('-', 60)}");
        users.ForEach(x => Console.WriteLine($"{x.UserID,-10}{x.Name,-10}{x.City,-10}{x.PhoneNumber,-12}{x.WalletBalance,-10}"));
        Console.WriteLine(new String('-', 60) + "\n");
    }

    public void DisplayList(List<MedicineDetails> medicineDetails)
    {
        Console.WriteLine($"{new String('-', 60)}\n{"MedicineID",-12}{"MedicineName",-15}{"AvailableCount",-15}{"Price",-10}{"DateOfExpiry",-12}\n{new String('-', 60)}");
        medicineDetails.ForEach(x => Console.WriteLine($"{x.MedicineID,-12}{x.MedicineName,-15}{x.AvailableCount,-15}{x.Price,-10}{x.DateOfExpiry.ToShortDateString(),-12}"));
        Console.WriteLine(new String('-', 60) + "\n");
    }

    public void DisplayList(List<OrderDetails> orders)
    {
        Console.WriteLine($"{new String('-', 80)}\n{"OrderID",-10}{"UserID",-10}{"MedicineID",-12}{"MedicineCount",-15}{"TotalPrice",-12}{"OrderDate",-12}{"OrderStatus",-12}\n{new String('-', 80)}");
        orders.ForEach(x => Console.WriteLine($"{x.OrderID,-10}{x.UserID,-10}{x.MedicineID,-12}{x.MedicineCount,-15}{x.TotalPrice,-12}{x.OrderDate.ToShortDateString(),-12}{x.OrderStatus,-12}"));
        Console.WriteLine(new String('-', 80) + "\n");
    }
}