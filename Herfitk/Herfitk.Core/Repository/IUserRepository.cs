using Herfitk.Core.Models;
using Microsoft.AspNetCore.Identity;

namespace Herfitk.Core.Repository
{
    public interface IUserRepository : IGenericRepository<AppUser>
    {
        public Task<List<AppUser>> GetAllUserWithInclude();

        public Task<List<IdentityRole<int>>> GetAllRole();
    }
}