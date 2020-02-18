using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TeamManager.Admin.Domain.Entities.Teams;
using TeamManager.Admin.Domain.ValueObjects;

namespace TeamManager.Admin.TransactionalDataService.EntityFramework.Mappings
{
    public class AdministratorConfiguration : IEntityTypeConfiguration<Administrator>
    {
        public void Configure(EntityTypeBuilder<Administrator> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Name).IsRequired();
            builder.Property(t => t.Email).IsRequired().HasConversion(e => e.Address, e => new Email(e));
        }
    }
}
