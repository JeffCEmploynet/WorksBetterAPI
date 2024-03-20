using Microsoft.EntityFrameworkCore;

namespace WorksBetterAPI.Models;

public class EmployeesContext : DbContext
{
    public EmployeesContext(DbContextOptions<EmployeesContext> options) : base(options) { }
    public DbSet<Employees> Employees { get; set; } = null!;
}
