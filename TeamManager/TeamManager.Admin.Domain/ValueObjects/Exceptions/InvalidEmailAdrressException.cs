using System;
using System.Collections.Generic;
using System.Text;

namespace TeamManager.Admin.Domain.ValueObjects.Exceptions
{
    public class InvalidEmailAdrressException : DomainException
    {
        public InvalidEmailAdrressException(string message) : base(message)
        {
        }
    }
}
