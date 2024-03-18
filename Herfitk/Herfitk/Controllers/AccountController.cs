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
        public async Task<IActionResult> Register(RegisterDto model, IFormFile nationalIdImage, IFormFile personalImage)
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
            if (nationalIdImage != null && nationalIdImage.Length > 0)
            {
                var uploadsDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Uploads Photos");
                if (!Directory.Exists(uploadsDirectory))
                    Directory.CreateDirectory(uploadsDirectory);

                var uniqueFileName = Guid.NewGuid().ToString() + "_" + nationalIdImage.FileName;
                var filePath = Path.Combine(uploadsDirectory, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                    await nationalIdImage.CopyToAsync(fileStream);
                

                user.NationalIdImage = "/Uploads Photos/" + uniqueFileName; // Assuming NationalIdImage is the property to store the image path
            }

            // Handle Personal Image Upload
            if (personalImage != null && personalImage.Length > 0)
            {
                var uploadsDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Uploads Photos");
                if (!Directory.Exists(uploadsDirectory))
                    Directory.CreateDirectory(uploadsDirectory);
                

                var uniqueFileName = Guid.NewGuid().ToString() + "_" + personalImage.FileName;
                var filePath = Path.Combine(uploadsDirectory, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                    await personalImage.CopyToAsync(fileStream);

                user.PersonalImage = "/Uploads Photos/" + uniqueFileName; // Assuming PersonalImage is the property to store the image path
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

