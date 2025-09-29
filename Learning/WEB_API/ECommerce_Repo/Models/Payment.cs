using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Models;

public class Payment
{
    [Key]
    public int PaymentID { get; set; }

    [ForeignKey(nameof(ProductID))]
    public int ProductID { get; set; }

    [ForeignKey(nameof(UserID))]
    public int UserID { get; set; }
    public int Quantity { get; set; }
    public int Amount { get; set; }
    public DateTime PaymentDate { get; set; }

    // public Products Products { get; set; }
    // public User User{ get; set; }
}
