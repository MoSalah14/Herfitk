using AutoMapper;
using Herfitk.API.DTO;
using Herfitk.Core.Models.Data;
using Herfitk.Core.Repository;
using Herfitk.Repository;
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
        //public async Task<IActionResult> Index()
        //{
        //    var getAllSataff = await repository.GetAllStaffIncluding();
        //    var getAllStaffDto = mapper.Map<List<Staff> , List<StaffDto>>(getAllSataff);
        //    return View(getAllStaffDto);

        //}
        public async Task<IActionResult> IndexId(int id)
        {
            var getStaffById = await repository.GetByIdAsync(id);
            var getStaffByIdDto = mapper.Map<Staff, StaffDto>(getStaffById);
            return View(getStaffByIdDto);
        }

        //public async Task<IActionResult> Add()
        //{
        //    return  View(new StaffDto());

        //}
        ////Add Staff 
        //[HttpPost]
        //public async Task<IActionResult> Add(StaffDto staffDto)
        //{
        //    if(staffDto == null)
        //    {
        //        return NotFound();
        //    }
        //    var addStaff = mapper.Map<StaffDto, Staff>(staffDto);
        //    var addNewStaff = await repository.AddAsync(addStaff);
          
        //    return RedirectToAction(nameof(Index));

        //}

    }
}
