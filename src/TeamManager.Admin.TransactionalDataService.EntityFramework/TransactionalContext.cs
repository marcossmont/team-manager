using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TeamManager.Admin.Domain.Entities.Teams;

namespace TeamManager.Admin.TransactionalDataService.EntityFramework
{
    public class TransactionalContext : DbContext
    {
        public TransactionalContext(DbContextOptions<TransactionalContext> options) : base(options)
        {

        }

        public DbSet<Team> Teams { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
