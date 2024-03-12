using Herfitk.Core.Repository;
using Herfitk.Repository.Data.DbContextBase;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herfitk.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly HerfitkContext _context;
        
        public GenericRepository(HerfitkContext context)
        {
            _context = context;
        }

        public T ADD(T name)
        {
           
             _context.Set<T>().Add(name);
            _context.SaveChanges();
            return name;
        }

        public T DELETE(int id)
        {
            T entity = _context.Set<T>().Find(id);
            if (entity == null) {
                _context.Set<T>().Remove(entity);
                _context.SaveChanges();
                return entity;
            }
            else
            {
                return null;
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {   
            return await _context.Set<T>().FindAsync(id);
        }

        public T UPDATE(T entity,int id)
        {
            T oldentity = _context.Set<T>().Find(id);
            oldentity = entity;
                _context.Set<T>().Update(oldentity);
                _context.SaveChanges();
                return entity;
          
        }

      
    }
}
