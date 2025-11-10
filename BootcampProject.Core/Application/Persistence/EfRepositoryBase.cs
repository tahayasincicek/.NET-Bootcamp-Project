using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Runtime.Remoting.Contexts;
using System.Threading.Tasks;
using System;

namespace Core.Application.Persistence.Repositories
{
    public class EfRepositoryBase<TContext, TEntity>
        : IRepository<TEntity>, IAsyncRepository<TEntity>
        where TContext : DbContext
        where TEntity : class
    {
        protected readonly TContext Context;

        public EfRepositoryBase(TContext context)
        {
            Context = context;
        }

        public TEntity Add(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
            Context.SaveChanges();
            return entity;
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await Context.Set<TEntity>().AddAsync(entity);
            await Context.SaveChangesAsync();
            return entity;
        }

        public TEntity Update(TEntity entity)
        {
            Context.Set<TEntity>().Update(entity);
            Context.SaveChanges();
            return entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            Context.Set<TEntity>().Update(entity);
            await Context.SaveChangesAsync();
            return entity;
        }

        public void Delete(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
            Context.SaveChanges();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
            await Context.SaveChangesAsync();
        }

        public TEntity Get(Func<TEntity, bool> predicate)
            => Context.Set<TEntity>().FirstOrDefault(predicate);

        public async Task<TEntity> GetAsync(Func<TEntity, bool> predicate)
            => Context.Set<TEntity>().FirstOrDefault(predicate);

        public IEnumerable<TEntity> GetAll()
            => Context.Set<TEntity>().ToList();

        public async Task<List<TEntity>> GetAllAsync()
            => await Context.Set<TEntity>().ToListAsync();
    }
}
