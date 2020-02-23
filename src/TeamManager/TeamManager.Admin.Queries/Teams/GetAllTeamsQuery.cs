using System;
using System.Linq;
using TeamManager.Admin.Queries.Contracts.Teams;
using TeamManager.Admin.QueryDataService.Contracts.DataAccess.Teams.Get;
using TeamManager.Admin.QueryDataService.Contracts.DataAccess.Teams.GetAll;
using static TeamManager.Admin.Queries.Contracts.Teams.GetAllTeamsQueryResult;

namespace TeamManager.Admin.Queries.Teams
{
    public class GetAllTeamsQuery : IGetAllTeamsQuery
    {
        private readonly IGetAllTeamsQueryDataAccess _dataAccess;

        public GetAllTeamsQuery(IGetAllTeamsQueryDataAccess dataAccess)
        {
            _dataAccess = dataAccess ?? throw new ArgumentNullException(nameof(dataAccess));
        }

        
        public GetAllTeamsQueryResult Query()
        {
            var teams = _dataAccess.Query();
            return new GetAllTeamsQueryResult()
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
