using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Herfitk.Core.Models.Data;

namespace Herfitk.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HerifyCategoriesController : ControllerBase
    {
        private readonly HerfitkContext _context;

        public HerifyCategoriesController(HerfitkContext context)
        {
            _context = context;
        }

        // GET: api/HerifyCategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HerifyCategory>>> GetHerifyCategories()
        {
            return await _context.HerifyCategories.ToListAsync();
        }

        // GET: api/HerifyCategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HerifyCategory>> GetHerifyCategory(int id)
        {
            var herifyCategory = await _context.HerifyCategories.FindAsync(id);

            if (herifyCategory == null)
            {
                return NotFound();
            }

            return herifyCategory;
        }

        // PUT: api/HerifyCategories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHerifyCategory(int id, HerifyCategory herifyCategory)
        {
            if (id != herifyCategory.CategoryId)
            {
                return BadRequest();
            }

            _context.Entry(herifyCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HerifyCategoryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/HerifyCategories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HerifyCategory>> PostHerifyCategory(HerifyCategory herifyCategory)
        {
            _context.HerifyCategories.Add(herifyCategory);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (HerifyCategoryExists(herifyCategory.CategoryId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetHerifyCategory", new { id = herifyCategory.CategoryId }, herifyCategory);
        }

        // DELETE: api/HerifyCategories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHerifyCategory(int id)
        {
            var herifyCategory = await _context.HerifyCategories.FindAsync(id);
            if (herifyCategory == null)
            {
                return NotFound();
            }

            _context.HerifyCategories.Remove(herifyCategory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HerifyCategoryExists(int id)
        {
            return _context.HerifyCategories.Any(e => e.CategoryId == id);
        }
    }
}
