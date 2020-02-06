using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using TeamManager.Admin.QueryDataService.Contracts;
using TeamManager.Admin.QueryDataService.Contracts.Repositories;
using TeamManager.Admin.QueryDataService.Dapper.Repositories;

namespace TeamManager.Admin.QueryDataService.Dapper
{
    public class QueryDataService : IQueryDataService
    {
        private readonly SqlConnection _connection;

        public QueryDataService(string connectionString)
        {
            _connection = new SqlConnection(connectionString);
        }

        public ITeamsRepository TeamsRepository => new TeamsRepository(_connection);
    }
}
