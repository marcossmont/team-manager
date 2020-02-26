using System;
using System.Collections.Generic;
using System.Text;

namespace TeamManager.Search.Queries.Contracts.Teams
{
    public interface IGetTeamsQuery
    {
        GetTeamsQueryResult Query(GetTeamsQueryParameters parameters);
    }
}
