using Herfitk.API.Dto;
using Herfitk.Core.Models;
//using Herfitk.Repository.Data.DbContextBase;
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

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
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
            {
                return BadRequest(result.Errors);
            }

            return Ok(result);
        }
    }
}



