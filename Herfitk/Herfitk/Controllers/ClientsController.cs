using AutoMapper;
using Herfitk.API.DTO;
using Herfitk.Core;
using Herfitk.Core.Models.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Talabat.API.Errors;

namespace Herfitk.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ClientsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        [HttpGet("All")]
        public async Task<IActionResult> GetClients()
        {
            var Getall = await unitOfWork.Repository<Client>().GetAllAsync();
            var mapClients = mapper.Map<IEnumerable<ClientDto>>(Getall);

            return Ok(mapClients);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetClient(int id)
        {
            var client = await unitOfWork.Repository<Client>().GetByIdAsync(id);

            if (client == null)
                return NotFound();

            var mapClient = mapper.Map<ClientDto>(client);

            return Ok(mapClient);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateClient(int id, ClientDto client)
        {
            try
            {
                var existingClient = await unitOfWork.Repository<Client>().GetByIdAsync(id);

                if (existingClient == null)
                    return NotFound();

                existingClient.History = client.History;
                existingClient.Review = client.Review;

                await unitOfWork.Repository<Client>().UpdateAsync(existingClient, id);
            }
            catch (DbUpdateConcurrencyException)
            {
                return new BadRequestObjectResult(new ApiResponse(400, "Error While Update"));
            }

            return NoContent();
        }

        [HttpPost("Add")]
        public async Task<ActionResult<Client>> CreateClient(ClientDto client)
        {
            try
            {
                var CientMap = mapper.Map<Client>(client);
                await unitOfWork.Repository<Client>().AddAsync(CientMap);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        // DELETE: api/Clients/5
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteClient(int id)
        {
            var client = await unitOfWork.Repository<Client>().GetByIdAsync(id);
            if (client == null)
                return NotFound();

            await unitOfWork.Repository<Client>().DeleteAsync(id);
            return NoContent();
        }
    }
}