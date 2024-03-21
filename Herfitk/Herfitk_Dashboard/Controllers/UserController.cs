using AutoMapper;
using Herfitk.API.Dto;
using Herfitk.Core.Models;
using Herfitk.Core.Models.Data;
using Herfitk.Core.Repository;
using Herfitk_Dashboard.Models;
using Microsoft.AspNetCore.Mvc;

namespace Herfitk_Dashboard.Controllers
{
    public class UserController : Controller
    {
        public readonly IGenericRepository<AppUser> repository;
        private readonly IMapper mapper;
        public UserController(IGenericRepository<AppUser> repository , IMapper mapper)
        {
             this.repository = repository;
             this.mapper = mapper;
        }
        public async Task<IActionResult> Index(string searchString)
        {
            try
            {
                var users = await repository.GetAllAsync();

                if (users == null)
                {
                    return NotFound();
                }

                // Filter herifys based on the searchString
                if (!string.IsNullOrEmpty(searchString))
                {
                    users = users.Where(users => users.DisplayName.Contains(searchString)).ToList();

                }
                if (int.TryParse(searchString, out int id))
                {
                    // Redirect to IndexId action if the searchString is a valid ID
                    return RedirectToAction(nameof(IndexId), new { id });
                }
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
                {
                    return NotFound(); // Return 404 Not Found if no Herfiy with the given id is found
                }
                return View(user);
            }
            catch (Exception)
            {
                return Content("Error With Data");
            }
        }

        public IActionResult Add()
        {
            try
            {
                return View(new RegisterViewModel());
            }
            catch
            {
                return Content("Error With Data");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(RegisterViewModel appUser)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    if (appUser != null)
                    {
                        var newUser = new AppUser
                        {
                            DisplayName = appUser.DisplayName,
                            Address = appUser.Address,
                            Email = appUser.Email,
                            UserName = appUser.Email,
                            PhoneNumber = appUser.PhoneNumber,
                            NationalId = appUser.NationalId,
                            UserRoleID = appUser.RoleId,
                            //PersonalImage = registerViewModel.PersonalImage,
                            //NationalIdImage = registerViewModel.NationalIdImage,
                            PasswordHash = appUser.Password
                            
                        };

                        await repository.AddAsync(newUser);

                        return RedirectToAction(nameof(Index));
                    }
                }
                return View(appUser);

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
                var editeUser = await repository.GetByIdAsync(id);
                if (editeUser == null)
                {
                    return NotFound();
                }
                //Continu ....
                //var editeHerifyReturnDto = mapper.Map<Herfiy, HerfiyReturnDto>(editeHerify);
                return View(editeUser);

            }
            catch (Exception)
            {
                return Content("Error With Data");
            }
        }
        [HttpPost]
        public async Task<IActionResult> Edite(int id,RegisterViewModel appUser)
        {
           
            if (ModelState.IsValid)
            {
                try
                {
                    var newRegister = await repository.GetByIdAsync(id);
                    if (appUser == null)
                    {
                        return NotFound();
                    }
                    else 
                    {
                        newRegister.DisplayName = appUser.DisplayName;
                        newRegister.Address = appUser.Address;
                        newRegister.Email = appUser.Email;
                        newRegister.PhoneNumber = appUser.PhoneNumber;
                        newRegister.NationalId = appUser.NationalId;
                        //newRegister.PersonalImage = appUser.PersonalImage;
                        //newRegister.NationalIdImage = appUser.NationalIdImage;
                    }

                    await repository.UpdateAsync(newRegister, id);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception)
                {
                    return Content("Error With Data");
                }
            }

            return View(appUser);
        }
        //Delete User 
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var deleteUser = await repository.DeleteAsync(id);
                if (deleteUser == null)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return Content("Error With Data");
            }
        }

    }
}
