using System.Reflection;
using Microsoft.EntityFrameworkCore;
using OT.Assessment.Database.Models;

namespace OT.Assessment.Database;
public partial class OTAssessmentContext: DbContext
{
    public OTAssessmentContext(DbContextOptions<OTAssessmentContext> options): base(options) {}

    public virtual DbSet<AccessLevel> AccessLevels => Set<AccessLevel>();
    public virtual DbSet<Account> Accounts => Set<Account>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
