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
    public class TaxSetupsController : ControllerBase
    {
        private readonly TaxSetupContext _context;

        public TaxSetupsController(TaxSetupContext context)
        {
            _context = context;
        }

        // GET: api/TaxSetups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaxSetup>>> GetTaxSetup()
        {
            return await _context.TaxSetup.ToListAsync();
        }

        // GET: api/TaxSetups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TaxSetup>> GetTaxSetup(long id)
        {
            var taxSetup = await _context.TaxSetup.FindAsync(id);

            if (taxSetup == null)
            {
                return NotFound();
            }

            return taxSetup;
        }

        // PUT: api/TaxSetups/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTaxSetup(long id, TaxSetup taxSetup)
        {
            if (id != taxSetup.Id)
            {
                return BadRequest();
            }

            _context.Entry(taxSetup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaxSetupExists(id))
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

        // POST: api/TaxSetups
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TaxSetup>> PostTaxSetup(TaxSetup taxSetup)
        {
            _context.TaxSetup.Add(taxSetup);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTaxSetup", new { id = taxSetup.Id }, taxSetup);
        }

        // DELETE: api/TaxSetups/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaxSetup(long id)
        {
            var taxSetup = await _context.TaxSetup.FindAsync(id);
            if (taxSetup == null)
            {
                return NotFound();
            }

            _context.TaxSetup.Remove(taxSetup);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TaxSetupExists(long id)
        {
            return _context.TaxSetup.Any(e => e.Id == id);
        }
    }
}
