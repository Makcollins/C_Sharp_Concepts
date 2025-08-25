using System;

namespace Cafeteria;

public class FoodDetails
{
    public string FoodID { get; set; }
    public string? FoodName { get; set; }
    public decimal Price { get; set; }
    public int AvailableQuantity { get; set; }
    static int counter = 101;

    public FoodDetails()
    {
        FoodID = $"FID{counter++}";
    }
}
