using Microsoft.EntityFrameworkCore;
using SV.Domain.Entities;
using SV.Infrastructure.Persistences.Contexts;
using SV.Infrastructure.Persistences.Interfaces;
using System.Linq.Expressions;

namespace SV.Infrastructure.Persistences.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly SVContext _context;
        private readonly DbSet<T> _entity;

        public GenericRepository(SVContext context)
        {
            _context = context;
            _entity = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _entity.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var getById = await _entity!.FirstOrDefaultAsync(e => e.Id.Equals(id))!;

            return getById!;
        }

        public async Task<bool> RegisterAsync(T entity)
        {
            entity.CreatedYear = DateTime.Now.Year;

            await _context.AddAsync(entity);

            var recordsAffected = await _context.SaveChangesAsync();
            return recordsAffected > 0;
        }

        public async Task<bool> EditAsync(T entity)
        {
            _context.Update(entity);

            var recordsAffected = await _context.SaveChangesAsync();

            return recordsAffected > 0;
        }

        public async Task<bool> RemoveAsync(int id)
        {
            T entity = await GetByIdAsync(id);

            _context.Remove(entity);

            var recordsAffected = await _context.SaveChangesAsync();

            return recordsAffected > 0;
        }

        public IQueryable<T> GetEntityQuery(Expression<Func<T, bool>>? filter = null)
        {
            IQueryable<T> query = _entity;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return query;
        }
    }
}
