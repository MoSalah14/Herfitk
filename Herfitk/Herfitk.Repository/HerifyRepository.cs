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
    public class HerifyRepository : GenericRepository<Herfiy>, IHerifyRepository
    {
        private readonly HerfitkContext context;

        public HerifyRepository(HerfitkContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<Herfiy> GetByIdAsyncWithInclude(int id)
        {
            var getData = await context.Herfiys
                                .Include(x => x.HerfiyUser)
                                .Include(x => x.ClientHerifies)
                                .Include(x => x.Payments)
                                .FirstOrDefaultAsync(e => e.Id == id);
            return getData;
        }

        //public async Task<Herfiy> GetByIdAsyncWithInclude(int id)
        //{
        //    var GetWithInclude = await context.Herfiys.Include(e => e.User).FirstOrDefaultAsync(e => e.Id == id);

        //    return GetWithInclude;
        //}
    }
}
