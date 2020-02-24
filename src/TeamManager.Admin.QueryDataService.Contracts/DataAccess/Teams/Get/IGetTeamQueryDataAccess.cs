using System;

namespace TeamManager.Admin.QueryDataService.Contracts.DataAccess.Teams.Get
{
    public interface IGetTeamQueryDataAccess
    {
        GetTeamQueryDataAccessOutput Query(Guid id);
    }
}
