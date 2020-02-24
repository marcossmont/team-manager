using System;
using System.Collections.Generic;
using System.Text;

namespace TeamManager.Admin.Domain.Entities.Teams.Exceptions
{
    public class TeamNameIsRequiredException : DomainException
    {
        public TeamNameIsRequiredException(string message) : base(message)
        {
        }
    }
}
