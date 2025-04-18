using System.Reflection;
using Microsoft.EntityFrameworkCore;
using OT.Assessment.Database.Models;

namespace OT.Assessment.Database;
public partial class OTAssessmentContext: DbContext
{
    public OTAssessmentContext(DbContextOptions<OTAssessmentContext> options): base(options) {}

    public virtual DbSet<AccessLevel> AccessLevels => Set<AccessLevel>();
    public virtual DbSet<Account> Accounts => Set<Account>();
    public virtual DbSet<ApplicationUser> ApplicationUsers => Set<ApplicationUser>();
    public virtual DbSet<Brand> Brands => Set<Brand>();
    public virtual DbSet<Country> Countries => Set<Country>();
    public virtual DbSet<Game> Games => Set<Game>();
    public virtual DbSet<GamePlayer> GamePlayers => Set<GamePlayer>();
    public virtual DbSet<Provider> Providers => Set<Provider>();
    public virtual DbSet<Theme> Themes => Set<Theme>();
    public virtual DbSet<Transaction> Transactions => Set<Transaction>();
    public virtual DbSet<TransactionType> TransactionTypes => Set<TransactionType>();
    public virtual DbSet<User> Users => Set<User>();
    public virtual DbSet<Wager> Wagers => Set<Wager>();


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
