using Microsoft.EntityFrameworkCore;

namespace WorksBetterAPI.Models;

public class InvoiceRegisterContext : DbContext
{
    public InvoiceRegisterContext(DbContextOptions<InvoiceRegisterContext> options) : base(options) { }
    public DbSet<InvoiceRegister> InvoiceRegister { get; set; }
}
