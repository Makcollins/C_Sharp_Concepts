using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Models;

public class Products
{
    [Key]
    public int ProductID { get; set; }

    [ForeignKey(nameof(CategoryID))]
    public int CategoryID { get; set; }
    public string ProductName { get; set; } = String.Empty;
    public decimal Price { get; set; }
    public int Count { get; set; }
    public string Description { get; set; } = String.Empty;

    // public Category Category{ get; set; }
}
