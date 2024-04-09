using Microsoft.EntityFrameworkCore;

namespace WorksBetterAPI.Models;

public class TaxSetupContext : DbContext
{
    public TaxSetupContext(DbContextOptions<TaxSetupContext> options) : base(options) { }
    public DbSet<TaxSetup> TaxSetup { get; set; } = null!;
}
