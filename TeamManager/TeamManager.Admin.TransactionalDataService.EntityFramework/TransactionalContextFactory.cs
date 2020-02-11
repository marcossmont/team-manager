using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace TeamManager.Admin.TransactionalDataService.EntityFramework
{
    public class TransactionalContextFactory : IDesignTimeDbContextFactory<TransactionalContext>
    {
        public TransactionalContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TransactionalContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=TeamManagerBusiness;Trusted_Connection=True");

            return new TransactionalContext(optionsBuilder.Options);
        }
    }
}
