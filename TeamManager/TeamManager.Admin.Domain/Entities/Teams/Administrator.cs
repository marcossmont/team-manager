using System;
using TeamManager.Admin.Domain.Entities.Teams.Exceptions;
using TeamManager.Admin.Domain.ValueObjects;

namespace TeamManager.Admin.Domain.Entities.Teams
{
    public class Administrator
    {
        public Administrator(string name, string emailAddress)
        {
            if (string.IsNullOrEmpty(name))
                throw new AdministratorNameIsRequiredException($"{nameof(name)} is required");

            Name = name;
            Email = new Email(emailAddress);
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public Email Email { get; set; }
    }
}