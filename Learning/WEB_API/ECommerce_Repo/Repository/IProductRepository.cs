using System;
using ECommerce.Models;

namespace ECommerce.Repository;

public interface IProductRepository
{
    Task<List<Products>> GetAllAsync();
    Task<Products> GetByIDAsync(int id);
    Task UpdateAsync(Products product);
    Task<int> CreateAsync(Products product);
    Task DeleteAsync(int id);

}
