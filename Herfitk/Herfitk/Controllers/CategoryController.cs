using Herfitk.Models;
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
        private readonly HerfitkContext context;

        public CategoryController(HerfitkContext _context)
        {
            context = _context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            if (ModelState.IsValid)
            {
                var alldata = context.Categories.ToList();
                return Ok(alldata);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpGet("{id:int}")]
        public IActionResult GetOne(int id)
        {
            if (ModelState.IsValid)
            {
                var onecatergory = context.Categories.Find(id);
                return Ok(onecatergory);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPost]
        public IActionResult AddCategory(Category cat)
        {
            if (ModelState.IsValid)
            {
                context.Categories.Add(cat);
                context.SaveChanges();
                string url = Url.Action(nameof(GetOne), new { id = cat.Id });
                return Created(url, new { Category = cat, Message = "Added" });
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut]
        public IActionResult Edit(Category cat1,[FromHeader]int id)
        {
            if (ModelState.IsValid)
            {
                Category oldcat = context.Categories.Find(id);
                if (oldcat != null)
                {
                    oldcat.Type = cat1.Type;
                    context.SaveChanges();
                }
                return StatusCode(204, new { message = "Updated", oldcat = cat1 });
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpDelete("{id:int}")]
        public IActionResult Remove([FromHeader]int id)
        {
            Category cat = context.Categories.Find(id);
            if (cat != null)
            {
                context.Categories.Remove(cat);
                context.SaveChanges();
                return Ok("Deleted This Category");
            }
            else
            {
                return NotFound();
            }
        }



    }
}
