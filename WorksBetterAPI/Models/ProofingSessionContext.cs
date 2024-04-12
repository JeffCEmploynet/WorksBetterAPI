using Microsoft.EntityFrameworkCore;
using NuGet.Packaging.Core;

namespace WorksBetterAPI.Models;

public class ProofingSessionContext : DbContext
{
    public ProofingSessionContext(DbContextOptions<ProofingSessionContext> options) : base(options) { }
    public DbSet<ProofingSession> ProofingSession { get; set; } = null!;
}
