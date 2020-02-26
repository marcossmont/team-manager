using System;
using System.Collections.Generic;
using System.Text;

namespace TeamManager.Search.QueryDataService.Contracts.Teams
{
    public interface IGetTeamsQueryDataAccess
    {
        IEnumerable<GetTeamsQueryDataAccessOutput> Query(GetTeamsQueryDataAccessInput parameters);
    }
}
