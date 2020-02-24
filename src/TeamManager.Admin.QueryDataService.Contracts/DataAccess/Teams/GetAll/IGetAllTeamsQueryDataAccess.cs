using System;
using System.Collections.Generic;
using System.Text;

namespace TeamManager.Admin.QueryDataService.Contracts.DataAccess.Teams.GetAll
{
    public interface IGetAllTeamsQueryDataAccess
    {
        IEnumerable<GetAllTeamsQueryDataAccessOutput> Query();
    }
}
