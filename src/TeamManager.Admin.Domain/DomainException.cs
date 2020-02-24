using System;
using System.Collections.Generic;
using System.Text;

namespace TeamManager.Admin.Domain
{
    public class DomainException : Exception
    {
        public DomainException(string message) : base(message)
        {

        }
    }
}
