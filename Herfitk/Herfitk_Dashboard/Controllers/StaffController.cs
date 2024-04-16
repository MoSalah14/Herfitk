using AutoMapper;
using Herfitk.Core.Models.Data;
using Herfitk.Core.Repository;
using Herfitk_Dashboard.Models;
using Microsoft.AspNetCore.Mvc;

namespace Herfitk_Dashboard.Controllers
{
    public class StaffController : Controller
    {
        private readonly IStaffRepository repository;
        private readonly IMapper mapper;

        public StaffController(IStaffRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        //Get All Satff
        public async Task<IActionResult> Index(string searchString)
        {
            //var getAllStaffDto = mapper.Map<List<Staff>, List<StaffDto>>(getAllSataff);
            try
            {
                var staff = await repository.GetAllAsync();

                if (staff == null)
                {
                    return NotFound();
                }

                // Filter Staff based on the searchString // Salary
                if (!string.IsNullOrEmpty(searchString))
                {
                    int searchSalary;
                    bool isValidSalary = int.TryParse(searchString, out searchSalary);

                    if (isValidSalary)
                    {
                        staff = staff.Where(s => s.Salary.HasValue && s.Salary == searchSalary).ToList();
                    }
                }
                if (int.TryParse(searchString, out int id))
                {
                    // Redirect to IndexId action if the searchString is a valid ID
                    return RedirectToAction(nameof(IndexId), new { id });
                }
                //Continu Later ****
                // var mappedData = mapper.Map<List<Herfiy>, List<HerfiyReturnDto>>(herifys);

                return View(staff);
            }
            catch (Exception)
            {
                return Content("Error With Data");
            }
        }

        public async Task<IActionResult> IndexId(int id)
        {
            // var getStaffByIdDto = mapper.Map<Staff, StaffDto>(getStaffById);
            try
            {
                var staff = await repository.GetByIdAsync(id);

                if (staff == null)
                {
                    return NotFound(); // Return 404 Not Found if no Herfiy with the given id is found
                }
                // var mappedDataId = mapper.Map<Herfiy, HerfiyReturnDto>(herify);
                return View(staff);
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
                return View(new Staff());
            }
            catch
            {
                return Content("Error With Data");
            }
        }

        //Add Staff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add([Bind("Salary,HireDate,WorkHours,UserId")] StaffViewModel staffViewModel, Staff staff)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (staffViewModel != null)
                    {
                        var newStaff = new Staff
                        {
                            Salary = staffViewModel.Salary,
                            HireDate = staffViewModel.HireDate,
                            WorkHours = staffViewModel.WorkHours,
                            UserId = staffViewModel.UserId
                        };
                        //Must Be Check To 1 or 2 Admin Or Herfy ..........................

                        await repository.AddAsync(newStaff);

                        return RedirectToAction(nameof(Index));
                    }
                }
                return View(staff);
            }
            catch (Exception)
            {
                return Content("Error With Data");
            }
        }

        //Edit Herifys
        public async Task<IActionResult> Edite(int id)
        {
            try
            {
                var editeStaff = await repository.GetByIdAsync(id);
                if (editeStaff == null)
                {
                    return NotFound();
                }
                //Continu .... Map
                return View(editeStaff);
            }
            catch (Exception)
            {
                return Content("Error With Data");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edite(int id, [Bind("Id,UserId,Salary,HireDate,WorkHours")] StaffViewModel staffViewModel, Staff staff)
        {
            if (id != staffViewModel.Id)
                return NotFound();
            if (ModelState.IsValid)
            {
                try
                {
                    var herfyUpdate = await repository.GetByIdAsync(id);
                    if (herfyUpdate == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        herfyUpdate.Salary = staffViewModel.Salary;
                        herfyUpdate.HireDate = staffViewModel.HireDate;
                        herfyUpdate.WorkHours = herfyUpdate.WorkHours;
                        herfyUpdate.UserId = herfyUpdate.UserId;
                    }
                    //Must Be 1 Or 2 Admin Or Staff
                    await repository.UpdateAsync(herfyUpdate, id);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception)
                {
                    return Content("Error With Data");
                }
            }

            return View(staff);
        }

        //Delete Herifys
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var deleteStaff = await repository.DeleteAsync(id);
                if (deleteStaff == null)
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