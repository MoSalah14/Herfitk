using Herfitk.Core.Models;
using Microsoft.AspNetCore.Identity;

namespace Herfitk.API.TokenService
{
    public interface IAuthService
    {
        public Task<string> GenerateTokinString(AppUser user, UserManager<AppUser> userManager);
    }
}