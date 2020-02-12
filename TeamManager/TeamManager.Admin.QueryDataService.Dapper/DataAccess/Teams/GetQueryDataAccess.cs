using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using TeamManager.Admin.QueryDataService.Contracts.DataAccess.Teams.Get;

namespace TeamManager.Admin.QueryDataService.Dapper.DataAccess.Teams
{
    public class GetQueryDataAccess : IGetQueryDataAccess
    {
        private SqlConnection _connection;

        public GetQueryDataAccess(DapperQueryDataService dataService)
        {
            _connection = dataService._connection;
        }

        public GetOutput Query(Guid id)
        {
            var query = "select Name, Decription, CreateSharePointSite, CreateTeamsChannel from Teams where Id = @Id";
            var parameters = new DynamicParameters(new { Id = id });
            
            return _connection.QueryFirst<GetOutput>(query, parameters);
        }
    }
}
