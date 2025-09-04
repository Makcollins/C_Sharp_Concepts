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
        new MedicineDetails() { MedicineName = "Gelucil", AvailableCount = 3, Price = 40, DateOfExpiry = Convert.ToDateTime("30/04/2026") },
        new MedicineDetails() { MedicineName = "Metrogel", AvailableCount = 5, Price = 50, DateOfExpiry = Convert.ToDateTime("30/12/2025") },
        new MedicineDetails() { MedicineName = "Povidin lodin", AvailableCount = 10, Price = 50, DateOfExpiry = Convert.ToDateTime("30/10/2025") }
    };
        return medicineDetails;
    }

    public List<OrderDetails> OrdersList()
    {
        List<OrderDetails> orders = new()
    {
        new OrderDetails("UID1001", "MD101", 3, 15, Convert.ToDateTime("13/11/2022"), OrderStatus.Purchased ),
        new OrderDetails("UID1001", "MD102", 3, 10, Convert.ToDateTime("13/11/2022"), OrderStatus.Cancelled ),
        new OrderDetails("UID1001", "MD104", 2, 100, Convert.ToDateTime("13/11/2022"), OrderStatus.Purchased ),
        new OrderDetails("UID1002", "MD103", 3, 120, Convert.ToDateTime("15/11/2022"), OrderStatus.Cancelled ),
        new OrderDetails("UID1002", "MD102", 5, 250, Convert.ToDateTime("15/11/2022"), OrderStatus.Purchased),
        new OrderDetails("UID1002", "MD105", 3, 15, Convert.ToDateTime("15/11/2022"), OrderStatus.Purchased )
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