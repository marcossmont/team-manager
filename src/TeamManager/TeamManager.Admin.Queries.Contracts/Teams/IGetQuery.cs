using System;
using System.Collections.Generic;
using System.Text;

namespace TeamManager.Admin.Queries.Contracts.Teams
{
    public interface IGetQuery
    {
        GetQueryResult Query(Guid id);
    }
}
