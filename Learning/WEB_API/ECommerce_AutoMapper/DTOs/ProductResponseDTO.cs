using System;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models;

public class ProductResponseDTO
{
    public int ProductID { get; set; }
    public string CategoryName { get; set; } = String.Empty;
    public string ProductName { get; set; } = String.Empty;
    public decimal Price { get; set; }
    public int Count { get; set; }
    public string Description { get; set; } = String.Empty;
}
