using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Models;

public class Cart
{
    [Key]
    public int CartID { get; set; }

    [ForeignKey(nameof(ProductID))]
    public int ProductID { get; set; }

    [ForeignKey(nameof(UserID))]
    public int UserID { get; set; }
    public int Count { get; set; }

    // public Products Products { get; set; }
    // public User User { get; set; }
}
