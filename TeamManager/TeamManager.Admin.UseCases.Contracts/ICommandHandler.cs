using System;
using System.Collections.Generic;
using System.Text;

namespace TeamManager.Admin.UseCases.Contracts
{
    public interface ICommandHandler<TCommand, TResult>
    {
        TResult Execute(TCommand input);
    }
}
