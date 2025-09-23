using System;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models;

public class Payment
{
    [Key]
    public int PaymentID { get; set; }
    public int ProductID { get; set; }
    public int UserID { get; set; }
    public int Quantity { get; set; }
    public int Amount { get; set; }
    public string PaymentDate { get; set; }
}
