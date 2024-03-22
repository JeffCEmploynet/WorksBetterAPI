using Microsoft.EntityFrameworkCore;

namespace WorksBetterAPI.Models;

public class CustomersContext : DbContext
{
    public CustomersContext(DbContextOptions<CustomersContext> options) : base(options) { }
    public DbSet<Customers> Customers { get; set; } = null!;
}
