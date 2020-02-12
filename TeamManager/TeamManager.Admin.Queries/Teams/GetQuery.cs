using System;
using TeamManager.Admin.Queries.Contracts.Teams;
using TeamManager.Admin.QueryDataService.Contracts.DataAccess.Teams.Get;
using static TeamManager.Admin.Queries.Contracts.Teams.GetQueryResult;

namespace TeamManager.Admin.Queries.Teams
{
    public class GetQuery : IGetQuery
    {
        private readonly IGetQueryDataAccess _dataAccess;

        public GetQuery(IGetQueryDataAccess dataAccess)
        {
            _dataAccess = dataAccess ?? throw new ArgumentNullException(nameof(dataAccess));
        }

        public GetQueryResult Query(Guid id)
        {
            var team = _dataAccess.Query(id);
            return new GetQueryResult()
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
