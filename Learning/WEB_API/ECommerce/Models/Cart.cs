using System;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models;

public class Cart
{
    [Key]
    public int CartID { get; set; }
    public int ProductID { get; set; }
    public int UserID { get; set; }
    public int Count{ get; set; }
}
