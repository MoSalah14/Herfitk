using Herfitk.Core.Models;
using Herfitk.Core.Models.Data;
using Herfitk.Core.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herfitk.Repository
{
    public class UserRepository : GenericRepository<AppUser>, IUserRepository
    {

        private readonly HerfitkContext context;

        public UserRepository(HerfitkContext context) : base(context)
        {
            this.context = context;
        }
        public async Task<List<AppUser>> GetAllUserWithInclude()
        {
            var getAllUser = await context.Users.Include(e=>e.Role).ToListAsync();
            return getAllUser;
        }

        public async Task<List<IdentityRole<int>>> GetAllRole()
        {
            var getAllUser = await context.Roles.ToListAsync();
            return getAllUser;
        }
    }
}
