using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Models;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScrewsController : ControllerBase
    {
        private readonly ServerContext _context;

        public ScrewsController(ServerContext context)
        {
            _context = context;
        }

        // GET: api/Screws
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Screw>>> GetScrew()
        {
            return await _context.Screw.ToListAsync();
        }

        // GET: api/Screws/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Screw>> GetScrew(int id)
        {
            var screw = await _context.Screw.FindAsync(id);

            if (screw == null)
            {
                return NotFound();
            }

            return screw;
        }

        // PUT: api/Screws/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutScrew(int id, Screw screw)
        {
            if (id != screw.ScrewId)
            {
                return BadRequest();
            }

            _context.Entry(screw).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ScrewExists(id))
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

        // POST: api/Screws
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Screw>> PostScrew(Screw screw)
        {
            _context.Screw.Add(screw);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetScrew", new { id = screw.ScrewId }, screw);
        }

        // DELETE: api/Screws/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteScrew(int id)
        {
            var screw = await _context.Screw.FindAsync(id);
            if (screw == null)
            {
                return NotFound();
            }

            _context.Screw.Remove(screw);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ScrewExists(int id)
        {
            return _context.Screw.Any(e => e.ScrewId == id);
        }
    }
}
