using Microsoft.EntityFrameworkCore;

namespace WorksBetterAPI.Models;

public class BranchesContext:DbContext
{
    public BranchesContext(DbContextOptions<BranchesContext> options) : base(options) { }
    public DbSet<Branches> Branches { get; set; } = null!;
}

