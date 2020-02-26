using Newtonsoft.Json;
using System.Collections.Generic;

namespace TeamManager.Search.QueryDataService.Contracts.Teams
{
    public class GetTeamsQueryDataAccessOutput
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("createSharePointSite")]
        public bool CreateSharePointSite { get; set; }
        [JsonProperty("createTeamsChannel")]
        public bool CreateTeamsChannel { get; set; }
    }
}