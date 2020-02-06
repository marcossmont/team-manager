using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TeamManager.Admin.Domain.Entities.Teams;
using TeamManager.Admin.TransactionalDataService.Contracts.Repositories;

namespace TeamManager.Admin.TransactionalDataService.EntityFramework.Repositories
{
    public class TeamsRepository : ITeamsRepository
    {
        private readonly TransactionalContext _context;

        public TeamsRepository(TransactionalContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Create(Team team)
        {
            _context.Teams.Add(team);
        }
    }
}
