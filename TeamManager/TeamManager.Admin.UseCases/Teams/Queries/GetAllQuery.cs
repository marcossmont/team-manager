using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TeamManager.Admin.QueryDataService.Contracts;
using TeamManager.Admin.UseCases.Contracts.Teams.Queries;
using static TeamManager.Admin.UseCases.Contracts.Teams.Queries.GetAllQueryResult;

namespace TeamManager.Admin.UseCases.Teams.Queries
{
    public class GetAllQuery : IGetAllQuery
    {
        private readonly IQueryDataService _queryDataService;

        public GetAllQuery(IQueryDataService queryDataService)
        {
            _queryDataService = queryDataService ?? throw new ArgumentNullException(nameof(queryDataService));
        }

        public GetAllQueryResult Query()
        {
            var teams = _queryDataService.TeamsRepository.GetAll();
            return new GetAllQueryResult()
            {
                Teams = teams.Select(t => new Team()
                {
                    Name = t.Name,
                    CreateSharePointSite = t.CreateSharePointSite,
                    CreateTeamsChannel = t.CreateTeamsChannel
                })
            };
        }
    }
}
