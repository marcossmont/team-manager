using System;
using System.Collections.Generic;
using System.Text;
using TeamManager.Admin.Domain.Entities.Teams;

namespace TeamManager.Admin.QueryDataService.Contracts.Repositories
{
    public interface ITeamsRepository
    {
        IEnumerable<Team> GetAll();
        Team Get(Guid id);
    }
}
