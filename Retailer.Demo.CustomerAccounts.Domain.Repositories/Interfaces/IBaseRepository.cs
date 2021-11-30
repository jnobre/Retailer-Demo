using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Retailer.Demo.CustomerAccounts.Domain.Entities;

namespace Retailer.Demo.CustomerAccounts.Domain.Repositories.Interfaces
{
    public interface IBaseRepository<T> where T : IEntity
    {
        Task<T> CreateAsync(T entity);
        Task<IReadOnlyCollection<T>> GetAllAsync();
        Task<IReadOnlyCollection<T>> GetAllAsync(Expression<Func<T, bool>> filter);
        Task<T> GetAsync(string id);
        Task<T> GetAsync(Expression<Func<T, bool>> filter);
        Task RemoveAsync(string id);
        Task<T> UpdateAsync(T entity);
    }
}