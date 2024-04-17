using AutoMapper;
using Herfitk.API.DTO;
using Herfitk.Core;
using Herfitk.Core.Models.Data;
using Herfitk.Core.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace Herfitk.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientHerifiesController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ClientHerifiesController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        [HttpGet("GetAll/{id}")]
        public async Task<IActionResult> GetClientHerifies(int id)
        {
            var spec = new ClientHerifyWithSpec();

            var GetAll = await unitOfWork.Repository<ClientHerify>().GetAllWithSpecAsync(spec);
            var GetALlByID = GetAll.Where(x => x.HerifyId == id);
            var MapData = mapper.Map<List<Herify_ReviewDto>>(GetALlByID);

            return Ok(MapData);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> PostClientHerify(Client_ReviewReturnDto clientHerify)
        {
            var spec = new ClientHerifyWithSpec(clientHerify.ClientId);

            var MapData = new ClientHerify
            {
                HerifyId = clientHerify.HerifyID,
                ClientReview = clientHerify.Review,
                Date = clientHerify.ReviewDate,
                Rate = clientHerify.Rate
            };
            var GetClientID = await unitOfWork.Repository<ClientHerify>().GetByIdWithSpecAsync(spec);

            MapData.ClientId = GetClientID?.Id;

            var CreateReview = await unitOfWork.Repository<ClientHerify>().AddAsync(MapData);
            await unitOfWork.CompleteAsync();
            return Ok(CreateReview);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteClientHerify(int id)
        {
            var spec = new ClientHerifyWithSpec(id);

            var clientHerify = await unitOfWork.Repository<ClientHerify>().GetByIdWithSpecAsync(spec);
            if (clientHerify == null)
                return NotFound();

            await unitOfWork.Repository<ClientHerify>().DeleteAsync(clientHerify.Id);
            await unitOfWork.CompleteAsync();

            return NoContent();
        }
    }
}