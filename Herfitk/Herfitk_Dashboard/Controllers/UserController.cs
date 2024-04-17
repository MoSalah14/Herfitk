using Herfitk.Core.Models;
using Herfitk.Core.Repository;
using Herfitk_Dashboard.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;

namespace Herfitk_Dashboard.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository repository;
        private readonly UserManager<AppUser> userManager;

        public UserController(UserManager<AppUser> userManager, IUserRepository repository)
        {
            this.repository = repository;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Index(string searchString)
        {
            try
            {
                var users = await repository.GetAllUserWithInclude();

                if (users == null)
                    return NotFound();
                // Filter users based on the searchString
                if (!string.IsNullOrEmpty(searchString))
                {
                    // Convert search string to upper case or lower case
                    var searchLower = searchString.ToLower();
                    var searchUpper = searchString.ToUpper();

                    // Filter users based on case-insensitive comparison
                    users = users.Where(user => user.DisplayName.ToLower().Contains(searchLower) ||
                                                 user.DisplayName.ToUpper().Contains(searchUpper)).ToList();
                }

                // Redirect to IndexId action if the searchString is a valid ID
                if (int.TryParse(searchString, out int id))
                    return RedirectToAction(nameof(IndexId), new { id });

                //Continu Later ****
                // var mappedData = mapper.Map<IEnumerable<AppUser>, List<RegisterDto>>(users);

                return View(users);
            }
            catch (Exception)
            {
                return Content("Error With Data");
            }
        }

        public async Task<IActionResult> IndexId(int id)
        {
            try
            {
                var user = await repository.GetByIdAsync(id);
                if (user == null)
                    return NotFound(); // Return 404 Not Found if no Herfiy with the given id is found

                return View(user);
            }
            catch (Exception)
            {
                return Content("Error With Data");
            }
        }

        public async Task<IActionResult> Add()
        {
            try
            {
                var roles = await repository.GetAllRole();
                ViewBag.UserRoleList = new SelectList(roles, "Id", "Name");

                return View(new RegisterViewModel());
            }
            catch
            {
                return Content("Error With Data");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(RegisterViewModel registerViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var existingUser = await userManager.FindByEmailAsync(registerViewModel.Email);

                    if (existingUser != null)
                    {
                        ModelState.AddModelError(nameof(RegisterViewModel.Email), "Email already exists.");
                        return View(registerViewModel);
                    }
                    var newUser = new AppUser
                    {
                        DisplayName = registerViewModel.DisplayName,
                        Address = registerViewModel.Address,
                        Email = registerViewModel.Email,
                        UserName = registerViewModel.Email,
                        PhoneNumber = registerViewModel.PhoneNumber,
                        NationalId = registerViewModel.NationalId,
                        UserRoleID = registerViewModel.RoleId,
                        PasswordHash = registerViewModel.Password
                    };

                    // Handle National ID Image Upload
                    if (registerViewModel.NationalIdImage != null && registerViewModel.NationalIdImage.Length > 0)
                    {
                        var currentDirectory = Directory.GetCurrentDirectory();
                        var herfitkDirectory = Path.Combine(currentDirectory, "..", "..", "..", "..", "GitHub", "Herfitk");
                        var wwwrootUploadsDirectory = Path.Combine(herfitkDirectory, "Herfitk", "Herfitk_Dashboard", "wwwroot", "imageID");
                        var assetsUploadsDirectory = Path.Combine(herfitkDirectory, "front-end", "Herfitk", "src", "assets", "imageID");

                        if (!Directory.Exists(wwwrootUploadsDirectory))
                            Directory.CreateDirectory(wwwrootUploadsDirectory);

                        if (!Directory.Exists(assetsUploadsDirectory))
                            Directory.CreateDirectory(assetsUploadsDirectory);

                        var uniqueFileName = Guid.NewGuid().ToString() + "_" + registerViewModel.NationalIdImage.FileName;
                        var wwwrootFilePath = Path.Combine(wwwrootUploadsDirectory, uniqueFileName);
                        var assetsFilePath = Path.Combine(assetsUploadsDirectory, uniqueFileName);

                        using (var wwwrootFileStream = new FileStream(wwwrootFilePath, FileMode.Create))
                        using (var assetsFileStream = new FileStream(assetsFilePath, FileMode.Create))
                        {
                            await registerViewModel.NationalIdImage.CopyToAsync(wwwrootFileStream);
                            await registerViewModel.NationalIdImage.CopyToAsync(assetsFileStream);
                        }

                        newUser.NationalIdImage = "/imageID/" + uniqueFileName; // Assuming NationalIdImage is the property to store the image path
                    }

                    // Handle Personal Image Upload
                    if (registerViewModel.PersonalImage != null && registerViewModel.PersonalImage.Length > 0)
                    {
                        var currentDirectory = Directory.GetCurrentDirectory();
                        var herfitkDirectory = Path.Combine(currentDirectory, "..", "..", "..", "..", "GitHub", "Herfitk");
                        var wwwrootUploadsDirectory = Path.Combine(herfitkDirectory, "Herfitk", "Herfitk_Dashboard", "wwwroot", "PersonalImage");
                        var assetsUploadsDirectory = Path.Combine(herfitkDirectory, "front-end", "Herfitk", "src", "assets", "PersonalImage");

                        if (!Directory.Exists(wwwrootUploadsDirectory))
                            Directory.CreateDirectory(wwwrootUploadsDirectory);

                        if (!Directory.Exists(assetsUploadsDirectory))
                            Directory.CreateDirectory(assetsUploadsDirectory);

                        var uniqueFileName = Guid.NewGuid().ToString() + "_" + registerViewModel.PersonalImage.FileName;
                        var wwwrootFilePath = Path.Combine(wwwrootUploadsDirectory, uniqueFileName);
                        var assetsFilePath = Path.Combine(assetsUploadsDirectory, uniqueFileName);

                        using (var wwwrootFileStream = new FileStream(wwwrootFilePath, FileMode.Create))
                        using (var assetsFileStream = new FileStream(assetsFilePath, FileMode.Create))
                        {
                            await registerViewModel.PersonalImage.CopyToAsync(wwwrootFileStream);
                            await registerViewModel.PersonalImage.CopyToAsync(assetsFileStream);
                        }

                        newUser.PersonalImage = "/PersonalImage/" + uniqueFileName; // Assuming PersonalImage is the property to store the image path
                    }

                    var result = await userManager.CreateAsync(newUser, registerViewModel.Password);

                    return RedirectToAction(nameof(Index));
                }

                return View(/*appUser*/);
            }
            catch (Exception)
            {
                return Content("Error With Data");
            }
        }

        //Edite User
        public async Task<IActionResult> Edite(int id)
        {
            try
            {
                var EditeUser = await repository.GetByIdAsync(id);
                if (EditeUser == null)
                    return NotFound();

                var roles = await repository.GetAllRole();
                ViewBag.UserRoleList = new SelectList(roles, "Id", "Name");

                var newUser = new RegisterViewModel
                {
                    DisplayName = EditeUser.DisplayName,
                    Address = EditeUser.Address,
                    Email = EditeUser.Email,
                    PhoneNumber = EditeUser.PhoneNumber,
                    NationalId = EditeUser.NationalId,
                    RoleId = EditeUser.UserRoleID,
                };

                return View(newUser);
            }
            catch (Exception)
            {
                return Content("Error With Data");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edite(int id, RegisterViewModel UserView)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var existingUser = await userManager.FindByEmailAsync(UserView.Email);
                    if (existingUser != null && existingUser.Id != id)
                    {
                        ModelState.AddModelError(nameof(RegisterViewModel.Email), "Email already exists.");
                        return View(UserView);
                    }

                    var GetAppUser = await repository.GetByIdAsync(id);
                    if (GetAppUser == null)
                        return NotFound();

                    GetAppUser.DisplayName = UserView.DisplayName;
                    GetAppUser.Address = UserView.Address;
                    GetAppUser.Email = UserView.Email;
                    GetAppUser.PhoneNumber = UserView.PhoneNumber;
                    GetAppUser.NationalId = UserView.NationalId;
                    GetAppUser.UserRoleID = UserView.RoleId;

                    // Handle National ID Image Upload
                    if (UserView.NationalIdImage != null && UserView.NationalIdImage.Length > 0)
                    {
                        var currentDirectory = Directory.GetCurrentDirectory();
                        var herfitkDirectory = Path.Combine(currentDirectory, "..", "..", "..", "..", "GitHub", "Herfitk");
                        var wwwrootUploadsDirectory = Path.Combine(herfitkDirectory, "Herfitk", "Herfitk_Dashboard", "wwwroot", "imageID");
                        var assetsUploadsDirectory = Path.Combine(herfitkDirectory, "front-end", "Herfitk", "src", "assets", "imageID");

                        if (!Directory.Exists(wwwrootUploadsDirectory))
                            Directory.CreateDirectory(wwwrootUploadsDirectory);

                        if (!Directory.Exists(assetsUploadsDirectory))
                            Directory.CreateDirectory(assetsUploadsDirectory);

                        var uniqueFileName = Guid.NewGuid().ToString() + "_" + UserView.NationalIdImage.FileName;
                        var wwwrootFilePath = Path.Combine(wwwrootUploadsDirectory, uniqueFileName);
                        var assetsFilePath = Path.Combine(assetsUploadsDirectory, uniqueFileName);

                        using (var wwwrootFileStream = new FileStream(wwwrootFilePath, FileMode.Create))
                        using (var assetsFileStream = new FileStream(assetsFilePath, FileMode.Create))
                        {
                            await UserView.NationalIdImage.CopyToAsync(wwwrootFileStream);
                            await UserView.NationalIdImage.CopyToAsync(assetsFileStream);
                        }

                        GetAppUser.NationalIdImage = "/imageID/" + uniqueFileName; // Assuming NationalIdImage is the property to store the image path
                    }

                    // Handle Personal Image Upload
                    if (UserView.PersonalImage != null && UserView.PersonalImage.Length > 0)
                    {
                        var currentDirectory = Directory.GetCurrentDirectory();
                        var herfitkDirectory = Path.Combine(currentDirectory, "..", "..", "..", "..", "GitHub", "Herfitk");
                        var wwwrootUploadsDirectory = Path.Combine(herfitkDirectory, "Herfitk", "Herfitk_Dashboard", "wwwroot", "PersonalImage");
                        var assetsUploadsDirectory = Path.Combine(herfitkDirectory, "front-end", "Herfitk", "src", "assets", "PersonalImage");

                        if (!Directory.Exists(wwwrootUploadsDirectory))
                            Directory.CreateDirectory(wwwrootUploadsDirectory);

                        if (!Directory.Exists(assetsUploadsDirectory))
                            Directory.CreateDirectory(assetsUploadsDirectory);

                        var uniqueFileName = Guid.NewGuid().ToString() + "_" + UserView.PersonalImage.FileName;
                        var wwwrootFilePath = Path.Combine(wwwrootUploadsDirectory, uniqueFileName);
                        var assetsFilePath = Path.Combine(assetsUploadsDirectory, uniqueFileName);

                        using (var wwwrootFileStream = new FileStream(wwwrootFilePath, FileMode.Create))
                        using (var assetsFileStream = new FileStream(assetsFilePath, FileMode.Create))
                        {
                            await UserView.PersonalImage.CopyToAsync(wwwrootFileStream);
                            await UserView.PersonalImage.CopyToAsync(assetsFileStream);
                        }

                        GetAppUser.PersonalImage = "/PersonalImage/" + uniqueFileName; // Assuming PersonalImage is the property to store the image path
                    }

                    var result = await userManager.UpdateAsync(GetAppUser);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception)
                {
                    return Content("Error With Data");
                }
            }

            return View(UserView);
        }

        //Delete User
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await repository.DeleteAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return Content("Error With Data");
            }
        }
    }
}