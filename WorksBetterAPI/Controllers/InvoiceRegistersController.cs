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
    public class InvoiceRegistersController : ControllerBase
    {
        private readonly InvoiceRegisterContext _context;

        public InvoiceRegistersController(InvoiceRegisterContext context)
        {
            _context = context;
        }

        // GET: api/InvoiceRegisters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InvoiceRegister>>> GetInvoiceRegister()
        {
            return await _context.InvoiceRegister.ToListAsync();
        }

        // GET: api/InvoiceRegisters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InvoiceRegister>> GetInvoiceRegister(long id)
        {
            var invoiceRegister = await _context.InvoiceRegister.FindAsync(id);

            if (invoiceRegister == null)
            {
                return NotFound();
            }

            return invoiceRegister;
        }

        // PUT: api/InvoiceRegisters/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInvoiceRegister(long id, InvoiceRegister invoiceRegister)
        {
            if (id != invoiceRegister.Id)
            {
                return BadRequest();
            }

            _context.Entry(invoiceRegister).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InvoiceRegisterExists(id))
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

        // POST: api/InvoiceRegisters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<InvoiceRegister>> PostInvoiceRegister(InvoiceRegister invoiceRegister)
        {
            _context.InvoiceRegister.Add(invoiceRegister);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInvoiceRegister", new { id = invoiceRegister.Id }, invoiceRegister);
        }

        // DELETE: api/InvoiceRegisters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInvoiceRegister(long id)
        {
            var invoiceRegister = await _context.InvoiceRegister.FindAsync(id);
            if (invoiceRegister == null)
            {
                return NotFound();
            }

            _context.InvoiceRegister.Remove(invoiceRegister);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InvoiceRegisterExists(long id)
        {
            return _context.InvoiceRegister.Any(e => e.Id == id);
        }
    }
}
