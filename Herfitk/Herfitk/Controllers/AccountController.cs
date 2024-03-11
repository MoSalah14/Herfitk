using Herfitk.API.Dto;
using Herfitk.Core.Models.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace Herfitk.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }


        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto login)
        {
            var user = await userManager.FindByEmailAsync(login.Email);
            if (user is null)
                return Unauthorized();

            var result = await signInManager.CheckPasswordSignInAsync(user, login.Password, false);

            if (result.Succeeded is false)
                return Unauthorized();

            return Ok(new UserDto()
            {
                DisplayName = user.DisplayName,
                Email = user.Email,
                Token = "Soon" //await _authService.CreateTokinAsync(user, _userManager)
            });

        }
    }
}
