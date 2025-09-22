using System;

namespace ECommerce.Models;

public class Cart
{
    public int CartID { get; set; }
    public int ProductID { get; set; }
    public int UserID { get; set; }
    public int Count{ get; set; }
}
