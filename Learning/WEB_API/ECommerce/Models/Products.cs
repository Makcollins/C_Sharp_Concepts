using System;

namespace ECommerce.Models;

public class Products
{
    public int ProductID { get; set; }
    public int CategoryID { get; set; }
    public int UserID { get; set; }
    public string ProductName { get; set; }
    public decimal Price { get; set; }
    public int Count { get; set; }
    public string Description { get; set; }
}
