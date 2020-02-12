using System;
using System.Linq;
using TeamManager.Admin.Queries.Contracts.Teams;
using TeamManager.Admin.QueryDataService.Contracts.DataAccess.Teams.Get;
using TeamManager.Admin.QueryDataService.Contracts.DataAccess.Teams.GetAll;
using static TeamManager.Admin.Queries.Contracts.Teams.GetAllQueryResult;

namespace TeamManager.Admin.Queries.Teams
{
    public class GetAllQuery : IGetAllQuery
    {
        private readonly IGetAllQueryDataAccess _dataAccess;

        public GetAllQuery(IGetAllQueryDataAccess dataAccess)
        {
            _dataAccess = dataAccess ?? throw new ArgumentNullException(nameof(dataAccess));
        }

        
        public GetAllQueryResult Query()
        {
            var teams = _dataAccess.Query();
            return new GetAllQueryResult()
            {
                Teams = teams.Select(team => new TeamModel()
                {
                    Id = team.Id,
                    Name = team.Name,
                    CreateSharePointSite = team.CreateSharePointSite,
                    CreateTeamsChannel = team.CreateTeamsChannel
                })
            };
        }
    }
}
