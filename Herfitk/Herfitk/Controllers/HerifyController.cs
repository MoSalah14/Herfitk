using AutoMapper;
using Herfitk.API.DTO;
using Herfitk.Core;
using Herfitk.Core.Models.Data;
using Microsoft.AspNetCore.Mvc;

namespace Herfitk.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HerifyController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public HerifyController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        [HttpGet("AllHerfiy")]
        public async Task<IActionResult> GetAllHerfiys()
        {
            if (ModelState.IsValid)
            {
                var alldata = await unitOfWork.herifyRepository.GetAllAsync();
                var mappedData = alldata.Select(item => mapper.Map<Herfiy, HerfiyReturnDto>(item));
                return Ok(mappedData);
            }
            return BadRequest(ModelState);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (ModelState.IsValid)
            {
                var herify = await unitOfWork.herifyRepository.GetByIdAsyncWithInclude(id);
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
                var HerifyUser = new Herfiy
                {
                    History = herify.History,
                    Speciality = herify.Speciality,
                    Zone = herify.Zone,
                    UserId = herify.HerifyUserId
                };

                if (herify.Image != null && herify.Image.Length > 0)
                {
                    var currentDirectory = Directory.GetCurrentDirectory();
                    var herfitkDirectory = Path.Combine(currentDirectory, "..", "..", "..", "..", "GitHub", "Herfitk");
                    var wwwrootUploadsDirectory = Path.Combine(herfitkDirectory, "Herfitk", "Herfitk_Dashboard", "wwwroot", "HerifyImage");
                    var assetsUploadsDirectory = Path.Combine(herfitkDirectory, "front-end", "Herfitk", "src", "assets", "HerifyImage");

                    if (!Directory.Exists(wwwrootUploadsDirectory))
                        Directory.CreateDirectory(wwwrootUploadsDirectory);

                    if (!Directory.Exists(assetsUploadsDirectory))
                        Directory.CreateDirectory(assetsUploadsDirectory);

                    var uniqueFileName = Guid.NewGuid().ToString() + "_" + herify.Image.FileName;
                    var wwwrootFilePath = Path.Combine(wwwrootUploadsDirectory, uniqueFileName);
                    var assetsFilePath = Path.Combine(assetsUploadsDirectory, uniqueFileName);

                    using (var wwwrootFileStream = new FileStream(wwwrootFilePath, FileMode.Create))
                    using (var assetsFileStream = new FileStream(assetsFilePath, FileMode.Create))
                    {
                        await herify.Image.CopyToAsync(wwwrootFileStream);
                        await herify.Image.CopyToAsync(assetsFileStream);
                    }

                    HerifyUser.Image = "/HerifyImage/" + uniqueFileName; // Assuming PersonalImage is the property to store the image path
                }

                var entity = await unitOfWork.herifyRepository.AddAsync(HerifyUser);
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
                var existingEntity = await unitOfWork.herifyRepository.GetByIdAsync(id);

                if (existingEntity == null)
                    return NotFound();

                mapper.Map(herify, existingEntity);
                await unitOfWork.herifyRepository.UpdateAsync(existingEntity, id);

                return Ok();
            }
            return BadRequest(ModelState);
        }

        [HttpGet("lastId")]
        public async Task<IActionResult> GetLastHerify()
        {
            var getLastHerifyID = await unitOfWork.herifyRepository.GetLastHerifyIdAsync();
            return Ok(getLastHerifyID);
        }
    }
}