using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TeamManager.Search.Queries.Contracts.Teams;
using TeamManager.Search.QueryDataService.Contracts.Teams;

namespace TeamManager.Search.Queries.Teams
{
    public class GetTeamsQuery : IGetTeamsQuery
    {
        private readonly IGetTeamsQueryDataAccess _dataAccess;

        public GetTeamsQuery(IGetTeamsQueryDataAccess dataAccess)
        {
            _dataAccess = dataAccess ?? throw new ArgumentNullException(nameof(dataAccess));
        }
        public GetTeamsQueryResult Query(GetTeamsQueryParameters parameters)
        {
            var dataAccessResult = _dataAccess.Query(new GetTeamsQueryDataAccessInput()
            {
                Name = parameters.Name,
                Description = parameters.Description
            });

            return new GetTeamsQueryResult() {
                Teams = dataAccessResult.Select(t => new GetTeamsQueryResult.TeamModel()
                {
                    Name = t.Name,
                    Desciption = t.Description,
                    CreateSharePointSite = t.CreateSharePointSite,
                    CreateTeamsChannel = t.CreateTeamsChannel
                })
            };
        }
    }
}
