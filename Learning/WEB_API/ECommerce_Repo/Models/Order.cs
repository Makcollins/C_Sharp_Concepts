using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Models;

public class Order
{
    [Key]
    public int OrderID { get; set; }

    [ForeignKey(nameof(UserID))]
    public int UserID { get; set; }

    [ForeignKey(nameof(CartID))]
    public int CartID { get; set; }
    public int Count { get; set; }

    // public User User { get; set; }
    // public Cart Cart { get; set; }
}
