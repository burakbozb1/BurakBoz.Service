using BurakBoz.Core.Repositories;
using BurakBoz.Core.Services;
using BurakBoz.Core.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BurakBoz.Service.Services
{
    public class Service<T> : IService<T> where T : class
    {
        protected readonly IGenericRepository<T> repository;
        protected readonly IUnitOfWork unitOfWork;

        public Service(IGenericRepository<T> repository, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<T> AddAsync(T entity)
        {
            await repository.AddAsync(entity);
            await unitOfWork.CommitAsync();
            return entity;
        }

        public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities)
        {
            await repository.AddRangeAsync(entities);
            await unitOfWork.CommitAsync();
            return entities;
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
            return await repository.AnyAsync(expression);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await repository.GetAll().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await repository.GetByIdAsync(id);
        }

        public async Task RemoveAsync(T entity)
        {
            repository.Remove(entity);
            await unitOfWork.CommitAsync();
        }

        public async Task RemoveRangeAsync(IEnumerable<T> entities)
        {
            repository.RemoveRange(entities);
            await unitOfWork.CommitAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            repository.Update(entity);
            await unitOfWork.CommitAsync();
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            return repository.Where(expression);
        }
    }
}
