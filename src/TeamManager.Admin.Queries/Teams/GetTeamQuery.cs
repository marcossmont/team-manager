using System;
using TeamManager.Admin.Queries.Contracts.Teams;
using TeamManager.Admin.QueryDataService.Contracts.DataAccess.Teams.Get;
using static TeamManager.Admin.Queries.Contracts.Teams.GetTeamQueryResult;

namespace TeamManager.Admin.Queries.Teams
{
    public class GetTeamQuery : IGetTeamQuery
    {
        private readonly IGetTeamQueryDataAccess _dataAccess;

        public GetTeamQuery(IGetTeamQueryDataAccess dataAccess)
        {
            _dataAccess = dataAccess ?? throw new ArgumentNullException(nameof(dataAccess));
        }

        public GetTeamQueryResult Query(Guid id)
        {
            var team = _dataAccess.Query(id);
            return new GetTeamQueryResult()
            {
                Team = new TeamModel()
                {
                    Desctiption = team.Description,
                    Name = team.Name,
                    CreateSharePointSite = team.CreateSharePointSite,
                    CreateTeamsChannel = team.CreateTeamsChannel
                }
            };
        }
    }
}
