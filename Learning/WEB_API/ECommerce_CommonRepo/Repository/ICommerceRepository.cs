using System;
using System.Linq.Expressions;

namespace ECommerce.Repository;

public interface ICommerceRepository<T>
{
    Task<List<T>> GetAllAsync();
    Task<T> GetOnlyOne(Expression<Func<T, bool>> filter);
    Task<List<T>> GetFiltered(Expression<Func<T, bool>> filter);
    Task UpdateAsync(T record);
    Task<T> CreateAsync(T record);
    Task DeleteAsync(T record);
}
