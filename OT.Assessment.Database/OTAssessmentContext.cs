using System.Reflection;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using OT.Assessment.Database.Helpers;
using OT.Assessment.Database.Models;
using DotNetEnv;

namespace OT.Assessment.Database;
public partial class OTAssessmentContext: DbContext
{
    public OTAssessmentContext(){}
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

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var data = Env.Load();
            
            var connectionDetails = new ConnectionString()
            {
                Server = GetEnvironmentVariable("SERVER"),
                DatabaseName = GetEnvironmentVariable("DATABASE_NAME"),
                Password = GetEnvironmentVariable("PASSWORD"),
                User = GetEnvironmentVariable("USER"),
            };

            var connectionString = ConnectionStringBuilder.BuildConnectionString(connectionDetails);
            
            optionsBuilder.UseSqlServer(connectionString);
        }
    }

    private string GetEnvironmentVariable(string variableName)
    {
        return Environment.GetEnvironmentVariable($"REFERENCE_DB__{variableName}", EnvironmentVariableTarget.Process) ?? string.Empty;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
