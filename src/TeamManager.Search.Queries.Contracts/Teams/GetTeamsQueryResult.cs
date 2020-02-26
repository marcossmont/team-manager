using System;
using System.Collections.Generic;

namespace TeamManager.Search.Queries.Contracts.Teams
{
    public class GetTeamsQueryResult
    {
        public IEnumerable<TeamModel> Teams { get; set; }

        public class TeamModel
        {
            public string Name { get; set; }
            public string Desciption { get; set; }
            public bool CreateSharePointSite { get; set; }
            public bool CreateTeamsChannel { get; set; }
        }
    }
}