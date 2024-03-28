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
    public class JobOrdersController : ControllerBase
    {
        private readonly JobOrdersContext _context;

        public JobOrdersController(JobOrdersContext context)
        {
            _context = context;
        }

        // GET: api/JobOrders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JobOrders>>> GetJobOrders(string? customerName, long? customerId, string? jobTitle, long? orderId, string? branch)
        {
            if (customerId != null && customerId > 0) { return Ok(_context.JobOrders.Where(dd => dd.CustomerId == customerId).ToArray()); }
            else if (customerName != null && customerName != "undefined") { return Ok(_context.JobOrders.Where(dd => dd.CustomerName == customerName).ToArray()); }
            else if (int.TryParse(orderId.ToString(), out _) && orderId != null && orderId > 0) { return Ok(_context.JobOrders.Where(dd => dd.JobOrdersId == orderId).ToArray()); }
            else if (jobTitle != null && jobTitle != "undefined") { return Ok(_context.JobOrders.Where(dd => dd.JobTitle == jobTitle).ToArray()); }
            else if (branch != null && branch != "undefined") { return Ok(_context.JobOrders.Where(dd => dd.Branch == branch).ToArray()); }

            return BadRequest("Invalid Parameters");
        }

        // GET: api/JobOrders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<JobOrders>> GetJobOrders(long id)
        {
            var jobOrders = await _context.JobOrders.FindAsync(id);

            if (jobOrders == null)
            {
                return NotFound();
            }

            return jobOrders;
        }

        // PUT: api/JobOrders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJobOrders(long id, JobOrders jobOrders)
        {
            if (id != jobOrders.JobOrdersId)
            {
                return BadRequest();
            }

            _context.Entry(jobOrders).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobOrdersExists(id))
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

        // POST: api/JobOrders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<JobOrders>> PostJobOrders(JobOrders jobOrders)
        {
            _context.JobOrders.Add(jobOrders);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetJobOrders", new { id = jobOrders.JobOrdersId }, jobOrders);
        }

        // DELETE: api/JobOrders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJobOrders(long id)
        {
            var jobOrders = await _context.JobOrders.FindAsync(id);
            if (jobOrders == null)
            {
                return NotFound();
            }

            _context.JobOrders.Remove(jobOrders);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool JobOrdersExists(long id)
        {
            return _context.JobOrders.Any(e => e.JobOrdersId == id);
        }
    }
}
