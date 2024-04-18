using Microsoft.EntityFrameworkCore;

namespace WorksBetterAPI.Models;
public class ChecksContext : DbContext
{
    public ChecksContext(DbContextOptions<ChecksContext> options) : base(options) { }
    public DbSet<Checks> Checks { get; set; }
}

