using MongoDB.Bson.Serialization.Attributes;

namespace TeamManager.Search.QueryDataService.Contracts.Teams
{
    public class GetTeamsQueryDataAccessOutput
    {
        [BsonElement("name")]
        public string Name { get; set; }
        [BsonElement("description")]
        public string Description { get; set; }
        [BsonElement("createSharePointSite")]
        public bool CreateSharePointSite { get; set; }
        [BsonElement("createTeamsChannel")]
        public bool CreateTeamsChannel { get; set; }
    }
}