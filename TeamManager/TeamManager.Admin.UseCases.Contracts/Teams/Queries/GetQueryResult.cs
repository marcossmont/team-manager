using System;

namespace TeamManager.Admin.UseCases.Contracts.Teams.Queries
{
    public class GetQueryResult
    {
        public TeamModel Team { get; set; }

        public class TeamModel
        {
            public Guid Id { get; set; }
            public string Desctiption { get; set; }
            public string Name { get; set; }
            public bool CreateSharePointSite { get; set; }
            public bool CreateTeamsChannel { get; set; }
            
        }
    }
}