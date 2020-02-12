using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TeamManager.Admin.Domain.Entities.Teams;

namespace TeamManager.Admin.TransactionalDataService.EntityFramework.Mappings
{
    public class TeamConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Name).IsRequired();
            builder.Property(t => t.Description);
            builder.Property(t => t.CreateSharePointSite).IsRequired();
            builder.Property(t => t.CreateTeamsChannel).IsRequired();
        }
    }
}
