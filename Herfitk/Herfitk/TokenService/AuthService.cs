using Herfitk.API.Dto;
using Herfitk.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Herfitk.API.TokenService
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration config;
        private readonly IHttpContextAccessor httpContextAccessor;

        public AuthService(IConfiguration configuration , IHttpContextAccessor httpContextAccessor)
        {
            config = configuration;
            this.httpContextAccessor = httpContextAccessor;
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

            var tokenExpirationMinutes = Convert.ToDouble(config.GetSection("Jwt:TokenExpirationMinutes").Value);
            var expirationTime = DateTime.Now.AddMinutes(tokenExpirationMinutes);
            var securityToken = new JwtSecurityToken(
                claims: claims,
                expires: expirationTime,
                issuer: config.GetSection("Jwt:Issuer").Value,
                audience: config.GetSection("Jwt:Audience").Value,
                signingCredentials: SigninCred);

            string TokinString = new JwtSecurityTokenHandler().WriteToken(securityToken);

            var response = httpContextAccessor.HttpContext.Response;
            response.Cookies.Append("authToken", TokinString, new CookieOptions
            {
                HttpOnly = true, // Ensure HttpOnly for security
                Secure = true, // Secure cookie for HTTPS
                Expires = DateTime.Now.AddMinutes(tokenExpirationMinutes), // Set expiration time
                SameSite = SameSiteMode.Strict // Adjust SameSite attribute as needed
            });

            return TokinString;

        }
    }
}
