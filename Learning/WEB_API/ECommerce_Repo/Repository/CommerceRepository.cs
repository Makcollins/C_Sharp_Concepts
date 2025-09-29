using System;
using System.Linq.Expressions;
using ECommerce.Data;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Repository;

public class CommerceRepository<T> : ICommerceRepository<T> where T : class
{
    private readonly EcommerceDBContext _context;
    private DbSet<T> _dbSet;

    public CommerceRepository(EcommerceDBContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }
    public async Task<T> CreateAsync(T record)
    {
        _dbSet.Add(record);
        await _context.SaveChangesAsync();
        return record;
    }

    public async Task DeleteAsync(T record)
    {
        _dbSet.Remove(record);
        await _context.SaveChangesAsync();
    }

    public async Task<List<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<T> GetByIDAsync(Expression<Func<T, bool>> filter)
    {
        return await _dbSet.FindAsync(filter); 
    }

    public async Task UpdateAsync(T record)
    {
        _context.Update(record);

        await _context.SaveChangesAsync();
    }
}
