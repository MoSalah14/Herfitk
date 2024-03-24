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
    public class ClientHerifyRepository : GenericRepository<ClientHerify>, IClientHerifyRepository
    {
        private readonly HerfitkContext context;

        public ClientHerifyRepository(HerfitkContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<Client?> GetClientByIdAsync(int id)
        {
            var getClient = await context.Clients.FirstOrDefaultAsync(e => e.UserId == id);
            return getClient;
        }

        public async Task<IEnumerable<ClientHerify>> GetAllReviewsAsync()
        {
            var GetData = await context.ClientHerifies.Include(e => e.Client.ClientUser).ToListAsync();
            return GetData;
        }
    }
}
