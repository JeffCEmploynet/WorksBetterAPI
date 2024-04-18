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
    public class CheckRegistersController : ControllerBase
    {
        private readonly CheckRegisterContext _context;

        public CheckRegistersController(CheckRegisterContext context)
        {
            _context = context;
        }

        // GET: api/CheckRegisters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CheckRegister>>> GetCheckRegister()
        {
            return await _context.CheckRegister.ToListAsync();
        }

        // GET: api/CheckRegisters
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<CheckRegister>>> GetCheckRegister(string? firstName, string? lastName, long? employeeId, long? checkId, long? checkNumber)
        {
            if (employeeId != null && employeeId > 0) { return Ok(_context.CheckRegister.Where(dd => dd.EmployeeId == employeeId).ToArray()); }
            else if (lastName != null && lastName != "undefined") { return Ok(_context.CheckRegister.Where(dd => dd.LastName == lastName).ToArray()); }
            else if (firstName != null && firstName != "undefined") { return Ok(_context.CheckRegister.Where(dd => dd.FirstName == firstName).ToArray()); }
            else if (employeeId != null && employeeId > 0) { return Ok(_context.CheckRegister.Where(dd => dd.EmployeeId == employeeId).ToArray()); }
            else if (checkId != null && checkId > 0) { return Ok(_context.CheckRegister.Where(dd => dd.Id == checkId).ToArray()); }
            else if (checkNumber != null && checkNumber > 0) { return Ok(_context.CheckRegister.Where(dd => dd.CheckNumber == checkNumber).ToArray()); }

            return BadRequest("Invalid Parameters");
        }

        // GET: api/CheckRegisters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CheckRegister>> GetCheckRegister(long id)
        {
            var checkRegister = await _context.CheckRegister.FindAsync(id);

            if (checkRegister == null)
            {
                return NotFound();
            }

            return checkRegister;
        }

        // PUT: api/CheckRegisters/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCheckRegister(long id, CheckRegister checkRegister)
        {
            if (id != checkRegister.Id)
            {
                return BadRequest();
            }

            _context.Entry(checkRegister).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CheckRegisterExists(id))
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

        // POST: api/CheckRegisters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CheckRegister>> PostCheckRegister(CheckRegister checkRegister)
        {
            _context.CheckRegister.Add(checkRegister);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCheckRegister", new { id = checkRegister.Id }, checkRegister);
        }

        // DELETE: api/CheckRegisters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCheckRegister(long id)
        {
            var checkRegister = await _context.CheckRegister.FindAsync(id);
            if (checkRegister == null)
            {
                return NotFound();
            }

            _context.CheckRegister.Remove(checkRegister);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CheckRegisterExists(long id)
        {
            return _context.CheckRegister.Any(e => e.Id == id);
        }
    }
}
