using Herfitk.API.Dto;
using Herfitk.Core.Models;
using Herfitk.Core.Models.Identity;
using Herfitk.Repository.Data.DbContextBase;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;

namespace Herfitk.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly HerfitkContext herfitk;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, HerfitkContext herfitk)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.herfitk = herfitk;
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto login)
        {
            var user = await userManager.FindByEmailAsync(login.Email);
            if (user is null)
                return Unauthorized();

            var result = await signInManager.CheckPasswordSignInAsync(user, login.Password, false);

            if (result.Succeeded is false)
                return Unauthorized();

            return Ok("LoginSuccess");

        }


        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterDto model)
        {
            var user = new AppUser()
            {

                DisplayName = model.DisplayName,
                Email = model.Email,
                UserName = model.Email,
                PasswordHash = model.Password,
                Address = model.Address,
                PhoneNumber = model.PhoneNumber,
                NationalId = model.NationalId,
                NationalIdImage = model.NationalIdImage,
                PersonalImage = model.PersonalImage,
                AccountState = "Active"

            };


            var result = await userManager.CreateAsync(user, user.PasswordHash);
            if (result.Succeeded is false) return BadRequest(result.Errors);

            var herfiy = await CreateOrRetrieveHerfiyForAppUser(user);
            return Ok(herfiy);
        }

        private async Task<HerifyAppUser> CreateOrRetrieveHerfiyForAppUser(AppUser user)
        {
            var newHerfiAppUser = new HerifyAppUser
            {
                Id = user.Id,
                DisplayName = user.DisplayName,
                Address = user.Address,
                NationalId = user.NationalId,
                PersonalImage = user.PersonalImage,
                NationalIdImage = user.NationalIdImage,
                AccountState = user.AccountState,
                UserName = user.UserName,
                NormalizedUserName = user.NormalizedUserName,
                Email = user.Email,
                NormalizedEmail = user.NormalizedEmail,
                EmailConfirmed = user.EmailConfirmed,
                PasswordHash = user.PasswordHash,
                SecurityStamp = user.SecurityStamp,
                ConcurrencyStamp = user.ConcurrencyStamp,
                PhoneNumber = user.PhoneNumber,
                PhoneNumberConfirmed = user.PhoneNumberConfirmed,
                TwoFactorEnabled = user.TwoFactorEnabled,
                LockoutEnd = user.LockoutEnd,
                LockoutEnabled = user.LockoutEnabled,
                AccessFailedCount = user.AccessFailedCount
            };

            // Add the new HerfiAppUser to the context and save changes
            await herfitk.AppUser.AddAsync(newHerfiAppUser);
            await herfitk.SaveChangesAsync();

            return newHerfiAppUser;
        }
    }

}

