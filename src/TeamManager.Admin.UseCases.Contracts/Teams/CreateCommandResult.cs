using Newtonsoft.Json;
using System;

namespace TeamManager.Admin.UseCases.Contracts.Teams.Commands
{
    public class CreateCommandResult
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }
    }
}