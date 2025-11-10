using System.Collections.Generic;
using System;

namespace Core.Application.Persistence.Repositories
{
    public interface IRepository<T> where T : class
    {
        T Add(T entity);
        void Delete(T entity);
        T Update(T entity);
        T Get(Func<T, bool> predicate);
        IEnumerable<T> GetAll();
    }
}
