using System;
using System.Collections.Generic;
using System.Text;
using TeamManager.Admin.QueryDataService.Contracts;
using TeamManager.Admin.UseCases.Contracts.Teams.Queries;
using static TeamManager.Admin.UseCases.Contracts.Teams.Queries.GetQueryResult;

namespace TeamManager.Admin.UseCases.Teams.Queries
{
    public class GetQuery : IGetQuery
    {
        private readonly IQueryDataService _queryDataService;

        public GetQuery(IQueryDataService queryDataService)
        {
            _queryDataService = queryDataService ?? throw new ArgumentNullException(nameof(queryDataService));
        }

        public GetQueryResult Query(Guid id)
        {
            var team = _queryDataService.TeamsRepository.Get(id);
            return new GetQueryResult()
            {
                Team = new TeamModel()
                {
                    Id = team.Id,
                    Desctiption = team.Description,
                    Name = team.Name,
                    CreateSharePointSite = team.CreateSharePointSite,
                    CreateTeamsChannel = team.CreateTeamsChannel
                }
            };
        }
    }
}
