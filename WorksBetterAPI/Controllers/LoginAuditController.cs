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
    public class LoginAuditController : ControllerBase
    {
        private readonly LoginAuditContext _context;
        private readonly UsersContext _usersContext;

        public LoginAuditController(LoginAuditContext context, UsersContext usersContext)
        {
            _context = context;
            _usersContext = usersContext;   
        }

        // GET: api/LoginAudit
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LoginAudit>>> GetLoginAudit()
        {
            return await _context.LoginAudit.ToListAsync();
        }

        // GET: api/LoginAudit/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LoginAudit>> GetLoginAudit(long id)
        {
            var loginAudit = await _context.LoginAudit.FindAsync(id);

            if (loginAudit == null)
            {
                return NotFound();
            }

            return loginAudit;
        }

        // PUT: api/LoginAudit/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLoginAudit(long id, LoginAudit loginAudit)
        {
            if (id != loginAudit.Id)
            {
                return BadRequest();
            }

            _context.Entry(loginAudit).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoginAuditExists(id))
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

        // POST: api/LoginAudit
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LoginAudit>> PostLoginAudit(string username, string password)
        {
            Users ValidUser = _usersContext.Users.FirstOrDefault(acc => username == acc.UserName && acc.Password == password);


            if (ValidUser != null)
            {
                LoginAudit audit = new LoginAudit();
                audit.UserName = username;
                audit.LoginDate = DateTime.UtcNow;
                audit.ExpirationDate = DateTime.UtcNow.AddDays(1);
                audit.Token = Guid.NewGuid();
                audit.FirstName = ValidUser.FirstName;
                audit.LastName = ValidUser.LastName;
                audit.BranchName = ValidUser.BranchName;
                audit.BranchId = ValidUser.BranchId;
                audit.UserType = ValidUser.UserType;
                audit.AuthLevel = ValidUser.AuthLevel;

                _context.LoginAudit.Add(audit);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetLoginAudit", new { id = audit.Id }, audit);
            }
            return BadRequest("Invalid Parameters");
        }

        // DELETE: api/LoginAudit/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLoginAudit(long id)
        {
            var loginAudit = await _context.LoginAudit.FindAsync(id);
            if (loginAudit == null)
            {
                return NotFound();
            }

            _context.LoginAudit.Remove(loginAudit);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LoginAuditExists(long id)
        {
            return _context.LoginAudit.Any(e => e.Id == id);
        }
    }
}
