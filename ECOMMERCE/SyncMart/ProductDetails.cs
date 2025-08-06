using System;

namespace SyncMart;

public class ProductDetails
{
    public string ProductID { get; set; } = String.Empty;
    public string ProductName { get; set; } = String.Empty;

    public int Stock { get; set; }
    public decimal Price { get; set; }
    public int ShippingDuration { get; set; }
}
