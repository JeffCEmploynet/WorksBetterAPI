using Microsoft.EntityFrameworkCore;

namespace WorksBetterAPI.Models;

public class JobOrdersContext : DbContext
{
    public JobOrdersContext(DbContextOptions<JobOrdersContext> options) : base(options) { }
    public DbSet<JobOrders> JobOrders { get; set; } = null!;
}
