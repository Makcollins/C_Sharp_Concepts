using System;

namespace Cafeteria;

public class CartItem
{
    private static int counter = 101;
    public string ItemID { get; set; }
    public string? OrderID { get; set; }
    public string? FoodID { get; set; }
    public decimal OrderPrice { get; set; }
    public int OrderQuantity { get; set; }

    public CartItem()
    {
        ItemID = $"ITID{counter++}";
    }
}
