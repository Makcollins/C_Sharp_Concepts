using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Models;

public class Cart
{
    [Key]
    public int CartID { get; set; }

    public int ProductID { get; set; }

    public int UserID { get; set; }
    public int Count { get; set; }

    public virtual ICollection<Products>? Products { get; }
    public virtual User? User { get; set; }
    public virtual ICollection<Order>? Orders { get;}
}
