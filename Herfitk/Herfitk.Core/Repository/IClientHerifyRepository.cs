using Herfitk.Core.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herfitk.Core.Repository
{
    public interface IClientHerifyRepository : IGenericRepository<ClientHerify>
    {
        public Task<IEnumerable<ClientHerify>> GetAllReviewsAsync();
        public Task<Client?> GetClientByIdAsync(int id);
    }
}
