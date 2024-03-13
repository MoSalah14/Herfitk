using AutoMapper;
using Herfitk.API.DTO;
using Herfitk.Core.Repository;
using Herfitk.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Herfitk.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HerifyController : ControllerBase
    {
        private readonly IHerifyRepository repository;
        private readonly IMapper mapper;

        public HerifyController(IHerifyRepository genericRepository, IMapper mapper)
        {
            repository = genericRepository;
            this.mapper = mapper;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (ModelState.IsValid)
            {
                var herify = await repository.GetByIdAsyncWithInclude(id);
                if (herify == null)
                    return NotFound();

                return Ok(mapper.Map<Herfiy, HerfiyDto>(herify));
            }
            else
                return BadRequest();
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(Herfiy herify)
        {
            if (ModelState.IsValid)
            {
                var entity = await repository.AddAsync(herify);
                //string url = Url.Action(nameof(GetById), new { id = herify.Id });
                //return Created(url, new { herify, Message = "Added" });
                return Ok(entity);
            }
            else
                return BadRequest(ModelState);
        }


        [HttpPut("update")]
        public async Task<IActionResult> Update(Herfiy herify, [FromHeader] int id)
        {
            if (ModelState.IsValid)
            {
                var entity = await repository.UpdateAsync(herify, id);
                return StatusCode(204, new { message = "Updated", entity });
            }
            return BadRequest(ModelState);
        }


    }
}
