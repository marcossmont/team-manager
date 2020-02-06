using System.Collections.Generic;

namespace TeamManager.Admin.UseCases.Contracts.Teams.Queries
{
    public class GetAllQueryResult
    {
        public IEnumerable<Team> Teams { get; set; }

        public class Team
        {
            public string Name { get; set; }
            public bool CreateSharePointSite { get; set; }
            public bool CreateTeamsChannel { get; set; }
        }
    }
}