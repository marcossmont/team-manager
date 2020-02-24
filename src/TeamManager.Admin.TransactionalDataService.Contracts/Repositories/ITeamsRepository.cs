using System;
using System.Collections.Generic;
using System.Text;
using TeamManager.Admin.Domain.Entities.Teams;

namespace TeamManager.Admin.TransactionalDataService.Contracts.Repositories
{
    public interface ITeamsRepository
    {
        void Create(Team team);
    }
}
