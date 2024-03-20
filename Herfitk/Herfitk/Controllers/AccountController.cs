using Herfitk.API.Dto;
using Herfitk.API.TokenService;
using Herfitk.Core.Models;
using Microsoft.AspNetCore.Authorization;

//using Herfitk.Repository.Data.DbContextBase;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Talabat.API.DTOs;
using Talabat.API.Errors;

namespace Herfitk.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly IAuthService authService;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IAuthService authService)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.authService = authService;
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto login)
        {
            var user = await userManager.FindByEmailAsync(login.Email);
            if (user is null)
                return Unauthorized(new ApiResponse(401, "Invalid email or password."));


            var result = await signInManager.CheckPasswordSignInAsync(user, login.Password, false);

            if (result.Succeeded is false)
                return Unauthorized(new ApiResponse(401, "Invalid email or password."));

            if (result.Succeeded)
            {
                var TokenString = await authService.GenerateTokinString(user, userManager);
                return Ok(new UserDto()
                {
                    DisplayName = user.DisplayName,
                    Email = user.Email,
                    Token = TokenString
                });
            }
            return BadRequest();
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterDto model)
        {
            if (CheckEmailExists(model.Email).Result.Value)
                return BadRequest(new ApiValidationErrorResponse() { Errors = new string[] { "This Email is Already Exist" } });

            var user = new AppUser()
            {
                DisplayName = model.DisplayName,
                Email = model.Email,
                UserName = model.Email,
                PasswordHash = model.Password,
                Address = model.Address,
                PhoneNumber = model.PhoneNumber,
                NationalId = model.NationalId,
                UserRoleID = model.RoleId
            };

            // Handle National ID Image Upload
            if (model.NationalIdImage != null && model.NationalIdImage.Length > 0)
            {
                var currentDirectory = Directory.GetCurrentDirectory();
                var herfitkDirectory = Path.Combine(currentDirectory, "..", "..", "..", "..", "GitHub", "Herfitk");
                var wwwrootUploadsDirectory = Path.Combine(herfitkDirectory, "Herfitk", "Herfitk_Dashboard", "wwwroot", "imageID");
                var assetsUploadsDirectory = Path.Combine(herfitkDirectory, "front-end", "Herfitk", "src", "assets", "imageID");

                if (!Directory.Exists(wwwrootUploadsDirectory))
                    Directory.CreateDirectory(wwwrootUploadsDirectory);

                if (!Directory.Exists(assetsUploadsDirectory))
                    Directory.CreateDirectory(assetsUploadsDirectory);

                var uniqueFileName = Guid.NewGuid().ToString() + "_" + model.NationalIdImage.FileName;
                var wwwrootFilePath = Path.Combine(wwwrootUploadsDirectory, uniqueFileName);
                var assetsFilePath = Path.Combine(assetsUploadsDirectory, uniqueFileName);

                using (var wwwrootFileStream = new FileStream(wwwrootFilePath, FileMode.Create))
                using (var assetsFileStream = new FileStream(assetsFilePath, FileMode.Create))
                {
                    await model.NationalIdImage.CopyToAsync(wwwrootFileStream);
                    await model.NationalIdImage.CopyToAsync(assetsFileStream);
                }

                user.NationalIdImage = "/imageID/" + uniqueFileName; // Assuming NationalIdImage is the property to store the image path
            }

            // Handle Personal Image Upload
            if (model.PersonalImage != null && model.PersonalImage.Length > 0)
            {
                var currentDirectory = Directory.GetCurrentDirectory();
                var herfitkDirectory = Path.Combine(currentDirectory, "..", "..", "..", "..", "GitHub", "Herfitk");
                var wwwrootUploadsDirectory = Path.Combine(herfitkDirectory, "Herfitk", "Herfitk_Dashboard", "wwwroot", "PersonalImage");
                var assetsUploadsDirectory = Path.Combine(herfitkDirectory, "front-end", "Herfitk", "src", "assets", "PersonalImage");

                if (!Directory.Exists(wwwrootUploadsDirectory))
                    Directory.CreateDirectory(wwwrootUploadsDirectory);

                if (!Directory.Exists(assetsUploadsDirectory))
                    Directory.CreateDirectory(assetsUploadsDirectory);

                var uniqueFileName = Guid.NewGuid().ToString() + "_" + model.PersonalImage.FileName;
                var wwwrootFilePath = Path.Combine(wwwrootUploadsDirectory, uniqueFileName);
                var assetsFilePath = Path.Combine(assetsUploadsDirectory, uniqueFileName);

                using (var wwwrootFileStream = new FileStream(wwwrootFilePath, FileMode.Create))
                using (var assetsFileStream = new FileStream(assetsFilePath, FileMode.Create))
                {
                    await model.PersonalImage.CopyToAsync(wwwrootFileStream);
                    await model.PersonalImage.CopyToAsync(assetsFileStream);
                }

                user.PersonalImage = "/PersonalImage/" + uniqueFileName; // Assuming PersonalImage is the property to store the image path
            }

            var result = await userManager.CreateAsync(user, user.PasswordHash);
            if (!result.Succeeded)
                return BadRequest(new ApiResponse(400));


            return Ok(result);
        }



        [Authorize]
        [HttpGet]
        public async Task<ActionResult<UserDto>> GetCurrentUser()
        {
            if (!ModelState.IsValid) return BadRequest();
            var Email = User.FindFirstValue(ClaimTypes.Email);

            var user = await userManager.FindByEmailAsync(Email);

            return Ok(new UserDto()
            {
                DisplayName = user.DisplayName,
                Email = user.Email,
                //Token = await _authService.CreateTokinAsync(user, _userManager)
            });

        }


        [HttpGet("emailexists")]
        public async Task<ActionResult<bool>> CheckEmailExists(string email)
        {
            return await userManager.FindByEmailAsync(email) is not null;
        }

    }
}



