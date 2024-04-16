using Herfitk.Core.Models.Data;

namespace Herfitk.Core.Repository
{
    public interface IStaffRepository : IGenericRepository<Staff>
    {
        public Task<List<Staff>> GetAllStaffIncluding();
    }
}