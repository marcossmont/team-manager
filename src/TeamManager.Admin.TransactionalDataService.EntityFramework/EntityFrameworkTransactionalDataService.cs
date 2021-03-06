﻿using TeamManager.Admin.TransactionalDataService.Contracts;
using TeamManager.Admin.TransactionalDataService.Contracts.Repositories;
using TeamManager.Admin.TransactionalDataService.EntityFramework.Repositories;

namespace TeamManager.Admin.TransactionalDataService.EntityFramework
{
    public class EntityFrameworkTransactionalDataService : ITransactionalDataService
    {
        private readonly TransactionalContext _context;

        public EntityFrameworkTransactionalDataService(TransactionalContext context)
        {
            _context = context ?? throw new System.ArgumentNullException(nameof(context));
        }
        public ITeamsRepository TeamsRepository => new TeamsRepository(_context);

        public void Persist()
        {
            _context.SaveChanges();
        }
    }
}
