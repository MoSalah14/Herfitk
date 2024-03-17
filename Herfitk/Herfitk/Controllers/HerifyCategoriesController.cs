using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Herfitk.Core.Models.Data;
using Herfitk.Core.Repository;
using Herfitk.Repository;
using AutoMapper;
using Herfitk.API.DTO;

namespace Herfitk.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HerifyCategoriesController : ControllerBase
    {
        private readonly IGenericRepository<HerifyCategory> context;
        private readonly IMapper mapper;

        public HerifyCategoriesController(IGenericRepository<HerifyCategory> context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        // GET: api/HerifyCategories
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAllHerifyByCatID(int id)
        {
            var GetAll = await context.GetAllAsync();

            var GetAllMapped = GetAll.Select(item => mapper.Map<HerifyCategory, HerifyDto>(item));

            return Ok(GetAllMapped);
        }

        // GET: api/HerifyCategories/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetHerifyCategory(int id) // This Make error Because table is composite primary Key
        {
            var herifyCategory = await context.GetByIdAsync(id);   // This Get one value but must get 2 value

            if (herifyCategory == null)
                return NotFound();


            return Ok(herifyCategory);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHerifyCategory(int id, HerifyCategory herifyCategory)
        {
            if (id != herifyCategory.CategoryId)
                return BadRequest();

            try
            {
                await context.UpdateAsync(herifyCategory, id);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return NoContent();
        }


        [HttpPost]
        public async Task<IActionResult> CreateHerifyCategory(HerifyCategory herifyCategory)
        {
            try
            {
                await context.AddAsync(herifyCategory);
            }
            catch (DbUpdateException)
            {
                throw;
            }

            return CreatedAtAction("GetHerifyCategory", new { id = herifyCategory.CategoryId }, herifyCategory);
        }

        // DELETE: api/HerifyCategories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHerifyCategory(int id)
        {
            var herifyCategory = await context.GetByIdAsync(id);
            if (herifyCategory == null)
                return NotFound();

            await context.DeleteAsync(id);

            return NoContent();
        }

    }
}
