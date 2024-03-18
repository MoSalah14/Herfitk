using Herfitk.Core.Models.Data;
using Herfitk.Core.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herfitk.Repository
{
    public class HerifyCategoriesRepository : GenericRepository<HerifyCategory>, IHerifyCategoriesRepository
    {
        private readonly HerfitkContext context;

        public HerifyCategoriesRepository(HerfitkContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<List<HerifyCategory>> GetAllHerfiyWithIncludeAsync()
        {
            return await context.HerifyCategories.Include(e => e.Herify)
                    .Include(e => e.Category)
                    .ToListAsync();


        }
    }
}
