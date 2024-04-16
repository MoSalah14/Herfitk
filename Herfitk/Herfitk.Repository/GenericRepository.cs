using Herfitk.Core;
using Herfitk.Core.Models.Data;
using Herfitk.Core.Repository;
using Microsoft.EntityFrameworkCore;

namespace Herfitk.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly HerfitkContext _context;

        public GenericRepository(HerfitkContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
            => await _context.Set<T>().ToListAsync();

        public async Task<T?> GetByIdAsync(int id)
             => await _context.Set<T>().FindAsync(id);

        public async Task<T> AddAsync(T name)
        {
            await _context.Set<T>().AddAsync(name);
            return name;
        }

        public async Task Update(T entity, int id)
        {
            T existingEntity = await _context.FindAsync<T>(id);
            if (existingEntity != null)
                _context.Entry(existingEntity).CurrentValues.SetValues(entity);
            else
                throw new ArgumentException($"Entity with ID {id} not found.");
        }

        public async Task Delete(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _context.Remove(entity);
                await _context.SaveChangesAsync();
            }
            else
                throw new ArgumentException($"Entity with ID {id} not found.");
        }

        public async Task<IEnumerable<T>> GetAllWithSpecAsync(ISpecification<T> specification)
            => await SpecificationEvaluator<T>.GetQuery(_context.Set<T>(), specification).ToListAsync();

        public async Task<T?> GetByIdWithSpecAsync(ISpecification<T> specification)
             => await SpecificationEvaluator<T>.GetQuery(_context.Set<T>(), specification).FirstOrDefaultAsync();
    }
}