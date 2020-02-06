using System;
using System.Collections.Generic;
using System.Text;

namespace TeamManager.Admin.Domain.Entities.Teams.Exceptions
{
    public class AdministratorNameIsRequiredException : DomainException
    {
        public AdministratorNameIsRequiredException(string message) : base(message)
        {
        }
    }
}
