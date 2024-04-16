using Herfitk.Core.Models.Data;

namespace Herfitk.Core.Repository
{
    public interface IHerifyRepository : IGenericRepository<Herfiy>
    {
        public Task<Herfiy> GetByIdAsyncWithInclude(int id);

        public Task<int?> GetLastHerifyIdAsync();

        public Task<List<Herfiy>> GetAllHerfyIncluding();
    }
}