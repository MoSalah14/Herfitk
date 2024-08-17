using Herfitk.API.Helpers;
using Herfitk.Core;
using Herfitk.Core.Models.Data;

//using Herfitk.Repository.Data.DbContextBase;
using Microsoft.AspNetCore.Mvc;

namespace Herfitk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IUnitOfWork _UnitOfWork;

        public CategoryController(IUnitOfWork repository)
        {
            _UnitOfWork = repository;
        }

        //[Authorize]
        [Cashed(600)] // Create This Attribute to Check if this Action Executed Before
        [HttpGet("Getall")]
        public async Task<ActionResult> GetAll()
        {
            if (ModelState.IsValid)
            {
                var alldata = await _UnitOfWork.Repository<Category>().GetAllAsync();
                return Ok(alldata);
            }
            return BadRequest(ModelState);
        }

        [Cashed(600)]
        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetCategoryByID(int id)
        {
            if (ModelState.IsValid)
            {
                var onecatergory = await _UnitOfWork.Repository<Category>().GetByIdAsync(id);
                return Ok(onecatergory);
            }
            return BadRequest(ModelState);
        }
    }
}