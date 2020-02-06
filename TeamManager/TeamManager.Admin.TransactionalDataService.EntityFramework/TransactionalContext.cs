using Microsoft.EntityFrameworkCore;
using TeamManager.Admin.Domain.Entities.Teams;

namespace TeamManager.Admin.TransactionalDataService.EntityFramework
{
    public class TransactionalContext : DbContext
    {
        //"Server=(localdb)\mssqllocaldb;Database=MyDatabase;Trusted_Connection=True;"
        private readonly string _connectionString;

        protected TransactionalContext(string connectionString)
        {
            _connectionString = connectionString ?? throw new System.ArgumentNullException(nameof(connectionString));
        }

        public DbSet<Team> Teams { get; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlServer(_connectionString);
    }
}
