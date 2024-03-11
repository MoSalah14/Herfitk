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

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {   
            return await _context.Set<T>().FindAsync(id);


        }
    }
}
