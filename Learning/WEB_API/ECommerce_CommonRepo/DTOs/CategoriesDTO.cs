using System;

namespace ECommerce.DTOs;

public class CategoriesDTO
{
    public int CategoryID { get; set; }
    public string CategoryName { get; set; } = String.Empty;
    public string Description { get; set; } = String.Empty;
}
