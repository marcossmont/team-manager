using System;
using System.Collections.Generic;
using System.Text;

namespace TeamManager.Admin.QueryDataService.Contracts.DataAccess.Teams.GetAll
{
    public interface IGetAllQueryDataAccess
    {
        IEnumerable<GetAllOutput> Query();
    }
}
