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

    //creating relationship with the products Model
    //one payment can contain several products
    //so we need to get a collection of products model
    public virtual ICollection<Products>? Products { get; set; }
    public virtual User? User { get; set; }
}
