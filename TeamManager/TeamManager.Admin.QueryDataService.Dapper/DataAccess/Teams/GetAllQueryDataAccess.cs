using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using TeamManager.Admin.QueryDataService.Contracts.DataAccess.Teams.GetAll;

namespace TeamManager.Admin.QueryDataService.Dapper.DataAccess.Teams
{
    public class GetAllQueryDataAccess
    {
        private readonly SqlConnection _connection;

        public GetAllQueryDataAccess(DapperQueryDataService dataService)
        {
            _connection = dataService._connection;
        }

        public IEnumerable<GetAllOutput> Query()
        {
            var query = "select Id, Name, CreateSharePointSite, CreateTeamsChannel from Teams";
            return _connection.Query<GetAllOutput>(query);
        }
    }
}
