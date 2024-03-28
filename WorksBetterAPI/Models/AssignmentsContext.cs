using Microsoft.EntityFrameworkCore;

namespace WorksBetterAPI.Models;

public class AssignmentsContext : DbContext
{
    public AssignmentsContext(DbContextOptions<AssignmentsContext> options) : base(options) { }
    public DbSet<Assignments> Assignments { get; set; } = null!;
}
