using System;
using System.Collections.Generic;

namespace TeamManager.Admin.Queries.Contracts.Teams
{
    public class GetAllTeamsQueryResult
    {
        public IEnumerable<TeamModel> Teams { get; set; }

        public class TeamModel
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
            public bool CreateSharePointSite { get; set; }
            public bool CreateTeamsChannel { get; set; }
        }
    }
}