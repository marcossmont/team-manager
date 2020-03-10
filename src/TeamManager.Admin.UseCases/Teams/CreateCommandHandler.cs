using System;
using TeamManager.Admin.Domain.Entities.Teams;
using TeamManager.Admin.TransactionalDataService.Contracts;
using TeamManager.Admin.UseCases.Contracts.Teams.Commands;
using TeamManager.Core.BusPublisher;

namespace TeamManager.Admin.UseCases.Teams.Commands
{
    public class CreateCommandHandler : ICreateCommandHandler
    {
        private readonly ITransactionalDataService _dataService;
        private readonly IBusPublisher _busPublisher;

        public CreateCommandHandler(ITransactionalDataService dataService, IBusPublisher busPublisher)
        {
            _dataService = dataService ?? throw new ArgumentNullException(nameof(dataService));
            _busPublisher = busPublisher;
        }

        public CreateCommandResult Execute(CreateCommand input)
        {
            var team = new Team(input.Name, input.Description, input.CreateSharePointSite, input.CreateTeamsChannel);

            foreach (var administrator in input.Administrators)
            {
                team.AddAdministrador(administrator.Name, administrator.EmailAddress);
            }

            _dataService.TeamsRepository.Create(team);
            _dataService.Persist();

            _busPublisher.Publish("teams", new ReadTeamModel()
            {
                Name = input.Name,
                Description = input.Description,
                CreateSharePointSite = input.CreateSharePointSite,
                CreateTeamsChannel = input.CreateTeamsChannel
            }).GetAwaiter();

            return new CreateCommandResult()
            {
                Id = team.Id
            };
        }

        public class ReadTeamModel
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public bool CreateSharePointSite { get; set; }
            public bool CreateTeamsChannel { get; set; }
        }
    }   
}
