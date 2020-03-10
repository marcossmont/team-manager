using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace TeamManager.Admin.Queries.Contracts.Teams
{
    public class GetAllTeamsQueryResult
    {
        [JsonProperty("teams")]
        public IEnumerable<TeamModel> Teams { get; set; }

        public class TeamModel
        {
            [JsonProperty("id")]
            public Guid Id { get; set; }
            [JsonProperty("name")]
            public string Name { get; set; }
            [JsonProperty("createSharePointSite")]
            public bool CreateSharePointSite { get; set; }
            [JsonProperty("createTeamsChannel")]
            public bool CreateTeamsChannel { get; set; }
        }
    }
}