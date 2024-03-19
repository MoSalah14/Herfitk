using Herfitk.API.Dto;

namespace Herfitk.API.TokenService
{
    public interface IAuthService
    {
        public string GenerateTokinString(LoginDto login);
    }
}
