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
    public class BranchesController : ControllerBase
    {
        private readonly BranchesContext _context;

        public BranchesController(BranchesContext context)
        {
            _context = context;
        }

        // GET: api/Branches
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Branches>>> GetBranches()
        {
            return await _context.Branches.ToListAsync();
        }

        // GET: api/Branches/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Branches>> GetBranches(short id)
        {
            var branches = await _context.Branches.FindAsync(id);

            if (branches == null)
            {
                return NotFound();
            }

            return branches;
        }

        // PUT: api/Branches/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBranches(short id, Branches branches)
        {
            if (id != branches.Id)
            {
                return BadRequest();
            }

            _context.Entry(branches).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BranchesExists(id))
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

        // POST: api/Branches
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Branches>> PostBranches(Branches branches)
        {
            _context.Branches.Add(branches);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBranches", new { id = branches.Id }, branches);
        }

        // DELETE: api/Branches/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBranches(short id)
        {
            var branches = await _context.Branches.FindAsync(id);
            if (branches == null)
            {
                return NotFound();
            }

            _context.Branches.Remove(branches);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BranchesExists(short id)
        {
            return _context.Branches.Any(e => e.Id == id);
        }
    }
}
