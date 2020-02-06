using System;
using System.Collections.Generic;
using System.Text;
using TeamManager.Admin.Domain.Entities.Teams;
using TeamManager.Admin.TransactionalDataService.Contracts;
using TeamManager.Admin.UseCases.Contracts.Teams.Commands;

namespace TeamManager.Admin.UseCases.Teams.Commands
{
    public class CreateCommandHandler : ICreateCommandHandler
    {
        private readonly ITransactionalDataService _dataService;

        public CreateCommandHandler(ITransactionalDataService dataService)
        {
            _dataService = dataService ?? throw new ArgumentNullException(nameof(dataService));
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

            return new CreateCommandResult()
            {
                Id = team.Id
            };
        }
    }
}
