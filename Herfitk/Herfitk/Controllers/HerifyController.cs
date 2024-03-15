using AutoMapper;
using Herfitk.API.DTO;
using Herfitk.Core.Models.Data;
using Herfitk.Core.Repository;
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

        [HttpGet("HerfiySpeciality")]
        public async Task<IActionResult> GetAllHerafiySpeciality([FromHeader] string type)
        {
            if (ModelState.IsValid)
            {
                var alldata = await repository.GetAllAsync();
                var GetDataWithFIlter = alldata.Where(e => e.Speciality == type).ToList();
                var mappedData = GetDataWithFIlter.Select(item => mapper.Map<Herfiy, HerfiyReturnDto>(item));
                return Ok(mappedData);
            }
            return BadRequest(ModelState);
        }



        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (ModelState.IsValid)
            {
                var herify = await repository.GetByIdAsyncWithInclude(id);
                if (herify == null)
                    return NotFound();

                return Ok(mapper.Map<Herfiy, HerfiyReturnDto>(herify));
            }
            else
                return BadRequest();
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(HerifyDto herify)
        {
            if (ModelState.IsValid)
            {

                var mappedHerify = mapper.Map<HerifyDto, Herfiy>(herify);
                var entity = await repository.AddAsync(mappedHerify);
                //string url = Url.Action(nameof(GetById), new { id = herify.Id });
                //return Created(url, new { herify, Message = "Added" });
                return Ok(entity);
            }
            else
                return BadRequest(ModelState);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(HerifyDto herify, [FromHeader] int id)
        {
            if (ModelState.IsValid)
            {
                var existingEntity = await repository.GetByIdAsync(id);

                if (existingEntity == null)
                    return NotFound();

                mapper.Map(herify, existingEntity);
                var updatedEntity = await repository.UpdateAsync(existingEntity, id);

                return Ok(updatedEntity);
            }
            return BadRequest(ModelState);
        }



    }
}
