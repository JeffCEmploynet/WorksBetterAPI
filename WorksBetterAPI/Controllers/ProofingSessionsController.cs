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
    public class ProofingSessionsController : ControllerBase
    {
        private readonly ProofingSessionContext _context;

        public ProofingSessionsController(ProofingSessionContext context)
        {
            _context = context;
        }

        // GET: api/ProofingSessions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProofingSession>>> GetProofingSession()
        {
            return await _context.ProofingSession.ToListAsync();
        }

        // GET: api/ProofingSessions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProofingSession>> GetProofingSession(long id)
        {
            var proofingSession = await _context.ProofingSession.FindAsync(id);

            if (proofingSession == null)
            {
                return NotFound();
            }

            return proofingSession;
        }

        // PUT: api/ProofingSessions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProofingSession(long id, ProofingSession proofingSession)
        {
            if (id != proofingSession.Id)
            {
                return BadRequest();
            }

            _context.Entry(proofingSession).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProofingSessionExists(id))
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

        // POST: api/ProofingSessions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProofingSession>> PostProofingSession(ProofingSession proofingSession)
        {
            _context.ProofingSession.Add(proofingSession);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProofingSession", new { id = proofingSession.Id }, proofingSession);
        }

        // DELETE: api/ProofingSessions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProofingSession(long id)
        {
            var proofingSession = await _context.ProofingSession.FindAsync(id);
            if (proofingSession == null)
            {
                return NotFound();
            }

            _context.ProofingSession.Remove(proofingSession);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProofingSessionExists(long id)
        {
            return _context.ProofingSession.Any(e => e.Id == id);
        }
    }
}
