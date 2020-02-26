using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using TeamManager.Admin.QueryDataService.Contracts.DataAccess.Teams.Get;

namespace TeamManager.Admin.QueryDataService.Dapper.DataAccess.Teams
{
    public class GetTeamQueryDataAccess : IGetTeamQueryDataAccess
    {
        private readonly DapperQueryDataService _dataService;

        public GetTeamQueryDataAccess(DapperQueryDataService dataService)
        {
            _dataService = dataService ?? throw new ArgumentNullException(nameof(dataService));
        }

        public GetTeamQueryDataAccessOutput Query(Guid id)
        {
            using (var connection = _dataService.GetSqlConnection())
            {
                var query = "select Name, Description, CreateSharePointSite, CreateTeamsChannel from Teams where Id = @Id";
                var parameters = new DynamicParameters(new { Id = id });

                return connection.QueryFirstOrDefault<GetTeamQueryDataAccessOutput>(query, parameters);
            }
        }
    }
}
