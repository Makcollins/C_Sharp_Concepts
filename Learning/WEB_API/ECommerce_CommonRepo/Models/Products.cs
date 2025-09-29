using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Models;

public class Products
{
    [Key]
    public int ProductID { get; set; }

    public string ProductName { get; set; } = String.Empty;
    public decimal Price { get; set; }
    public int Count { get; set; }
    public string Description { get; set; } = String.Empty;
    //creating relationship with category Model
    // we have to include category id property
    public int CategoryID { get; set; }

    //Since One category can have several products:
    public virtual Category? Category { get; set; }
    //creating relationship with Cart Model
    public virtual Cart? Cart { get; set; }
    public virtual Payment? Payment { get; set; }
}
