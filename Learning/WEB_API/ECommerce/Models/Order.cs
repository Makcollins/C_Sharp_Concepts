using System;

namespace ECommerce.Models;

public class Order
{
    public int OrderID { get; set; }
    public int UserID { get; set; }
    public int CartID { get; set; }
    public int Count { get; set; }
}
