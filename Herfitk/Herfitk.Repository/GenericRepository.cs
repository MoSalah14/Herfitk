using Herfitk.Core.Repository;
using Herfitk.Models;
using Herfitk.Repository.Data.DbContextBase;
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
            T oldentity = await _context.Set<T>().FindAsync(id);
            if (oldentity != null)
            {
                //_context.Set<T>().Update(entity);
                _context.Entry(entity).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return entity;
            }
            return oldentity;
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
