using System;
using TeamManager.Admin.QueryDataService.Contracts.Repositories;

namespace TeamManager.Admin.QueryDataService.Contracts
{
    public interface IQueryDataService
    {
        ITeamsRepository TeamsRepository { get; }
    }
}
