using System;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models;

public class Category
{
    [Key]
    public int CategoryID { get; set; }
    public string CategoryName { get; set; } = String.Empty;
    public string Description { get; set; } = String.Empty;

    //creating relationship with the products Model
    //one category can contain several products
    //so we need to get a collection of products model
    public virtual ICollection<Products>? Products{ get; set; }
}
