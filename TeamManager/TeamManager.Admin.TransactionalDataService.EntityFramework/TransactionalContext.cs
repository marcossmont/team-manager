using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TeamManager.Admin.Domain.Entities.Teams;

namespace TeamManager.Admin.TransactionalDataService.EntityFramework
{
    public class TransactionalContext : DbContext
    {
        private readonly string _connectionString;

        public TransactionalContext(string connectionString)
        {
            _connectionString = connectionString ?? throw new System.ArgumentNullException(nameof(connectionString));
        }

        internal TransactionalContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Team> Teams { get; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlServer(_connectionString);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
