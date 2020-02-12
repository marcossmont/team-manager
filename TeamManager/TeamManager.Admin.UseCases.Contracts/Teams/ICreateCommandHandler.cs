using System;
using System.Collections.Generic;
using System.Text;

namespace TeamManager.Admin.UseCases.Contracts.Teams.Commands
{
    public interface ICreateCommandHandler : ICommandHandler<CreateCommand, CreateCommandResult>
    {
    }
}
