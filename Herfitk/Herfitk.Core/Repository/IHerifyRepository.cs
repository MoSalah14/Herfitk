using Herfitk.Core.Models.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herfitk.Core.Repository
{
    public interface IHerifyRepository : IGenericRepository<Herfiy>
    {
        public Task<Herfiy> GetByIdAsyncWithInclude(int id);
        public Task<int?> GetLastHerifyIdAsync();
        public Task<List<Herfiy>> GetAllHerfyIncluding();
    }
}
