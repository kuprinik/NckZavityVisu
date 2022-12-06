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
    public class DataController : ControllerBase
    {
        private readonly ServerContext _context;

        public DataController(ServerContext context)
        {
            _context = context;
        }

        // GET: api/Data
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.Data>>> GetData()
        {
            return await _context.Data.ToListAsync();
        }

        // GET: api/Data/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Models.Data>> GetData(int id)
        {
            var data = await _context.Data.FindAsync(id);

            if (data == null)
            {
                return NotFound();
            }

            return data;
        }

        // PUT: api/Data/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutData(int id, Models.Data data)
        {
            if (id != data.DataId)
            {
                return BadRequest();
            }

            _context.Entry(data).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DataExists(id))
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

        // POST: api/Data
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Models.Data>> PostData(Models.Data data)
        {
            _context.Data.Add(data);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetData", new { id = data.DataId }, data);
        }

        // DELETE: api/Data/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteData(int id)
        {
            var data = await _context.Data.FindAsync(id);
            if (data == null)
            {
                return NotFound();
            }

            _context.Data.Remove(data);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DataExists(int id)
        {
            return _context.Data.Any(e => e.DataId == id);
        }
    }
}
