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
    public class EmployeesController : ControllerBase
    {
        private readonly EmployeesContext _context;

        public EmployeesController(EmployeesContext context)
        {
            _context = context;
        }

        // GET: api/EmployeesModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employees>>> GetEmployeesModels(long? id, string? firstName, string? lastName)
        {
            if(id != null && id > 0) { return Ok(_context.Employees.Where(dd => dd.Id == id).ToArray()); }
            else if(firstName != null && lastName != null) { return Ok(_context.Employees.Where(dd => dd.FirstName == firstName && dd.LastName == lastName).ToArray()); }
            else if (firstName != null && lastName == null) { return Ok(_context.Employees.Where(dd => dd.FirstName == firstName).ToArray()); }
            else if (firstName == null && lastName != null) { return Ok(_context.Employees.Where(dd => dd.LastName == lastName).ToArray()); }

            return BadRequest("Invalid Parameters");
        }

        // GET: api/EmployeesModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employees>> GetEmployeesModel(long id)
        {
            var employeesModel = await _context.Employees.FindAsync(id);

            if (employeesModel == null)
            {
                return NotFound();
            }

            return employeesModel;
        }

        // PUT: api/EmployeesModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployeesModel(long id, Employees employeesModel)
        {
            if (id != employeesModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(employeesModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeesModelExists(id))
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

        // POST: api/EmployeesModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Employees>> PostEmployeesModel(Employees employeesModel)
        {
            _context.Employees.Add(employeesModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployeesModel", new { id = employeesModel.Id }, employeesModel);
        }

        // DELETE: api/EmployeesModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployeesModel(long id)
        {
            var employeesModel = await _context.Employees.FindAsync(id);
            if (employeesModel == null)
            {
                return NotFound();
            }

            _context.Employees.Remove(employeesModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmployeesModelExists(long id)
        {
            return _context.Employees.Any(e => e.Id == id);
        }
    }
}
