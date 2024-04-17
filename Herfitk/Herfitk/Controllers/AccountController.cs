using Herfitk.API.Dto;
using Herfitk.API.DTO;
using Herfitk.API.SendEmail;
using Herfitk.API.TokenService;
using Herfitk.Core.Models;
using Microsoft.AspNetCore.Authorization;

//using Herfitk.Repository.Data.DbContextBase;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using System.Security.Claims;
using System.Text.Encodings.Web;
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
        private readonly IEmailService _emailSender;

        public AccountController
            (UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IAuthService authService, IEmailService emailSender)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.authService = authService;
            _emailSender = emailSender;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto login)
        {
            var user = await userManager.FindByEmailAsync(login.Email);
            if (user is null)
                return Unauthorized(new ApiResponse(401, "Invalid email or password."));

            if (!await userManager.IsEmailConfirmedAsync(user))
                return BadRequest(new ApiResponse(400, "Email not confirmed."));

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
            var existingUser = await userManager.FindByEmailAsync(model.Email);
            if (existingUser != null)
                return BadRequest("This Email is Already Exist");

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

            var token = await userManager.GenerateEmailConfirmationTokenAsync(user);
            var confirmationLink = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, token = token }, Request.Scheme);
            var buttonHtml = $"<a href=\"{confirmationLink}\" style=\"display: inline-block; padding: 10px 20px; background-color: green; color: white; text-decoration: none;\">Click here to confirm email</a>";
            var SendMail = new EmailData
            {
                To = model.Email,
                Subject = "Confirm Your Email",
                //Body = $"Please click the link below to confirm your email :  <a href=\"{confirmationLink}\">{confirmationLink}</a>",
                Body = $"Please {buttonHtml} to confirm your email.",
            };
            _emailSender.SendEmail(SendMail);

            return Ok("Registration successful. Confirmation email sent.");
        }

        [HttpGet("ConfirmEmail")]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(token))
                return BadRequest("User ID or token is invalid.");

            var user = await userManager.FindByIdAsync(userId);
            if (user == null)
                return NotFound("User not found.");

            var result = await userManager.ConfirmEmailAsync(user, token);
            if (result.Succeeded)
                return Ok("Email confirmed successfully.");

            return BadRequest("Email confirmation failed.");
        }

        [HttpPost("ResetPassword")]
        public async Task<IActionResult> ResetPasswod(ResetUserPassword resetUserPassword)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(resetUserPassword.Email);
                if (user != null)
                {
                    resetUserPassword.Token = await userManager.GeneratePasswordResetTokenAsync(user);
                    var result = await userManager.ResetPasswordAsync(user, resetUserPassword.Token, resetUserPassword.NewPassword);
                    if (result.Succeeded)
                        return Ok("Successfully Reset Password");
                    else
                    {
                        var errorMessage = result.Errors.Select(error => error.Description).FirstOrDefault();
                        return BadRequest($"Password reset failed: {errorMessage}");
                    }
                }
            }
            return BadRequest("Invalid Data");
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetCurrentUser()
        {
            if (!ModelState.IsValid) return BadRequest();
            var Email = User.FindFirstValue(ClaimTypes.Email);
            if (!string.IsNullOrEmpty(Email))
            {
                var user = await userManager.FindByEmailAsync(Email);
                if (user != null)
                {
                    return Ok(new UserDto()
                    {
                        DisplayName = user.DisplayName,
                        Email = user.Email,
                    });
                }
            }
            return BadRequest("Email not found");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserByID(int id)
        {
            var user = await userManager.Users.Include(u => u.UserHerify).SingleOrDefaultAsync(u => u.Id == id);
            if (user == null)
                return NotFound(new ApiResponse(404, "User not found."));

            var userProfileDto = new UserProfileDto()
            {
                DisplayName = user.DisplayName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Address = user.Address
            };

            if (user.UserHerify != null)
            {
                userProfileDto.Speciality = user.UserHerify.Speciality;
                userProfileDto.Zone = user.UserHerify.Zone;
            }

            if (!string.IsNullOrEmpty(user.PersonalImage))
                userProfileDto.Image = user.PersonalImage;

            return Ok(userProfileDto);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateUser(int id, UpdateProfileDto register)
        {
            if (ModelState.IsValid)
            {
                var getUser = await userManager.FindByIdAsync(id.ToString());

                if (getUser != null)
                {
                    getUser.Id = id;
                    getUser.DisplayName = register.DisplayName;
                    getUser.Email = register.Email;
                    getUser.PhoneNumber = register.PhoneNumber;
                    getUser.Address = register.Address;
                    getUser.UserName = register.Email;

                    await userManager.UpdateAsync(getUser);
                    return Ok();
                }

                return BadRequest("Failed to update user.");
            }

            return BadRequest(ModelState);
        }
    }
}