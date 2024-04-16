using Herfitk.Core.Models.Data;
using Herfitk.Core.Repository;
using Microsoft.EntityFrameworkCore;

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

        public async Task<List<Herfiy>> GetAllHerfyIncluding()
        {
            var getData = await context.Herfiys
                                .Include(x => x.HerfiyUser)
                                .Include(x => x.ClientHerifies)
                                .Include(x => x.Payments).ToListAsync();

            return getData;
        }

        public async Task<int?> GetLastHerifyIdAsync()
        {
            var lastHerfiy = await context.Herfiys.OrderByDescending(e => e.Id).FirstOrDefaultAsync();
            return lastHerfiy?.Id;
        }
    }
}