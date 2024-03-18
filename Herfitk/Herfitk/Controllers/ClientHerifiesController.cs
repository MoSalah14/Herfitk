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
    public class ClientHerifiesController : ControllerBase
    {
        private readonly HerfitkContext _context;

        public ClientHerifiesController(HerfitkContext context)
        {
            _context = context;
        }

        // GET: api/ClientHerifies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClientHerify>>> GetClientHerifies()
        {
            return await _context.ClientHerifies.ToListAsync();
        }

        // GET: api/ClientHerifies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClientHerify>> GetClientHerify(int id)
        {
            var clientHerify = await _context.ClientHerifies.FindAsync(id);

            if (clientHerify == null)
            {
                return NotFound();
            }

            return clientHerify;
        }

        // PUT: api/ClientHerifies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClientHerify(int id, ClientHerify clientHerify)
        {
            if (id != clientHerify.Id)
            {
                return BadRequest();
            }

            _context.Entry(clientHerify).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientHerifyExists(id))
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

        // POST: api/ClientHerifies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ClientHerify>> PostClientHerify(ClientHerify clientHerify)
        {
            _context.ClientHerifies.Add(clientHerify);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClientHerify", new { id = clientHerify.Id }, clientHerify);
        }

        // DELETE: api/ClientHerifies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClientHerify(int id)
        {
            var clientHerify = await _context.ClientHerifies.FindAsync(id);
            if (clientHerify == null)
            {
                return NotFound();
            }

            _context.ClientHerifies.Remove(clientHerify);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClientHerifyExists(int id)
        {
            return _context.ClientHerifies.Any(e => e.Id == id);
        }
    }
}
