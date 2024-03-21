using Herfitk.Core.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herfitk.Core.Repository
{
    public interface IUserRepository : IGenericRepository<AppUser>
    {
        public  Task<List<AppUser>> GetAllUserWithInclude();
        public  Task<List<IdentityRole<int>>> GetAllRole();
    }
}
