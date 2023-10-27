using Microsoft.EntityFrameworkCore;
using GoalFundApi.Models;

namespace OmniGLM_API.db
{
    public class ApplicationContext : DbContext
    {
        private readonly ApplicationConfig _appConfig;
        private string _connectionString => _appConfig.DatabaseConnectionString;
        public DbSet<Quest> Quests { get; set; }
        public DbSet<Goal> Goals { get; set; }
        public DbSet<Requirement> Requirements { get; set; }

        public ApplicationContext(
            ApplicationConfig appConfig,
            DbContextOptions options
        )
        : base(options)
        {
            _appConfig = appConfig;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseNpgsql(_connectionString)
                .EnableSensitiveDataLogging()
                .UseSnakeCaseNamingConvention();
        }

        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
            
        // }
    }
}