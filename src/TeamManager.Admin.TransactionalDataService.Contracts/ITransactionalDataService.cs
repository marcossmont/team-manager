using System;
using System.Collections.Generic;
using System.Text;
using TeamManager.Admin.TransactionalDataService.Contracts.Repositories;

namespace TeamManager.Admin.TransactionalDataService.Contracts
{
    public interface ITransactionalDataService
    {
        ITeamsRepository TeamsRepository { get; }

        void Persist();
    }
}
