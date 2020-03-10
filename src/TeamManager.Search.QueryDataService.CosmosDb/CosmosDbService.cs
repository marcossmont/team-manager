using MongoDB.Driver;
using System.Security.Authentication;

namespace TeamManager.Search.QueryDataService.CosmosDb
{
    public class CosmosDbService
    {
        public IMongoDatabase Database { get; }

        public CosmosDbService(string connectionString, string databaseName)
        {
            var url = new MongoUrl(connectionString);
            MongoClientSettings settings = MongoClientSettings.FromUrl(url);
            settings.SslSettings = new SslSettings() { 
                EnabledSslProtocols = SslProtocols.Tls12 
            };
            var mongoClient = new MongoClient(settings);
            Database = mongoClient.GetDatabase(databaseName);
        }
    }
}
