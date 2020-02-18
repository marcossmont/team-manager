using System;

namespace TeamManager.Admin.Queries.Contracts.Teams
{
    public class GetQueryResult
    {
        public TeamModel Team { get; set; }

        public class TeamModel
        {
            public string Desctiption { get; set; }
            public string Name { get; set; }
            public bool CreateSharePointSite { get; set; }
            public bool CreateTeamsChannel { get; set; }
        }
    }
}