using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace Core.Application.Persistence.Repositories
{
    public interface IAsyncRepository<T> where T : class
    {
        Task<T> AddAsync(T entity);
        Task<T> GetAsync(Func<T, bool> predicate);
        Task<List<T>> GetAllAsync();
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
