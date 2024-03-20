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
        private readonly IGenericRepository<AppUser> repository;
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
                return View(new AppUser());
            }
            catch
            {
                return Content("Error With Data");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
       //
        public async Task<IActionResult> Add( AppUser appUser,[ Bind("DisplayName,Address,Email,PhoneNumber,Password,NationalId,RoleId,PersonalImage,NationalIdImage")] RegisterViewModel registerViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (registerViewModel != null)
                    {
                        var newUser = new AppUser
                        {
                            DisplayName = registerViewModel.DisplayName,
                            Address = registerViewModel.Address,
                            Email = registerViewModel.Email,
                            PhoneNumber = registerViewModel.PhoneNumber,
                            NationalId = registerViewModel.NationalId,
                            //RoleId = registerViewModel.RoleId,
                            //PersonalImage = registerViewModel.PersonalImage,
                            //PersonalImage = registerViewModel.NationalIdImage
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
        public async Task<IActionResult> Edite(int id, AppUser appUser , [Bind("DisplayName,Address,Email,PhoneNumber,Password,NationalId,RoleId,PersonalImage,NationalIdImage")] RegisterViewModel registerViewModel)
        {
            //if (id != registerViewModel.Id)
                return NotFound();
            if (ModelState.IsValid)
            {
                try
                {
                    //var registerViewModel = await repository.GetByIdAsync(id);
                    if (registerViewModel == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        registerViewModel.DisplayName = registerViewModel.DisplayName;
                        registerViewModel.Address = registerViewModel.Address;
                        registerViewModel.Email = registerViewModel.Email;
                        registerViewModel.PhoneNumber = registerViewModel.PhoneNumber;
                        registerViewModel.NationalId = registerViewModel.NationalId;
                        registerViewModel.PersonalImage = registerViewModel.PersonalImage;
                        registerViewModel.NationalIdImage = registerViewModel.NationalIdImage;
                    }

                    //await repository.UpdateAsync(registerViewModel, id);
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
