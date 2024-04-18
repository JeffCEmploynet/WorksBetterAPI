using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WorksBetterAPI.Models;

namespace WorksBetterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChecksController : ControllerBase
    {
        private readonly ChecksContext _context;

        public ChecksController(ChecksContext context)
        {
            _context = context;
        }

        // GET: api/Checks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Checks>>> GetChecks()
        {
            return await _context.Checks.ToListAsync();
        }

        // GET: api/Checks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Checks>> GetChecks(long id)
        {
            var checks = await _context.Checks.FindAsync(id);

            if (checks == null)
            {
                return NotFound();
            }

            return checks;
        }

        // PUT: api/Checks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChecks(long id, Checks checks)
        {
            if (id != checks.Id)
            {
                return BadRequest();
            }

            _context.Entry(checks).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChecksExists(id))
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

        // POST: api/Checks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Checks>> PostChecks(Checks checks)
        {
            _context.Checks.Add(checks);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetChecks", new { id = checks.Id }, checks);
        }

        // DELETE: api/Checks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChecks(long id)
        {
            var checks = await _context.Checks.FindAsync(id);
            if (checks == null)
            {
                return NotFound();
            }

            _context.Checks.Remove(checks);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ChecksExists(long id)
        {
            return _context.Checks.Any(e => e.Id == id);
        }
    }
}
