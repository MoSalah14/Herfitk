using Herfitk.Core.Repository;
using Herfitk.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Policy;

namespace Herfitk.API.Controllers
{
    public class HerifyController : Controller
    {
        private readonly IGenericRepository<Herfiy> context;
        public HerifyController(IGenericRepository<Herfiy> _context)
        {
            context = _context;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            if(ModelState.IsValid)
            {
                var herify=await context.GetByIdAsync(id);               
                return Ok(herify);                
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost("AddOne")]
        public IActionResult AddOne(Herfiy herify)
        {
            if (ModelState.IsValid)
            {
                var entity = context.ADD(herify);
                //string url = Url.Action(nameof(GetById), new { id = herify.Id });
                //return Created(url, new { herify, Message = "Added" });
                
                return Ok(entity);
            }
            else
            {
                return BadRequest(ModelState);
            }
           
        }
        [HttpPut("update")]
        public IActionResult update(Herfiy herify,[FromHeader]int id)
        { 
            if(ModelState.IsValid) {
                var entity = context.UPDATE(herify, id);
                return StatusCode(204, new { message = "Updated",herify });

            }
            return BadRequest(ModelState);
        }

     
    }
}
