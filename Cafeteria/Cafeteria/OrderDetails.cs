using System;

namespace Cafeteria;

public class OrderDetails
{
    private static int counter = 1000;
    public string OrderID { get; set; }
    public string? UserID { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal TotalPrice { get; set; }
    public OrderStatus OrderStatus { get; set; }
    public OrderDetails()
    {
        counter++;
        OrderID = $"OID{counter}";
    }
}
public enum OrderStatus {Default, Initiated, Ordered,Cancelled}
