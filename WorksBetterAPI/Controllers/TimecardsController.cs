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
    public class TimecardsController : ControllerBase
    {
        private readonly TimecardsContext _context;

        public TimecardsController(TimecardsContext context)
        {
            _context = context;
        }

        // GET: api/Timecards
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Timecards>>> GetTimecards()
        {
            return await _context.Timecards.ToListAsync();
        }

        // GET: api/Timecards
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Timecards>>> GetTimecards(string? firstName, string? lastName, long? employeeId, long? assignmentId, string? customerName, long? customerId)
        {
            if (assignmentId != null && assignmentId > 0) { return Ok(_context.Timecards.Where(dd => dd.Id == assignmentId).ToArray()); }
            else if (employeeId != null && employeeId > 0) { return Ok(_context.Timecards.Where(dd => dd.EmployeeId == employeeId).ToArray()); }
            else if (lastName != null && lastName != "undefined") { return Ok(_context.Timecards.Where(dd => dd.LastName == lastName).ToArray()); }
            else if (firstName != null && firstName != "undefined") { return Ok(_context.Timecards.Where(dd => dd.FirstName == firstName).ToArray()); }
            else if (customerId != null && customerId > 0) { return Ok(_context.Timecards.Where(dd => dd.CustomerId == customerId).ToArray()); }
            else if (customerName != null && customerName != "undefined") { return Ok(_context.Timecards.Where(dd => dd.CustomerName == customerName).ToArray()); }

            return BadRequest("Invalid Parameters");
        }

        // GET: api/Timecards/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Timecards>> GetTimecards(long id)
        {
            var timecards = await _context.Timecards.FindAsync(id);

            if (timecards == null)
            {
                return NotFound();
            }

            return timecards;
        }

        // PUT: api/Timecards/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTimecards(long id, Timecards timecards)
        {
            if (id != timecards.Id)
            {
                return BadRequest();
            }

            _context.Entry(timecards).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TimecardsExists(id))
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

        // POST: api/Timecards
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Timecards>> PostTimecards(Timecards timecards)
        {
            _context.Timecards.Add(timecards);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTimecards", new { id = timecards.Id }, timecards);
        }

        // DELETE: api/Timecards/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTimecards(long id)
        {
            var timecards = await _context.Timecards.FindAsync(id);
            if (timecards == null)
            {
                return NotFound();
            }

            _context.Timecards.Remove(timecards);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TimecardsExists(long id)
        {
            return _context.Timecards.Any(e => e.Id == id);
        }
    }
}
