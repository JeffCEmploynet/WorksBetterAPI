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
    public class AssignmentsController : ControllerBase
    {
        private readonly AssignmentsContext _context;

        public AssignmentsController(AssignmentsContext context)
        {
            _context = context;
        }

        // GET: api/Assignments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Assignments>>> GetAssignments()
        {
            return await _context.Assignments.ToListAsync();
        }

        // GET: api/Assignments
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Assignments>>> GetAssignments(string? firstName, string? lastName, long? employeeId, long? assignmentId ,string? customerName, long? customerId, string? jobTitle, long? orderId, string? branch)
        { 
            if (assignmentId != null && assignmentId > 0) { return Ok(_context.Assignments.Where(dd => dd.Id == assignmentId).ToArray()); }
            else if (employeeId != null && employeeId > 0) { return Ok(_context.Assignments.Where(dd => dd.EmployeeId == employeeId).ToArray()); }
            else if (lastName != null && lastName != "undefined") { return Ok(_context.Assignments.Where(dd => dd.LastName == lastName).ToArray()); }
            else if (firstName != null && firstName != "undefined") { return Ok(_context.Assignments.Where(dd => dd.FirstName == firstName).ToArray()); }
            else if (customerId != null && customerId > 0) { return Ok(_context.Assignments.Where(dd => dd.CustomerId == customerId).ToArray()); }
            else if (customerName != null && customerName != "undefined") { return Ok(_context.Assignments.Where(dd => dd.CustomerName == customerName).ToArray()); }
            else if (int.TryParse(orderId.ToString(), out _) && orderId != null && orderId > 0) { return Ok(_context.Assignments.Where(dd => dd.OrderId == orderId).ToArray()); }
            else if (jobTitle != null && jobTitle != "undefined") { return Ok(_context.Assignments.Where(dd => dd.JobTitle == jobTitle).ToArray()); }
            else if (branch != null && branch != "undefined") { return Ok(_context.Assignments.Where(dd => dd.Branch == branch).ToArray()); }

            return BadRequest("Invalid Parameters");
        }

        // GET: api/Assignments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Assignments>> GetAssignments(long id)
        {
            var assignments = await _context.Assignments.FindAsync(id);

            if (assignments == null)
            {
                return NotFound();
            }

            return assignments;
        }

        // PUT: api/Assignments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAssignments(long id, Assignments assignments)
        {
            if (id != assignments.Id)
            {
                return BadRequest();
            }

            _context.Entry(assignments).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssignmentsExists(id))
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

        // POST: api/Assignments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Assignments>> PostAssignments(Assignments assignments)
        {
            _context.Assignments.Add(assignments);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAssignments", new { id = assignments.Id }, assignments);
        }

        // DELETE: api/Assignments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAssignments(long id)
        {
            var assignments = await _context.Assignments.FindAsync(id);
            if (assignments == null)
            {
                return NotFound();
            }

            _context.Assignments.Remove(assignments);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AssignmentsExists(long id)
        {
            return _context.Assignments.Any(e => e.Id == id);
        }
    }
}
