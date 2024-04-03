using Microsoft.EntityFrameworkCore;

namespace WorksBetterAPI.Models;

public class TimecardsContext : DbContext
{
    public TimecardsContext(DbContextOptions<TimecardsContext> options) : base(options) { }
    public DbSet<Timecards> Timecards { get; set; } = null!;
}
