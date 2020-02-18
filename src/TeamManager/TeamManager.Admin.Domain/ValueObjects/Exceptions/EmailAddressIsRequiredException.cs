using System;
using System.Collections.Generic;
using System.Text;

namespace TeamManager.Admin.Domain.ValueObjects.Exceptions
{
    public class EmailAddressIsRequiredException : DomainException
    {
        public EmailAddressIsRequiredException(string message) : base(message)
        {
        }
    }
}
