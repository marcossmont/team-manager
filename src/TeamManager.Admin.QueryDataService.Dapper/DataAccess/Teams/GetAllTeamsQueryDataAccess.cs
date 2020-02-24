using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using TeamManager.Admin.QueryDataService.Contracts.DataAccess.Teams.GetAll;

namespace TeamManager.Admin.QueryDataService.Dapper.DataAccess.Teams
{
    public class GetAllTeamsQueryDataAccess : IGetAllTeamsQueryDataAccess
    {
        private readonly DapperQueryDataService _dataService;

        public GetAllTeamsQueryDataAccess(DapperQueryDataService dataService)
        {
            _dataService = dataService ?? throw new ArgumentNullException(nameof(dataService));
        }

        public IEnumerable<GetAllTeamsQueryDataAccessOutput> Query()
        {
            using (var connection = _dataService.GetSqlConnection())
            {
                var query = "select Id, Name, CreateSharePointSite, CreateTeamsChannel from Teams";
                return connection.Query<GetAllTeamsQueryDataAccessOutput>(query);
            }
        }
    }
}
