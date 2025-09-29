using System;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models;

public class CreateProductDTO
{
    [Key]
    public int ProductID { get; set; }
    public int CategoryID { get; set; }
    public string ProductName { get; set; } = String.Empty;
    public decimal Price { get; set; }
    public int Count { get; set; }
    public string Description { get; set; } = String.Empty;
}
