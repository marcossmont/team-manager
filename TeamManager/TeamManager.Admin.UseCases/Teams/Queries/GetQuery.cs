using System;
using System.Collections.Generic;
using System.Text;
using TeamManager.Admin.QueryDataService.Contracts;
using TeamManager.Admin.UseCases.Contracts.Teams.Queries;

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
                Team = team
            };
        }
    }
}
