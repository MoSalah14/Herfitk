using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Herfitk.Core.Models.Data;
using Herfitk.Core.Repository;
using System.Net.Sockets;
using Talabat.API.Errors;
using AutoMapper;
using Herfitk.API.DTO;

namespace Herfitk.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {

        private readonly IGenericRepository<Client> repository;
        private readonly IMapper mapper;

        public ClientsController(IGenericRepository<Client> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        
        [HttpGet("All")]
        public async Task<IActionResult> GetClients()
        {
            var Getall = await repository.GetAllAsync();
            var mapClients = mapper.Map<IEnumerable<ClientDto>>(Getall);

            return Ok(mapClients);
        }


        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetClient(int id)
        {
            var client = await repository.GetByIdAsync(id);

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
                var existingClient = await repository.GetByIdAsync(id);

                if (existingClient == null)
                    return NotFound();

                existingClient.History = client.History;
                existingClient.Review = client.Review;

                await repository.UpdateAsync(existingClient, id);
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
                await repository.AddAsync(CientMap);
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
            var client = await repository.GetByIdAsync(id);
            if (client == null)
                return NotFound();

            await repository.DeleteAsync(id);
            return NoContent();
        }
    }
}
