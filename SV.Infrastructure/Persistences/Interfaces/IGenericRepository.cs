﻿using SV.Domain.Entities;
using System.Linq.Expressions;

namespace SV.Infrastructure.Persistences.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAllAsync();

        Task<T> GetByIdAsync(int id);

        Task<bool> RegisterAsync(T entity);

        Task<bool> EditAsync(T entity);

        Task<bool> RemoveAsync(int id);

        IQueryable<T> GetEntityQuery(Expression<Func<T, bool>>? filter = null);
    }
}
