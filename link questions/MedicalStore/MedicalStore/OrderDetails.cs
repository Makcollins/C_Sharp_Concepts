using System;

namespace MedicalStore;

public class OrderDetails
{
    public string OrderID { get; set; }
    public string? UserID { get; set; }
    public string? MedicineID { get; set; }
    public int MedicineCount { get; set; }
    public decimal TotalPrice { get; set; }
    public DateTime OrderDate { get; set; }
    public OrderStatus OrderStatus { get; set; }

    static int counter = 2001;

    public OrderDetails()
    {
        OrderID = $"OID{counter}";
    }
}

public enum OrderStatus
{
    Purchased, Cancelled
}