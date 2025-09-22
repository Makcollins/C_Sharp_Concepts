using System;

namespace MedicalStore;

public class OrderDetails(string userID,string medicineID,int medicineCount,decimal totalPrice,DateTime orderDate,OrderStatus orderStatus)
{
    public string OrderID { get; } = $"OID{counter++}";
    public string UserID { get; set; } = userID;
    public string? MedicineID { get; set; } = medicineID;
    public int MedicineCount { get; set; } = medicineCount;
    public decimal TotalPrice { get; set; } = totalPrice;
    public DateTime OrderDate { get; set; } = orderDate;
    public OrderStatus OrderStatus { get; set; } = orderStatus;

    static int counter = 2001;

    // public OrderDetails()
    // {
    //     OrderID = $"OID{counter}";
    // }
}

public enum OrderStatus
{
    Purchased, Cancelled
}