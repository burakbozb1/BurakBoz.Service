using BurakBoz.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BurakBoz.Repository.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {

        protected readonly AppDbContext context;
        private readonly DbSet<T> dbSet;

        public GenericRepository(AppDbContext context)
        {
            this.context = context;
            dbSet = context.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            await dbSet.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await dbSet.AddRangeAsync(entities);
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
            return await dbSet.AnyAsync(expression);
        }

        public IQueryable<T> GetAll()
        {
            return dbSet.AsNoTracking().AsQueryable();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            dbSet.RemoveRange(entities);
        }

        public void Update(T entity)
        {
            dbSet.Update(entity);
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            return dbSet.Where(expression);
        }
    }
}
