using System;

namespace SyncMart;

public class OrderDetails
{
    public string OrderID { get; set; } = String.Empty;
    public string CustomerID { get; set; } = String.Empty;
    public string ProductID { get; set; } = String.Empty;

    public int TotalPrice { get; set; }
    public DateTime PurchaseDate { get; set; }
    public int Quantity { get; set; }
    public OrderStatus Status { get; set; }
    

}
