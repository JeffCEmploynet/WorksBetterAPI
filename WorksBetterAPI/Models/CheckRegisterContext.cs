using Microsoft.EntityFrameworkCore;

namespace WorksBetterAPI.Models;

public class CheckRegisterContext : DbContext
{
    public CheckRegisterContext(DbContextOptions<CheckRegisterContext> options) : base(options) { }
    public DbSet<CheckRegister> CheckRegister { get; set;}
}
