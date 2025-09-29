using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Models;

public class Order
{
    [Key]
    public int OrderID { get; set; }

    public int UserID { get; set; }

    public int CartID { get; set; }
    public int Count { get; set; }

    public virtual User? User { get; set; }
    public virtual Cart? Cart { get; set; }
}
