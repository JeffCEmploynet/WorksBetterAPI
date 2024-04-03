using Microsoft.EntityFrameworkCore;

namespace WorksBetterAPI.Models;

public class UsersContext: DbContext
{
    public UsersContext(DbContextOptions<UsersContext> options) : base(options) { }
    public DbSet<Users> Users { get; set; } = null!;
}

