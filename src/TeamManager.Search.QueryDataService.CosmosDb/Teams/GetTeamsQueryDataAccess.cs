using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using TeamManager.Search.QueryDataService.Contracts.Teams;

namespace TeamManager.Search.QueryDataService.CosmosDb.Teams
{
    public class GetTeamsQueryDataAccess : IGetTeamsQueryDataAccess
    {
        private readonly IMongoDatabase _database;

        public GetTeamsQueryDataAccess(CosmosDbService cosmosDbService)
        {
            _database = cosmosDbService.Database;
        }

        public List<GetTeamsQueryDataAccessOutput> Query(GetTeamsQueryDataAccessInput parameters)
        {
            var teams = _database.GetCollection<GetTeamsQueryDataAccessOutput>("teams");
            return teams.Find(t => t.Name.Contains(parameters.Name) || t.Description.Contains(parameters.Description)).ToList();
        }
    }
}
