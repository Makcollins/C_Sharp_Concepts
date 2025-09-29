using System;
using ECommerce.Data;
using ECommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Repository;

public class ProductRepository : IProductRepository
{
    private readonly EcommerceDBContext _context;
    public ProductRepository(EcommerceDBContext context)
    {
        _context = context;
    }
    public async Task<int> CreateAsync(Products product)
    {
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
        return product.ProductID; 
    }

    public async Task DeleteAsync(int id)
    {
        var productToDelete = await _context.Products.FindAsync(id);
        if (productToDelete == null)
            throw new ArgumentNullException($"No product found with ID {id} ");
        _context.Products.Remove(productToDelete);
        await _context.SaveChangesAsync(); 
    }

    public async Task<List<Products>> GetAllAsync()
    {
        return await _context.Products.ToListAsync();
    }

    public async Task<Products> GetByIDAsync(int id)
    {
        return await _context.Products.FindAsync(id);
    }

    public async Task UpdateAsync(Products product)
    {
        _context.Update(product);

        await _context.SaveChangesAsync();
    }
}
