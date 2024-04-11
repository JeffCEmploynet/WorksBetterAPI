using Microsoft.EntityFrameworkCore;

namespace WorksBetterAPI.Models;

public class LoginAuditContext: DbContext
{
    public LoginAuditContext(DbContextOptions<LoginAuditContext> options) : base(options) { }
    public DbSet<LoginAudit> LoginAudit { get; set; }
}
