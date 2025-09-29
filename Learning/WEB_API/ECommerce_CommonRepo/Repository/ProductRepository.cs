using System;
using ECommerce.Data;
using ECommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Repository;

public class ProductRepository :CommerceRepository<Products>, IProductRepository
{
    private readonly EcommerceDBContext _context;
    public ProductRepository(EcommerceDBContext context) :base(context)
    {
        _context = context;
    }
    
}
