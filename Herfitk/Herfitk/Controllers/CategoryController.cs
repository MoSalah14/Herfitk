using Herfitk.Core.Models.Data;
using Herfitk.Core.Repository;
using Microsoft.AspNetCore.Authorization;

//using Herfitk.Repository.Data.DbContextBase;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Herfitk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IGenericRepository<Category> repository;

        public CategoryController( IGenericRepository<Category> repository)
        {
            this.repository = repository;
        }

        //[Authorize]
        [HttpGet("Getall")]
        public async Task<ActionResult> GetAll()
        {
            if (ModelState.IsValid)
            {
                var alldata = await repository.GetAllAsync();
                return Ok(alldata);
            }
            return BadRequest(ModelState);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetOne(int id)
        {
            if (ModelState.IsValid)
            {
                var onecatergory = await repository.GetByIdAsync(id);
                return Ok(onecatergory);
            }
            return BadRequest(ModelState);

        }

        //[HttpPost]
        //public IActionResult Add(Category category)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var newcategory=repository.ADD(category);
        //        return Ok(newcategory);
        //    }
        //    else
        //    {
        //        return BadRequest(ModelState);
        //    }

        //}
        

        
        //[HttpPost]
        //public IActionResult AddCategory(Category cat)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        context.Categories.Add(cat);
        //        context.SaveChanges();
        //        string url = Url.Action(nameof(GetOne), new { id = cat.Id });
        //        return Created(url, new { Category = cat, Message = "Added" });
        //    }
        //    else
        //    {
        //        return BadRequest(ModelState);
        //    }
        //}

        //[HttpPut]
        //public IActionResult Edit(Category cat1, [FromHeader] int id)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        Category oldcat = context.Categories.Find(id);
        //        if (oldcat != null)
        //        {
        //            oldcat.Type = cat1.Type;
        //            context.SaveChanges();
        //        }
        //        return StatusCode(204, new { message = "Updated", oldcat = cat1 });
        //    }
        //    else
        //    {
        //        return BadRequest(ModelState);
        //    }
        //}

        //[HttpDelete("{id:int}")]
        //public IActionResult Remove([FromHeader] int id)
        //{
        //    Category cat = context.Categories.Find(id);
        //    if (cat != null)
        //    {
        //        context.Categories.Remove(cat);
        //        context.SaveChanges();
        //        return Ok("Deleted This Category");
        //    }
        //    else
        //    {
        //        return NotFound();
        //    }
        //}



    }
}
