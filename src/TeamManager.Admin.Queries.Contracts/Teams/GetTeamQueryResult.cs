using Newtonsoft.Json;
using System;

namespace TeamManager.Admin.Queries.Contracts.Teams
{
    public class GetTeamQueryResult
    {
        [JsonProperty("team")]
        public TeamModel Team { get; set; }

        public class TeamModel
        {
            [JsonProperty("desctiption")]
            public string Desctiption { get; set; }
            [JsonProperty("name")]
            public string Name { get; set; }
            [JsonProperty("createSharePointSite")]
            public bool CreateSharePointSite { get; set; }
            [JsonProperty("createTeamsChannel")]
            public bool CreateTeamsChannel { get; set; }
        }
    }
}