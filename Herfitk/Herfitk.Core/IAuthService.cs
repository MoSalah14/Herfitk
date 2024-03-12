using Herfitk.Core.Models.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herfitk.Core
{
    public interface IAuthService
    {
        Task<string> CreateTokenAsync(AppUser appUser,UserManager<AppUser> userManager);
    }
}
