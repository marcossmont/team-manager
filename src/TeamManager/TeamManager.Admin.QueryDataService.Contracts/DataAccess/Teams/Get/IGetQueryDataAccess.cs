using System;

namespace TeamManager.Admin.QueryDataService.Contracts.DataAccess.Teams.Get
{
    public interface IGetQueryDataAccess
    {
        GetOutput Query(Guid id);
    }
}
