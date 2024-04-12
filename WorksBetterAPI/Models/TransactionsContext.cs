using Microsoft.EntityFrameworkCore;

namespace WorksBetterAPI.Models
{
    public class TransactionsContext : DbContext
    {
        public TransactionsContext(DbContextOptions<TransactionsContext> options) : base(options) { }
        public DbSet<Transactions> Transactions { get; set; } = null!;
    }
}
