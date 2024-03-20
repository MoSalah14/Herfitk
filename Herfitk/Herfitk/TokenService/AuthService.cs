using Herfitk.API.Dto;
using Herfitk.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Herfitk.API.TokenService
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration config;

        public AuthService(IConfiguration configuration)
        {
            config = configuration;
        }
        public async Task<string> GenerateTokinString(AppUser user, UserManager<AppUser> userManager)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.Name,user.DisplayName)
            };
            var userRoles = await userManager.GetRolesAsync(user);

            foreach (var role in userRoles)
                claims.Add(new Claim(ClaimTypes.Role, role));

            var securityKey = new SymmetricSecurityKey(new byte[64]);

            var SigninCred = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512);

            var securityToken = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(60),
                issuer: config.GetSection("Jwt:Issuer").Value,
                audience: config.GetSection("Jwt:Audience").Value,
                signingCredentials: SigninCred);

            string TokinString = new JwtSecurityTokenHandler().WriteToken(securityToken);

            return TokinString;

        }
    }
}
