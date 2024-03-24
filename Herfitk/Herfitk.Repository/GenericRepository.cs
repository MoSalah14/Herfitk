using Herfitk.Core.Models.Data;
using Herfitk.Core.Repository;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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
            await _context.SaveChangesAsync();
            return name;
        }

        public async Task<T> UpdateAsync(T entity, int id)
        {
            T existingEntity = await _context.Set<T>().FindAsync(id);
            if (existingEntity != null)
            {
                _context.Entry(existingEntity).CurrentValues.SetValues(entity);
                await _context.SaveChangesAsync();
                return existingEntity;
            }
            return null;
        }

        public async Task<T> DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

    }
}
