using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Herfitk.Core.Models.Data;
using Herfitk.Core.Repository;
using AutoMapper;
using Herfitk.API.DTO;

namespace Herfitk.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientHerifiesController : ControllerBase
    {
        private readonly IGenericRepository<ClientHerify> repository;
        private readonly IMapper mapper;

        public ClientHerifiesController(IGenericRepository<ClientHerify> repository,IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }


        [HttpGet("GetAll/{id}")]
        public async Task<IActionResult> GetClientHerifies(int id)
        {
            var GetAll = await repository.GetAllAsync();
            var GetALlByID = GetAll.Where(x => x.HerifyId == id);
           var MapData =  mapper.Map<List<Herify_ReviewDto>>(GetALlByID);

            return Ok(MapData);
        }

        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetClientHerify(int id)
        //{
        //    var clientHerify = await repository.GetByIdAsync(id);

        //    if (clientHerify == null)
        //        return NotFound();

        //    var GetReview = mapper.Map<Herify_ReviewDto>(clientHerify);
        //    return Ok(GetReview);
        //}


        //[HttpPut("Update/{id}")]
        //public async Task<IActionResult> PutClientHerify(int id, ClientHerify clientHerify)
        //{
        //    try
        //    {
        //        await repository.UpdateAsync(clientHerify, id);
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {  
        //        throw new Exception("Error While Updating Please Try Again Later");
        //    }

        //    return NoContent();
        //}


        [HttpPost("Create")]
        public async Task<IActionResult> PostClientHerify(Client_ReviewReturnDto clientHerify)
        {
            var MapData = new ClientHerify
            {
                HerifyId = clientHerify.HerifyID,
                ClientId = clientHerify.ClientId,
                ClientReview = clientHerify.Review,
                Date = clientHerify.ReviewDate,
                Rate = clientHerify.Rate
            };
            // Create Get Client ID By User ID
            var CreateReview = await repository.AddAsync(MapData);
            return Ok(CreateReview);
        }


        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteClientHerify(int id)
        {
            var clientHerify = await repository.DeleteAsync(id);
            if (clientHerify == null)
                return NotFound();

            return NoContent();
        }


    }
}
