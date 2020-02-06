using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using TeamManager.Admin.Domain.Entities.Teams;
using TeamManager.Admin.QueryDataService.Contracts.Repositories;

namespace TeamManager.Admin.QueryDataService.Dapper.Repositories
{
    public class TeamsRepository : ITeamsRepository
    {
        private readonly SqlConnection _connection;
        private const string SqlQueryGetAll = "select Name, Decription, CreateSharePointSite, CreateTeamsChannel from Teams";
        private const string SqlQueryGet = "select Name, Decription, CreateSharePointSite, CreateTeamsChannel from Teams where Id = @Id";

        public TeamsRepository(SqlConnection connection)
        {
            _connection = connection ?? throw new ArgumentNullException(nameof(connection));
        }

        public IEnumerable<Team> GetAll()
        {
            return _connection.Query<Team>(SqlQueryGetAll);
        }

        public Team Get(Guid id)
        {
            var parameters = new DynamicParameters(new { Id = id });
            return _connection.QueryFirst<Team>(SqlQueryGet, parameters);
        }
    }
}
