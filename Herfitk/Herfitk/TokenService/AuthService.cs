using Herfitk.API.Dto;
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
        public string GenerateTokinString(LoginDto login)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email,login.Email),
                new Claim(ClaimTypes.Role,"Admin")
            };

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
